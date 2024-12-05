using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MPP
{

    public class MPPAsistencia
    {

        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];


        public bool GuardarAsistencia(List<BEAsistencia> listaAsistencias)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement == null)
                {
                    asistenciasElement = new XElement("asistencias");
                    doc.Root.Add(asistenciasElement);
                }


                int numeroMaterias = asistenciasElement.Elements("asistencia").Count();



                foreach (BEAsistencia asistencia in listaAsistencias)
                {
                    if (numeroMaterias == 0)
                    {
                        asistenciasElement.Add(new XElement("asistencia",
                            new XAttribute("codigo", 1),
                            new XElement("codigo_carrera", asistencia.IdCarrera),
                            new XElement("codigo_materia", asistencia.IdMateria),
                            new XElement("codigo_alumno", asistencia.IdAlumno),
                            new XElement("fecha", asistencia.Fecha.ToString("MM/dd/yyyy")),
                            new XElement("asistencia", asistencia.Asistencia)

                            ));

                        doc.Save(xmlFilePath);
                        numeroMaterias++;
                    }
                    else
                    {
                        int nuevoCodigo = 1;
                        if (asistenciasElement.Elements("asistencia").Any())
                        {
                            nuevoCodigo = asistenciasElement.Elements("asistencia")
                                .Max(u => (int)u.Attribute("codigo")) + 1;
                        }

                        asistenciasElement.Add(new XElement("asistencia",
                            new XAttribute("codigo", nuevoCodigo),
                            new XElement("codigo_carrera", asistencia.IdCarrera),
                            new XElement("codigo_materia", asistencia.IdMateria),
                            new XElement("codigo_alumno", asistencia.IdAlumno),
                            new XElement("fecha", asistencia.Fecha.ToString("MM/dd/yyyy")),
                            new XElement("asistencia", asistencia.Asistencia)

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

        public bool ModificarAsistencia(BEAsistencia asistencia)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();


                XElement asistenciasElement = doc.Root.Element("asistencias");

                XElement asistenciaElement = asistenciasElement.Elements("asistencia")
    .FirstOrDefault(a =>
        (int)a.Element("codigo_carrera") == asistencia.IdCarrera &&
        (int)a.Element("codigo_materia") == asistencia.IdMateria &&
        (int)a.Element("codigo_alumno") == asistencia.IdAlumno &&
        (string)a.Element("fecha") == asistencia.Fecha.ToString("MM/dd/yyyy"));



                if (asistenciaElement != null)
                {
                    // Actualizar el valor de la asistencia
                    asistenciaElement.Element("asistencia").Value = asistencia.Asistencia.ToString();
                    doc.Save(xmlFilePath);
                    return true;
                }
                else
                {
                    // Si no se encuentra la asistencia, devolver false
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool ComprobarAsistenciaEnFecha(BECarrera carrera, BEMateria materia, string fecha)
        {
            XDocument doc;

            doc = CargarXml();

            XElement asistenciasElement = doc.Root.Element("asistencias");
            if (asistenciasElement == null)
            {
                asistenciasElement = new XElement("asistencias");
                doc.Root.Add(asistenciasElement);
                doc.Save(xmlFilePath);
                return false;
            }

            var asistencia = doc.Root.Element("asistencias").Elements("asistencia")
                .FirstOrDefault(a =>
                    (int)a.Element("codigo_carrera") == carrera.Codigo &&
                    (int)a.Element("codigo_materia") == materia.Codigo &&
                    (string)a.Element("fecha") == fecha);

            // Si no se encontró ninguna asistencia, retornar falso
            if (asistencia == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public DataTable DevolverAsistencia(BECarrera carrera, BEMateria materia, string fecha)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();


                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement != null)
                {
                    var asistencias = asistenciasElement.Elements("asistencia")
                .Where(a =>
                    (int)a.Element("codigo_carrera") == carrera.Codigo &&
                    (int)a.Element("codigo_materia") == materia.Codigo &&
                    (string)a.Element("fecha") == fecha)
                .Select(a => new
                {
                    Codigo = (int)a.Attribute("codigo"),
                    CodigoCarrera = (int)a.Element("codigo_carrera"),
                    CodigoMateria = (int)a.Element("codigo_materia"),
                    CodigoAlumno = (int)a.Element("codigo_alumno"),
                    Fecha = (string)a.Element("fecha"),
                    Asistencia = (bool)a.Element("asistencia")
                });

                    DataTable dtAsistencia = new DataTable();
                    dtAsistencia.Columns.Add("Asistencia", typeof(bool));
                    dtAsistencia.Columns.Add("Nombre", typeof(string));
                    dtAsistencia.Columns.Add("Apellido", typeof(string));
                    dtAsistencia.Columns.Add("Dni", typeof(string));
                    dtAsistencia.Columns.Add("CodigoAlumno", typeof(int));



                    foreach (var asistencia in asistencias)
                    {
                        XElement alumnosElement = doc.Root.Element("alumnos");
                        XElement alumnoElement = alumnosElement.Elements("alumno")
                            .FirstOrDefault(alumno =>
                                (int)alumno.Attribute("codigo") == asistencia.CodigoAlumno);

                        string nombreAlumno = (alumnoElement != null) ? alumnoElement.Element("nombre").Value : "Desconocido";
                        string apellidoAlumno = (alumnoElement != null) ? alumnoElement.Element("apellido").Value : "Desconocido";
                        string dniAlumno = (alumnoElement != null) ? alumnoElement.Element("dni").Value : "Desconocido";

                        dtAsistencia.Rows.Add(asistencia.Asistencia, nombreAlumno, apellidoAlumno, dniAlumno, asistencia.CodigoAlumno);
                    }

                    return dtAsistencia;
                }

                return new DataTable();


            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public DataTable DevolverAsistenciaPorFecha(BECarrera carrera, BEMateria materia)
        {
            try
            {
                XDocument doc = CargarXml();

                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement != null)
                {
                    string formatoFecha = "MM/dd/yyyy"; // Cambia esto según el formato que esperas


                    // Obtener todas las fechas únicas
                    var fechasUnicas = asistenciasElement.Elements("asistencia")
                .Where(a =>
                    (int)a.Element("codigo_carrera") == carrera.Codigo &&
                    (int)a.Element("codigo_materia") == materia.Codigo)
                .Select(a => (string)a.Element("fecha"))
                .Distinct()
                .OrderBy(f =>
                {
                    DateTime fecha;
                    DateTime.TryParseExact(f, formatoFecha,
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None,
                                           out fecha);
                    return fecha;
                })
                .ToList();

                    // Crear el DataTable con las columnas necesarias
                    DataTable dtAsistencia = new DataTable();
                    dtAsistencia.Columns.Add("Nombre", typeof(string));
                    dtAsistencia.Columns.Add("Apellido", typeof(string));
                    dtAsistencia.Columns.Add("Dni", typeof(string));
                    foreach (var fecha in fechasUnicas)
                    {
                        dtAsistencia.Columns.Add(fecha, typeof(bool));
                    }
                    dtAsistencia.Columns.Add("CodigoAlumno", typeof(int));

                    // Obtener todas las asistencias para la carrera y materia especificadas
                    var asistencias = asistenciasElement.Elements("asistencia")
                        .Where(a =>
                            (int)a.Element("codigo_carrera") == carrera.Codigo &&
                            (int)a.Element("codigo_materia") == materia.Codigo)
                        .Select(a => new
                        {
                            Codigo = (int)a.Attribute("codigo"),
                            CodigoCarrera = (int)a.Element("codigo_carrera"),
                            CodigoMateria = (int)a.Element("codigo_materia"),
                            CodigoAlumno = (int)a.Element("codigo_alumno"),
                            Fecha = (string)a.Element("fecha"),
                            Asistencia = (bool)a.Element("asistencia")
                        });

                    // Obtener los elementos de alumnos
                    XElement alumnosElement = doc.Root.Element("alumnos");

                    // Agrupar asistencias por alumno
                    var asistenciasPorAlumno = asistencias
                        .GroupBy(a => a.CodigoAlumno)
                        .ToList();

                    foreach (var grupo in asistenciasPorAlumno)
                    {
                        var primeraAsistencia = grupo.First();
                        XElement alumnoElement = alumnosElement.Elements("alumno")
                            .FirstOrDefault(alumno =>
                                (int)alumno.Attribute("codigo") == primeraAsistencia.CodigoAlumno);

                        string nombreAlumno = (alumnoElement != null) ? alumnoElement.Element("nombre").Value : "Desconocido";
                        string apellidoAlumno = (alumnoElement != null) ? alumnoElement.Element("apellido").Value : "Desconocido";
                        string dniAlumno = (alumnoElement != null) ? alumnoElement.Element("dni").Value : "Desconocido";

                        DataRow row = dtAsistencia.NewRow();
                        row["Nombre"] = nombreAlumno;
                        row["Apellido"] = apellidoAlumno;
                        row["Dni"] = dniAlumno;
                        row["CodigoAlumno"] = primeraAsistencia.CodigoAlumno;

                        foreach (var asistencia in grupo)
                        {
                            DateTime fecha;
                            if (DateTime.TryParseExact(asistencia.Fecha, formatoFecha,
                                                       System.Globalization.CultureInfo.InvariantCulture,
                                                       System.Globalization.DateTimeStyles.None,
                                                       out fecha))
                            {
                                row[asistencia.Fecha] = asistencia.Asistencia;
                            }
                        }

                        dtAsistencia.Rows.Add(row);
                    }

                    return dtAsistencia;
                }

                return new DataTable();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GuardarAsistenciaPorFecha(List<BEAsistencia> listaAsistencia)
        {
            XDocument doc = CargarXml();

            XElement asistenciasElement = doc.Root.Element("asistencias");
            if (asistenciasElement == null)
            {
                asistenciasElement = new XElement("asistencias");
                doc.Root.Add(asistenciasElement);
            }

            foreach (var asistencia in listaAsistencia)
            {
                XElement asistenciaElement = asistenciasElement.Elements("asistencia")
                    .FirstOrDefault(a =>
                        (int)a.Element("codigo_carrera") == asistencia.IdCarrera &&
                        (int)a.Element("codigo_materia") == asistencia.IdMateria &&
                        (int)a.Element("codigo_alumno") == asistencia.IdAlumno &&
                        (string)a.Element("fecha") == asistencia.Fecha.ToString("MM/dd/yyyy"));


                asistenciaElement.SetElementValue("asistencia", asistencia.Asistencia);



            }

            doc.Save(xmlFilePath);
        }

        public List<BEAsistencia> AsistenciaHoy()
        {
            try
            {
                DateTime fechaHoy = DateTime.Today;
                XDocument doc = CargarXml();

                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement == null)
                {
                    asistenciasElement = new XElement("asistencias");
                    doc.Root.Add(asistenciasElement);
                }

                string formatoFecha = "MM/dd/yyyy";

                var asistenciasDeHoy = asistenciasElement.Elements("asistencia")
            .Where(a =>
            {
                DateTime fecha;
                return DateTime.TryParseExact(a.Element("fecha").Value, formatoFecha,
                                               System.Globalization.CultureInfo.InvariantCulture,
                                               System.Globalization.DateTimeStyles.None,
                                               out fecha) && fecha == fechaHoy;
            })
        .Select(a => new BEAsistencia
        {
            Id = int.Parse(a.Attribute("codigo").Value),
            IdCarrera = int.Parse(a.Element("codigo_carrera").Value),
            IdMateria = int.Parse(a.Element("codigo_materia").Value),
            IdAlumno = int.Parse(a.Element("codigo_alumno").Value),
            Fecha = DateTime.ParseExact(a.Element("fecha").Value, formatoFecha,
                                            System.Globalization.CultureInfo.InvariantCulture),
            Asistencia = bool.Parse(a.Element("asistencia").Value)
        })
        .ToList();

                return asistenciasDeHoy;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BEAsistencia> AsistenciaUltimaSemana()
        {
            try
            {
                DateTime fechaHoy = DateTime.Today;
                DateTime fechaSemana = fechaHoy.AddDays(-7);
                XDocument doc = CargarXml();

                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement == null)
                {
                    asistenciasElement = new XElement("asistencias");
                    doc.Root.Add(asistenciasElement);
                }
                string formatoFecha = "MM/dd/yyyy";
                var asistenciasUltimaSemana = asistenciasElement.Elements("asistencia")
            .Where(a =>
            {
                DateTime fecha;
                bool fechaValida = DateTime.TryParseExact(a.Element("fecha").Value, formatoFecha,
                                                           System.Globalization.CultureInfo.InvariantCulture,
                                                           System.Globalization.DateTimeStyles.None,
                                                           out fecha);
                return fechaValida && fecha >= fechaSemana && fecha <= fechaHoy;
            })
            .Select(a => new BEAsistencia
            {
                Id = int.Parse(a.Attribute("codigo").Value),
                IdCarrera = int.Parse(a.Element("codigo_carrera").Value),
                IdMateria = int.Parse(a.Element("codigo_materia").Value),
                IdAlumno = int.Parse(a.Element("codigo_alumno").Value),
                Fecha = DateTime.ParseExact(a.Element("fecha").Value, formatoFecha,
                                            System.Globalization.CultureInfo.InvariantCulture),
                Asistencia = bool.Parse(a.Element("asistencia").Value)
            })
            .ToList();

                return asistenciasUltimaSemana;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BEAsistencia> AsistenciaUltimoMes()
        {
            try
            {
                DateTime fechaHoy = DateTime.Today;
                DateTime fechaMes = fechaHoy.AddDays(-30);
                XDocument doc = CargarXml();

                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement == null)
                {
                    asistenciasElement = new XElement("asistencias");
                    doc.Root.Add(asistenciasElement);
                }

                string formatoFecha = "MM/dd/yyyy";
                var asistenciasUltimoMes = asistenciasElement.Elements("asistencia")
            .Where(a =>
            {
                DateTime fecha;
                bool fechaValida = DateTime.TryParseExact(a.Element("fecha").Value, formatoFecha,
                                                           System.Globalization.CultureInfo.InvariantCulture,
                                                           System.Globalization.DateTimeStyles.None,
                                                           out fecha);
                return fechaValida && fecha >= fechaMes && fecha <= fechaHoy;
            })
            .Select(a => new BEAsistencia
            {
                Id = int.Parse(a.Attribute("codigo").Value),
                IdCarrera = int.Parse(a.Element("codigo_carrera").Value),
                IdMateria = int.Parse(a.Element("codigo_materia").Value),
                IdAlumno = int.Parse(a.Element("codigo_alumno").Value),
                Fecha = DateTime.ParseExact(a.Element("fecha").Value, formatoFecha,
                                            System.Globalization.CultureInfo.InvariantCulture),
                Asistencia = bool.Parse(a.Element("asistencia").Value)
            })
            .ToList();

                return asistenciasUltimoMes;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BEAsistencia> AsistenciaIntervalo(DateTime desde, DateTime hasta)
        {
            try
            {
                DateTime fechaDesde = desde;
                DateTime fechaHasta = hasta;
                XDocument doc = CargarXml();

                XElement asistenciasElement = doc.Root.Element("asistencias");
                if (asistenciasElement == null)
                {
                    asistenciasElement = new XElement("asistencias");
                    doc.Root.Add(asistenciasElement);
                }

                string formatoFecha = "MM/dd/yyyy";
                var asistenciasIntervalo = asistenciasElement.Elements("asistencia")
            .Where(a =>
            {
                DateTime fecha;
                bool fechaValida = DateTime.TryParseExact(a.Element("fecha").Value, formatoFecha,
                                                           System.Globalization.CultureInfo.InvariantCulture,
                                                           System.Globalization.DateTimeStyles.None,
                                                           out fecha);
                return fechaValida && fecha >= fechaDesde && fecha <= fechaHasta;
            })
            .Select(a => new BEAsistencia
            {
                Id = int.Parse(a.Attribute("codigo").Value),
                IdCarrera = int.Parse(a.Element("codigo_carrera").Value),
                IdMateria = int.Parse(a.Element("codigo_materia").Value),
                IdAlumno = int.Parse(a.Element("codigo_alumno").Value),
                Fecha = DateTime.ParseExact(a.Element("fecha").Value, formatoFecha,
                                            System.Globalization.CultureInfo.InvariantCulture),
                Asistencia = bool.Parse(a.Element("asistencia").Value)
            })
            .ToList();

                return asistenciasIntervalo;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
