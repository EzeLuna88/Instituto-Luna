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
using System.Xml.Linq;
using System.IO;
using System.Configuration;

namespace MPP
{

    public class MPPMateria : IGestor<BEMateria>
    {

        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];


        #region "metodos"
        public List<BEMateria> ListarTodo()
        {
            try
            {
                List<BEMateria> listaMaterias = new List<BEMateria>();

                if (File.Exists(xmlFilePath))
                {
                    XDocument doc = XDocument.Load(xmlFilePath);
                    XElement materiasElement = doc.Root.Element("materias");
                    if (materiasElement == null)
                    {
                        materiasElement = new XElement("notas");
                        doc.Root.Add(materiasElement);
                    }

                    if (materiasElement != null)
                    {
                        foreach (XElement materias in materiasElement.Elements("materia"))
                        {
                            BEMateria materia = new BEMateria
                            {
                                Codigo = int.Parse(materias.Attribute("codigo").Value),
                                Nombre = materias.Element("nombre").Value,

                            };

                            listaMaterias.Add(materia);
                        }
                    }
                }

                return listaMaterias.Count > 0 ? listaMaterias : null;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public DataTable ListarAlumnosAsistenciaNotas(BECarrera carrera, BEMateria materia)
        {
            try
            {
                DataTable dtAlumnos = new DataTable();
                dtAlumnos.Columns.Add("Codigo", typeof(int));
                dtAlumnos.Columns.Add("Nombre", typeof(string));
                dtAlumnos.Columns.Add("Apellido", typeof(string));
                dtAlumnos.Columns.Add("DNI", typeof(int));
                dtAlumnos.Columns.Add("Porcentaje Asistencia", typeof(double));
                dtAlumnos.Columns.Add("Parcial 1", typeof(double));
                dtAlumnos.Columns.Add("Parcial 2", typeof(double));


                XDocument doc;

                if (File.Exists(xmlFilePath))
                {
                    doc = XDocument.Load(xmlFilePath);
                }
                else
                {
                    throw new FileNotFoundException("El archivo XML no se encontró.");
                }

                //buscar carrera
                XElement carreraElement = doc.Descendants("carrera")
                    .FirstOrDefault(c => (int)c.Attribute("codigo") == carrera.Codigo);

                if (carreraElement != null)
                {

                    XElement asistenciasElement = doc.Root.Element("asistencias");
                    if (asistenciasElement != null)
                    {
                        var asistencias = asistenciasElement.Elements("asistencia")
                            .Where(a =>
                                (int)a.Element("codigo_carrera") == carrera.Codigo &&
                                (int)a.Element("codigo_materia") == materia.Codigo);

                        XElement alumnosRootElement = doc.Root.Element("alumnos");
                        if (alumnosRootElement != null)
                        {
                            var alumnos = carreraElement.Element("alumnos").Elements("alumno");

                            foreach (var alumnoElement in alumnos)
                            {
                                int codigoAlumno = (int)alumnoElement.Attribute("codigo");

                                XElement alumnoInfoElement = alumnosRootElement.Elements("alumno")
                                    .FirstOrDefault(a => (int)a.Attribute("codigo") == codigoAlumno);

                                if (alumnoInfoElement != null)
                                {
                                    var asistenciasAlumno = asistencias
                                        .Where(a => (int)a.Element("codigo_alumno") == codigoAlumno);

                                    int totalAsistencias = asistenciasAlumno.Count();
                                    int asistenciasPresentes = asistenciasAlumno.Count(a => (bool)a.Element("asistencia"));

                                    double porcentajeAsistencia = totalAsistencias > 0
                                        ? (double)asistenciasPresentes / totalAsistencias * 100
                                        : 0;

                                    double notaParcial1 = 0;
                                    double notaParcial2 = 0;
                                    // Calcular el promedio de parciales
                                    XElement notasElement = doc.Root.Element("notas");
                                    double promedioParciales = 0;
                                    if (notasElement != null)
                                    {
                                        var notasAlumno = notasElement.Elements("nota")
                                            .FirstOrDefault(n =>
                                                (int)n.Element("codigo_carrera") == carrera.Codigo &&
                                                (int)n.Element("codigo_materia") == materia.Codigo &&
                                                (int)n.Element("codigo_alumno") == codigoAlumno);

                                        if (notasAlumno != null)
                                        {
                                            notaParcial1 = (double)notasAlumno.Element("nota_parcial_1");
                                            notaParcial2 = (double)notasAlumno.Element("nota_parcial_2");
                                        }
                                    }

                                    DataRow row = dtAlumnos.NewRow();
                                    row["Codigo"] = (int)alumnoInfoElement.Attribute("codigo");
                                    row["Nombre"] = (string)alumnoInfoElement.Element("nombre");
                                    row["Apellido"] = (string)alumnoInfoElement.Element("apellido");
                                    row["DNI"] = (int)alumnoInfoElement.Element("dni");
                                    row["Porcentaje Asistencia"] = porcentajeAsistencia;
                                    row["Parcial 1"] = notaParcial1;
                                    row["Parcial 2"] = notaParcial2;
                                    dtAlumnos.Rows.Add(row);
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }
                return dtAlumnos;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Guardar(BEMateria bEMateria)
        {
            try
            {
                XDocument doc;

                doc = CargarXml();
                XElement materiasElement = doc.Root.Element("materias");
                if (materiasElement == null)
                {
                    materiasElement = new XElement("materias");
                    doc.Root.Add(materiasElement);
                }

                int numeroMaterias = materiasElement.Elements("materia").Count();

                if (bEMateria.Codigo > 0)
                {
                    XElement materiaActualizar = materiasElement.Elements("materia")
                .FirstOrDefault(u => (int)u.Attribute("codigo") == bEMateria.Codigo);
                    if (materiaActualizar != null)
                    {
                        materiaActualizar.Element("nombre").Value = bEMateria.Nombre.ToString().Trim();

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

                if (numeroMaterias == 0)
                {
                    materiasElement.Add(new XElement("materia",
                        new XAttribute("codigo", 1),
                        new XElement("nombre", bEMateria.Nombre.ToString().Trim())

                        ));
                }
                else
                {

                    int nuevoCodigo = 1;
                    if (materiasElement.Elements("materia").Any())
                    {
                        nuevoCodigo = materiasElement.Elements("materia")
                            .Max(u => (int)u.Attribute("codigo")) + 1;
                    }
                    bEMateria.Codigo = nuevoCodigo;

                    materiasElement.Add(new XElement("materia",
                        new XAttribute("codigo", bEMateria.Codigo.ToString().Trim()),
                        new XElement("nombre", bEMateria.Nombre.ToString().Trim())
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


        public bool Baja(BEMateria bEMateria)
        {
            throw new NotImplementedException();

        }

        public (bool exito, string mensaje) BajaMateria(BEMateria bEMateria)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement carrerasElement = doc.Root.Element("carreras");
                bool estaAsociada = carrerasElement.Elements("carrera")
             .Any(carreras => carreras.Element("materias")
                 .Elements("materia")
                 .Any(materia => (string)materia.Attribute("codigo") == bEMateria.Codigo.ToString()));

                if (estaAsociada)
                {
                    return (false, "La materia no se puede eliminar porque está asociada a una o más carreras.");
                }

                XElement materiasElement = doc.Root.Element("materias");

                if (materiasElement != null)
                {
                    XElement materiaElement = materiasElement.Elements("materia")
                        .FirstOrDefault(u => (string)u.Attribute("codigo") == bEMateria.Codigo.ToString());

                    if (materiasElement != null)
                    {
                        materiaElement.Remove();

                        doc.Save(xmlFilePath);
                        return (true, string.Empty);
                    }
                }

                return (false, "La materia no se encontró.");
            }
            catch (Exception e)
            {

                return (false, "Error al intentar eliminar la materia: " + e.Message);
            }
        }

        public BEMateria ListarTodo(BEMateria objeto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarCorrelatividad(BEMateria materiaPrincipal, BEMateria materiaCorrelativa, BECarrera carrera)
        {
            try
            {
                XDocument doc;
                if (File.Exists(xmlFilePath))
                {
                    doc = XDocument.Load(xmlFilePath);
                }
                else
                {
                    throw new FileNotFoundException("El archivo XML no se encontró.");
                }

                XElement carrerasElement = doc.Root.Element("carreras");
                if (carrerasElement == null)
                {
                    throw new InvalidOperationException("El archivo XML no contiene la estructura esperada.");
                }

                XElement carreraElement = carrerasElement.Elements("carrera")
                    .FirstOrDefault(u => (int)u.Attribute("codigo") == carrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }

                XElement materiasElement = carreraElement.Element("materias");
                if (materiasElement == null)
                {
                    throw new InvalidOperationException("La carrera no contiene materias.");
                }

                XElement materiaElement = materiasElement.Elements("materia")
                    .FirstOrDefault(m => (int)m.Attribute("codigo") == materiaPrincipal.Codigo);

                if (materiaElement == null)
                {
                    throw new InvalidOperationException("La materia no se encontró.");
                }

                XElement correlatividadesElement = materiaElement.Element("correlatividades");
                if (correlatividadesElement == null)
                {
                    correlatividadesElement = new XElement("correlatividades");
                    materiaElement.Add(correlatividadesElement);
                }

                if (correlatividadesElement.Elements("correlativa").Any(c => (int)c.Attribute("codigo") == materiaCorrelativa.Codigo))
                {
                    throw new InvalidOperationException("La correlatividad ya está asignada a esta materia.");
                }

                correlatividadesElement.Add(new XElement("correlativa", new XAttribute("codigo", materiaCorrelativa.Codigo)));

                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public bool QuitarCorrelatividad(BECarrera carrera, BEMateria materia)
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
            .FirstOrDefault(u => (int)u.Attribute("codigo") == carrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }


                XElement materiasElement = carreraElement.Element("materias");
                if (materiasElement != null)
                {
                    XElement materiaElement = materiasElement.Elements("materia")
                         .FirstOrDefault(u => (int)u.Attribute("codigo") == materia.Codigo);

                    if (materiaElement != null)
                    {
                        XElement correlativasElement = materiaElement.Element("correlatividades");
                        if (correlativasElement != null)
                        {
                            IEnumerable<XElement> correlativaElements = correlativasElement.Elements("correlativa");


                            foreach (XElement correlativaElement in correlativaElements.ToList())
                            {
                                correlativaElement.Remove();
                            }
                            doc.Save(xmlFilePath);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public bool GuardarProfesor(BEMateria materia, BECarrera carrera, BEProfesor profesor)
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
            .FirstOrDefault(u => (int)u.Attribute("codigo") == carrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }


                XElement materiasElement = carreraElement.Element("materias");
                if (materiasElement != null)
                {
                    XElement materiaElement = materiasElement.Elements("materia")
                         .FirstOrDefault(u => (int)u.Attribute("codigo") == materia.Codigo);

                    if (materiaElement != null)
                    {
                        materiaElement.Add(new XElement("profesor",
                            new XAttribute("codigo", profesor.Codigo)
                            ));

                        doc.Save(xmlFilePath);
                    }

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool QuitarProfesor(BECarrera carrera, BEMateria materia)
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
            .FirstOrDefault(u => (int)u.Attribute("codigo") == carrera.Codigo);

                if (carreraElement == null)
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }


                XElement materiasElement = carreraElement.Element("materias");
                if (materiasElement != null)
                {
                    XElement materiaElement = materiasElement.Elements("materia")
                         .FirstOrDefault(u => (int)u.Attribute("codigo") == materia.Codigo);

                    if (materiaElement != null)
                    {
                        XElement profesorElement = materiaElement.Element("profesor");
                        if (profesorElement != null)
                        {
                            profesorElement.Remove();
                            doc.Save(xmlFilePath);
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
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

        #endregion
    }
}
