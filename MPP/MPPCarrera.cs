using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;
using Abstraccion;
using System.Collections;
using static BE.BEMateria;
using System.Security.Policy;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using System.CodeDom;
using System.Xml;
using System.Net;

namespace MPP
{

    public class MPPCarrera : IGestor<BECarrera>
    {

        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];


        #region "metodos"
        public List<BECarrera> ListarTodo()
        {
            try
            {
                List<BECarrera> listaCarreras = new List<BECarrera>();
                XDocument doc;


                doc = XDocument.Load(xmlFilePath);

                foreach (XElement element in doc.Descendants("carrera"))
                {
                    BECarrera carrera = new BECarrera();
                    carrera.Codigo = int.Parse(element.Attribute("codigo").Value);
                    carrera.Nombre = element.Element("nombre").Value;

                    //Listar materias
                    List<BEMateria> listaMaterias = new List<BEMateria>();
                    XElement materiasElement = element.Element("materias");
                    if (materiasElement != null)
                    {
                        foreach (XElement materiaElement in materiasElement.Elements("materia"))
                        {
                            BEMateria materia = new BEMateria();
                            materia.Codigo = (int)materiaElement.Attribute("codigo");
                            XElement materiaEncontrada = doc.Element("sistema")
                                                .Element("materias")
                                                .Elements("materia")
                                                .FirstOrDefault(m => (int)m.Attribute("codigo") == materia.Codigo);
                            materia.Nombre = materiaEncontrada.Element("nombre").Value;
                            listaMaterias.Add(materia);

                            XElement profesorElement = materiaElement.Element("profesor");
                            if (profesorElement != null)
                            {

                                BEProfesor profesor = new BEProfesor();
                                profesor.Codigo = (int)materiaElement.Element("profesor").Attribute("codigo");
                                XElement profesorEncontrado = doc.Element("sistema")
                                                .Element("profesores")
                                                .Elements("profesor")
                                    .FirstOrDefault(m => (int)m.Attribute("codigo") == profesor.Codigo);
                                profesor.Nombre = profesorEncontrado.Element("nombre").Value;
                                profesor.Apellido = profesorEncontrado.Element("apellido").Value;
                                profesor.Dni = int.Parse(profesorEncontrado.Element("dni").Value);

                                materia.Profesor = profesor;
                            }
                            //Listar correlatividades
                            List<BEMateria> listaCorrelatividades = new List<BEMateria>();
                            XElement correlatividadesElement = materiaElement.Element("correlatividades");
                            if (correlatividadesElement != null)
                            {
                                foreach (XElement correlativaElement in correlatividadesElement.Elements("correlativa"))
                                {
                                    BEMateria correlativa = new BEMateria();
                                    correlativa.Codigo = (int)correlativaElement.Attribute("codigo");

                                    XElement materiaCorrelativaEncontrada = doc.Element("sistema")
                                                .Element("materias")
                                                .Elements("materia")
                                        .FirstOrDefault(m => (int)m.Attribute("codigo") == correlativa.Codigo);

                                    if (materiaEncontrada != null)
                                    {
                                        correlativa.Nombre = materiaCorrelativaEncontrada.Element("nombre").Value;
                                    }

                                    listaCorrelatividades.Add(correlativa);
                                }
                            }
                            materia.Correlatividad = listaCorrelatividades;

                        }
                    }
                    carrera.ListaMaterias = listaMaterias;


                    //Listar alumnos
                    List<BEAlumno> listaAlumnos = new List<BEAlumno>();
                    XElement alumnosElement = element.Element("alumnos");
                    if (alumnosElement != null)
                    {
                        foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                        {
                            BEAlumno alumno = new BEAlumno();
                            alumno.Codigo = (int)alumnoElement.Attribute("codigo");

                            XElement alumnoGuardar = doc.Root.Element("alumnos");

                            XElement alumnoEncontrado = alumnoGuardar.Elements("alumno")
                                      .FirstOrDefault(m => (int)m.Attribute("codigo") == alumno.Codigo);

                            if (alumnoEncontrado != null)
                            {
                                alumno.Nombre = alumnoEncontrado.Element("nombre").Value;
                                alumno.Apellido = alumnoEncontrado.Element("apellido").Value;
                                alumno.FechaDeNacimiento = Convert.ToDateTime(alumnoEncontrado.Element("fecha_de_nacimiento").Value);
                                alumno.Direccion = alumnoEncontrado.Element("direccion").Value;
                                alumno.Telefono = alumnoEncontrado.Element("telefono").Value;
                                alumno.Email = alumnoEncontrado.Element("email").Value;
                                alumno.Dni = Convert.ToInt32(alumnoEncontrado.Element("dni").Value);
                            }

                            listaAlumnos.Add(alumno);
                        }
                    }
                    carrera.ListaAlumnos = listaAlumnos;

                    listaCarreras.Add(carrera);
                }
                return listaCarreras;
            }
            catch (Exception e)
            {
                throw e;
            }


        }



        public List<BEMateria> ListarMaterias(BECarrera beCarrera)
        {
            try
            {

                List<BEMateria> listaMaterias = new List<BEMateria>();
                XDocument doc;
                doc = CargarXml();
                XElement carrerasElement = doc.Root.Element("carreras");
                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                XElement carreraElement = carrerasElement.Elements("carrera")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == beCarrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }

                XElement materiasElement = carreraElement.Element("materias");
                if (materiasElement != null)
                {
                    foreach (XElement materiaElement in materiasElement.Elements("materia"))
                    {
                        BEMateria materia = new BEMateria();
                        materia.Codigo = (int)materiaElement.Attribute("codigo");
                        XElement materiaEncontrada = doc.Element("sistema")
                                                .Element("materias")
                                                .Elements("materia")
                                  .FirstOrDefault(m => (int)m.Attribute("codigo") == materia.Codigo);
                        materia.Nombre = materiaEncontrada.Element("nombre").Value;
                        listaMaterias.Add(materia);

                        //Listar correlatividades
                        List<BEMateria> listaCorrelatividades = new List<BEMateria>();
                        XElement correlatividadesElement = materiaElement.Element("correlatividades");
                        if (correlatividadesElement != null)
                        {
                            foreach (XElement correlativaElement in correlatividadesElement.Elements("correlativa"))
                            {
                                BEMateria correlativa = new BEMateria();
                                correlativa.Codigo = (int)correlativaElement.Attribute("codigo");

                                XElement materiaCorrelativaEncontrada = doc.Element("sistema")
                                                .Element("materias")
                                                .Elements("materia")
                                    .FirstOrDefault(m => (int)m.Attribute("codigo") == correlativa.Codigo);

                                if (materiaEncontrada != null)
                                {
                                    correlativa.Nombre = materiaCorrelativaEncontrada.Element("nombre").Value;
                                }

                                listaCorrelatividades.Add(correlativa);
                            }
                        }
                        materia.Correlatividad = listaCorrelatividades;

                    }
                }
                return listaMaterias;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private XDocument CargarXml()
        {
            XDocument doc;
            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);
            }
            else
            {
                doc = new XDocument(new XElement("sistema"));
            }

            return doc;
        }

        public bool Guardar(BECarrera carrera)
        {
            try
            {
                XDocument doc;

                doc = CargarXml();

                XElement carrerasElement = doc.Root.Element("carreras");
                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                int numeroCarreras = carrerasElement.Elements("carrera").Count();

                if (carrera.Codigo > 0)
                {
                    XElement carreraActualizar = carrerasElement.Elements("carrera")
                .FirstOrDefault(u => (int)u.Attribute("codigo") == carrera.Codigo);
                    if (carreraActualizar != null)
                    {
                        carreraActualizar.Element("nombre").Value = carrera.Nombre.ToString().Trim();

                        doc.Save(xmlFilePath);
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException("La materia no se encontró.");
                    }
                }
                else
                {

                }

                if (numeroCarreras == 0)
                {
                    carrerasElement.Add(new XElement("carrera",
                        new XAttribute("codigo", 1),
                        new XElement("nombre", carrera.Nombre.ToString().Trim())

                        ));
                }
                else
                {

                    int nuevoCodigo = 1;
                    if (carrerasElement.Elements("carrera").Any())
                    {
                        nuevoCodigo = carrerasElement.Elements("carrera")
                            .Max(u => (int)u.Attribute("codigo")) + 1;
                    }
                    carrera.Codigo = nuevoCodigo;

                    carrerasElement.Add(new XElement("carrera",
                        new XAttribute("codigo", carrera.Codigo.ToString().Trim()),
                        new XElement("nombre", carrera.Nombre.ToString().Trim())
                        ));
                }
                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Baja(BECarrera carrera)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement carrerasElement = doc.Root.Element("carreras");
                XElement asistenciasElement = doc.Root.Element("asistencias");
                XElement notasElement = doc.Root.Element("notas");

                if (carrerasElement != null)
                {
                    XElement carreraElement = carrerasElement.Elements("carrera")
                        .FirstOrDefault(u => (string)u.Attribute("codigo") == carrera.Codigo.ToString());

                    if (carrerasElement != null)
                    {
                        carreraElement.Remove();
                        if (asistenciasElement != null)
                        {
                            var asistenciaAQuitar = asistenciasElement.Elements("asistencia")
                        .Where(a => (string)a.Element("codigo_carrera") == carrera.Codigo.ToString())
                        .ToList();

                            foreach (var asistencia in asistenciaAQuitar)
                            {
                                asistencia.Remove();
                            }
                        }
                        if (notasElement != null)
                        {
                            var notaAQuitar = notasElement.Elements("nota")
                        .Where(a => (string)a.Element("codigo_carrera") == carrera.Codigo.ToString())
                        .ToList();

                            foreach (var nota in notaAQuitar)
                            {
                                nota.Remove();
                            }
                        }



                        doc.Save(xmlFilePath);


                        return true;
                    }
                }




                return false;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool AgregarMateria(BECarrera bECarrera, BEMateria bEMateria, bool materiaInicial)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                XElement carrerasElement = doc.Root.Element("carreras");
                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                XElement carreraElement = carrerasElement.Elements("carrera")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == bECarrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }

                XElement materiasElement = carreraElement.Element("materias");
                if (materiasElement == null)
                {
                    materiasElement = new XElement("materias");
                    carreraElement.Add(materiasElement);
                }

                if (materiasElement.Elements("materia").Any(m => (int)m.Attribute("codigo") == bEMateria.Codigo))
                {
                    throw new InvalidOperationException("La materia ya está asignada a esta carrera.");
                }

                materiasElement.Add(new XElement("materia",
            new XAttribute("codigo", bEMateria.Codigo),
            new XElement("materiaInicial", materiaInicial)
        ));


                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public bool AgregarAlumno(BECarrera bECarrera, BEAlumno bEAlumno)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                XElement carrerasElement = doc.Root.Element("carreras");
                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                XElement carreraElement = carrerasElement.Elements("carrera")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == bECarrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }

                XElement alumnosElement = carreraElement.Element("alumnos");
                if (alumnosElement == null)
                {
                    alumnosElement = new XElement("alumnos");
                    carreraElement.Add(alumnosElement);
                }

                if (alumnosElement.Elements("alumno").Any(m => (int)m.Attribute("codigo") == bEAlumno.Codigo))
                {
                    throw new InvalidOperationException("El alumno ya está asignado a esta carrera.");
                }

                alumnosElement.Add(new XElement("alumno",
            new XAttribute("codigo", bEAlumno.Codigo)

        ));
                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public bool BorrarMateria(BECarrera bECarrera, BEMateria bEMateria)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                XElement carrerasElement = doc.Root.Element("carreras");
                XElement asistenciasElement = doc.Root.Element("asistencias");
                XElement notasElement = doc.Root.Element("notas");

                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                XElement carreraElement = carrerasElement.Elements("carrera")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == bECarrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }
                else
                {
                    XElement materiaElement = carreraElement.Element("materias")?
                    .Elements("materia")
                        .FirstOrDefault(u => (int)u.Attribute("codigo") == bEMateria.Codigo);
                    if (materiaElement == null)
                    {
                        throw new InvalidOperationException("La materia no se encontró.");
                    }
                    else
                    {
                        materiaElement.Remove();
                        if (asistenciasElement != null)
                        {
                            var asistenciaAQuitar = asistenciasElement.Elements("asistencia")
                        .Where(a => (string)a.Element("codigo_carrera") == bECarrera.Codigo.ToString()
                              && (string)a.Element("codigo_materia") == bEMateria.Codigo.ToString()
                        )
                        .ToList();

                            foreach (var asistencia in asistenciaAQuitar)
                            {
                                asistencia.Remove();
                            }
                        }
                        if (notasElement != null)
                        {
                            var notaAQuitar = notasElement.Elements("nota")
                        .Where(a => (string)a.Element("codigo_carrera") == bECarrera.Codigo.ToString()
                        && (string)a.Element("codigo_materia") == bEMateria.Codigo.ToString())
                        .ToList();

                            foreach (var nota in notaAQuitar)
                            {
                                nota.Remove();
                            }
                        }
                        doc.Save(xmlFilePath);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public bool BorrarAlumno(BECarrera bECarrera, BEAlumno beAlumno)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                XElement carrerasElement = doc.Root.Element("carreras");
                XElement asistenciasElement = doc.Root.Element("asistencias");
                XElement notasElement = doc.Root.Element("notas");

                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                XElement carreraElement = carrerasElement.Elements("carrera")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == bECarrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }
                else
                {
                    XElement alumnoElement = carreraElement.Element("alumnos")?
                    .Elements("alumno")
                        .FirstOrDefault(u => (int)u.Attribute("codigo") == beAlumno.Codigo);
                    if (alumnoElement == null)
                    {
                        throw new InvalidOperationException("La materia no se encontró.");
                    }
                    else
                    {

                        alumnoElement.Remove();
                        if (asistenciasElement != null)
                        {
                            var asistenciaAQuitar = asistenciasElement.Elements("asistencia")
                        .Where(a => (string)a.Element("codigo_carrera") == bECarrera.Codigo.ToString()
                              && (string)a.Element("codigo_alumno") == beAlumno.Codigo.ToString()
                        )
                        .ToList();

                            foreach (var asistencia in asistenciaAQuitar)
                            {
                                asistencia.Remove();
                            }
                        }
                        if (notasElement != null)
                        {
                            var notaAQuitar = notasElement.Elements("nota")
                        .Where(a => (string)a.Element("codigo_carrera") == bECarrera.Codigo.ToString()
                        && (string)a.Element("codigo_alumno") == beAlumno.Codigo.ToString())
                        .ToList();

                            foreach (var nota in notaAQuitar)
                            {
                                nota.Remove();
                            }
                        }


                        doc.Save(xmlFilePath);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public BECarrera ListarTodo(BECarrera objeto)
        {
            throw new NotImplementedException();
        }


        public int TotalCarreras()
        {
            int totalCarreras = 0;
            XDocument doc;
            doc = CargarXml();

            XElement carrerasElement = doc.Root.Element("carreras");
            if (carrerasElement != null)
            {
                totalCarreras = doc.Descendants("carreras").Elements("carrera").Count();
            }
            return totalCarreras;
        }


        public DataTable TotalesAlumnosPorCarrera()
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                DataTable dtCarreras = new DataTable();
                dtCarreras.Columns.Add("Codigo", typeof(int));
                dtCarreras.Columns.Add("Nombre", typeof(string));
                dtCarreras.Columns.Add("Cantidad", typeof(int));
                XElement carrerasElement = doc.Root.Element("carreras");
                if (carrerasElement == null)
                {
                    carrerasElement = new XElement("carreras");
                    doc.Root.Add(carrerasElement);
                }

                var carreras = from carrera in doc.Root.Element("carreras").Elements("carrera")
                               let codigo = (int)carrera.Attribute("codigo")
                               let nombre = (string)carrera.Element("nombre")
                               let cantidad = carrera.Element("alumnos")?.Elements("alumno").Count() ?? 0
                               select new
                               {
                                   Codigo = codigo,
                                   Nombre = nombre,
                                   Cantidad = cantidad
                               };
                foreach (var carrera in carreras)
                {
                    dtCarreras.Rows.Add(carrera.Codigo, carrera.Nombre, carrera.Cantidad);
                }

                return dtCarreras;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

    }
}
