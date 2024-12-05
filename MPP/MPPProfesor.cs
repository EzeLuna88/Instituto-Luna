using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using DAL;
using Abstraccion;
using System.Collections;
using static BE.BEMateria;
using System.Configuration;
using System.Xml.Linq;
using System.IO;

namespace MPP
{
    public class MPPProfesor : IGestor<BEProfesor>
    {
        readonly string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];


        #region "metodos"
        public List<BEProfesor> ListarProfesor()
        {
            try
            {
                List<BEProfesor> listaProfesores = new List<BEProfesor>();

                if (File.Exists(xmlFilePath))
                {
                    XDocument doc = XDocument.Load(xmlFilePath);
                    XElement profesoresElement = doc.Root.Element("profesores");

                    if (profesoresElement != null)
                    {
                        foreach (XElement profesorElement in profesoresElement.Elements("profesor"))
                        {
                            BEProfesor profesor = new BEProfesor
                            {
                                Codigo = int.Parse(profesorElement.Attribute("codigo").Value),
                                Nombre = profesorElement.Element("nombre").Value,
                                Apellido = profesorElement.Element("apellido").Value,
                                Dni = int.Parse(profesorElement.Element("dni").Value)
                            };

                            listaProfesores.Add(profesor);
                        }
                    }
                }

                return listaProfesores.Count > 0 ? listaProfesores : null;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public List<BECarrera> ListarCarreras(BEProfesor profesor)
        {
            try
            {
                XDocument doc;

                doc = CargarXml();


                List<BECarrera> listaCarreras = new List<BECarrera>();

                var carreras = doc.Descendants("carrera")
    .Where(carrera =>
        carrera.Descendants("profesor").Any(p => (int)p.Attribute("codigo") == profesor.Codigo) ||
        carrera.Descendants("materia").Any(materia =>
            materia.Descendants("profesor").Any(p => (int)p.Attribute("codigo") == profesor.Codigo)))
    .Select(carrera =>


    new BECarrera
    {
        Codigo = (int)carrera.Attribute("codigo"),
        Nombre = carrera.Element("nombre").Value
    })
    .ToList();

                listaCarreras.AddRange(carreras);
                return listaCarreras;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<BEMateria> ListarMaterias(BEProfesor profesor, BECarrera carrera)
        {
            try
            {
                List<BEMateria> materias = new List<BEMateria>();

                XDocument doc;

                if (File.Exists(xmlFilePath))
                {
                    doc = XDocument.Load(xmlFilePath);
                }
                else
                {
                    throw new FileNotFoundException("El archivo XML no se encontró.");
                }

                XElement carreraElement = doc.Descendants("carrera")
                    .FirstOrDefault(c => (int)c.Attribute("codigo") == carrera.Codigo);

                if (carreraElement != null)
                {
                    IEnumerable<XElement> materiasElement = carreraElement.Descendants("materia")
                        .Where(m => m.Descendants("profesor").Any(p => (int)p.Attribute("codigo") == profesor.Codigo));

                    foreach (XElement materiaElement in materiasElement)
                    {
                        BEMateria materia = new BEMateria
                        {
                            Codigo = (int)materiaElement.Attribute("codigo")
                        };
                        XElement materiaEncontrada = doc.Element("sistema")
                                                .Element("materias")
                                                .Elements("materia")
                                          .FirstOrDefault(m => (int)m.Attribute("codigo") == materia.Codigo);
                        materia.Nombre = materiaEncontrada.Element("nombre").Value;
                        materias.Add(materia);
                    }
                }
                else
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }

                return materias;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public List<BEAlumno> ListasAlumnosDeMaterias(BECarrera carrera, BEMateria materia)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();


                XElement carrerasElement = doc.Root.Element("carreras");

                XElement carreraElement = carrerasElement.Elements("carrera")
                    .FirstOrDefault(c => (int)c.Attribute("codigo") == carrera.Codigo);
                if (carreraElement != null)
                {
                    List<BEAlumno> listaAlumnos = new List<BEAlumno>();
                    XElement alumnosElement = carreraElement.Element("alumnos");
                    if (alumnosElement != null)
                    {
                        foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                        {
                            BEAlumno alumno = new BEAlumno
                            {
                                Codigo = (int)alumnoElement.Attribute("codigo")
                            };

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

                    return listaAlumnos;
                }

                throw new InvalidOperationException("La carrera no se encontró.");

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Guardar(BEProfesor bEProfesor)
        {
            try
            {
                XDocument doc;

                doc = CargarXml();


                XElement profesoresElement = doc.Root.Element("profesores");
                if (profesoresElement == null)
                {
                    profesoresElement = new XElement("profesores");
                    doc.Root.Add(profesoresElement);
                }

                int numeroProfesores = profesoresElement.Elements("profesor").Count();

                string profesorDNI = bEProfesor.Dni.ToString().Trim();

                if (bEProfesor.Codigo > 0)
                {
                    XElement profesorAActualizar = profesoresElement.Elements("profesor")
                .FirstOrDefault(u => (int)u.Attribute("codigo") == bEProfesor.Codigo);
                    if (profesorAActualizar != null)
                    {
                        profesorAActualizar.Element("nombre").Value = bEProfesor.Nombre.ToString().Trim();
                        profesorAActualizar.Element("apellido").Value = bEProfesor.Apellido.ToString().Trim();
                        profesorAActualizar.Element("dni").Value = profesorDNI;

                        doc.Save(xmlFilePath);
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException("El profesor no se encontró.");
                    }
                }
                else
                {

                }

                XElement profesorElement = profesoresElement.Elements("profesor")
                    .FirstOrDefault(u => (string)u.Element("dni") == profesorDNI);

                if (profesorElement != null)
                {
                    throw new InvalidOperationException("El DNI ya se encuentra registrado.");
                }
                else
                {
                    if (numeroProfesores == 0)
                    {
                        profesoresElement.Add(new XElement("profesor",
                            new XAttribute("codigo", 1),
                            new XElement("nombre", bEProfesor.Nombre.ToString().Trim()),
                            new XElement("apellido", bEProfesor.Apellido.ToString().Trim()),
                            new XElement("dni", bEProfesor.Dni.ToString().Trim())
                            ));
                    }
                    else
                    {

                        int nuevoCodigo = 1;
                        if (profesoresElement.Elements("profesor").Any())
                        {
                            nuevoCodigo = profesoresElement.Elements("profesor")
                                .Max(u => (int)u.Attribute("codigo")) + 1;
                        }
                        bEProfesor.Codigo = nuevoCodigo;

                        profesoresElement.Add(new XElement("profesor",
                            new XAttribute("codigo", bEProfesor.Codigo.ToString().Trim()),
                            new XElement("nombre", bEProfesor.Nombre.ToString().Trim()),
                            new XElement("apellido", bEProfesor.Apellido.ToString().Trim()),
                            new XElement("dni", bEProfesor.Dni.ToString().Trim())
                            ));
                    }
                }
                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Baja(BEProfesor beProfesor)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement carrerasElement = doc.Root.Element("carreras");
                bool estaAsociado = carrerasElement.Elements("carrera")
                 .Any(carrera => carrera.Element("materias")
                     .Elements("materia")
                     .Any(materia =>
                     {
                         var profesor = materia.Element("profesor");
                         return profesor != null && (string)profesor.Attribute("codigo") == beProfesor.Codigo.ToString();
                     }));


                if (estaAsociado)
                {
                    return false;
                }
                else
                {
                    if (carrerasElement != null)
                    {
                        foreach (XElement carreraElement in carrerasElement.Elements("carrera"))
                        {
                            foreach (XElement materiaElement in carreraElement.Element("materias").Elements("materia"))
                            {
                                XElement profesorElement = materiaElement.Element("profesor");
                                if (profesorElement != null && (string)profesorElement.Attribute("codigo") == beProfesor.Codigo.ToString())
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    XElement profesoresElement = doc.Root.Element("profesores");

                    if (profesoresElement != null)
                    {
                        XElement profesorElement = profesoresElement.Elements("profesor")
                            .FirstOrDefault(u => (string)u.Attribute("codigo") == beProfesor.Codigo.ToString());

                        if (profesorElement != null)
                        {
                            profesorElement.Remove();

                            doc.Save(xmlFilePath);
                            return true;
                        }
                    }

                    return false;

                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public List<BEProfesor> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEProfesor ListarTodo(BEProfesor objeto)
        {
            throw new NotImplementedException();
        }


        public int TotalProfesores()
        {

            int totalProfesores;
            XDocument doc;

            doc = CargarXml();


            totalProfesores = doc.Descendants("profesores").Elements("profesor").Count();

            return totalProfesores;
        }


        public BEProfesor DevolverProfesor(BEUsuario usuario)
        {
            BEProfesor profesor = new BEProfesor();

            XDocument doc;
            doc = CargarXml();

            XElement profesoresElement = doc.Root.Element("profesores");
            if (profesoresElement == null)
            {
                profesoresElement = new XElement("profesores");
                doc.Root.Add(profesoresElement);
            }

            XElement profesorElement = profesoresElement.Elements("profesor")
                .FirstOrDefault(p =>
            (string)p.Element("nombre") == usuario.Nombre &&
            (string)p.Element("apellido") == usuario.Apellido &&
            (int)p.Element("dni") == usuario.Dni);

            if (profesorElement != null)
            {
                profesor.Codigo = (int)profesorElement.Attribute("codigo");
                profesor.Nombre = (string)profesorElement.Element("nombre");
                profesor.Apellido = (string)profesorElement.Element("apellido");
                profesor.Dni = (int)profesorElement.Element("dni");
            }
            return profesor;
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
        #endregion

    }
}
