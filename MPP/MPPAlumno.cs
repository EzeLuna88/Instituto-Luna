using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Data;
using Abstraccion;
using System.Collections;
using System.Configuration;
using System.Xml.Linq;
using System.IO;

namespace MPP
{
    public class MPPAlumno
    {
        readonly string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

        public bool Guardar(BEAlumno bEAlumno)
        {
            XDocument doc;
            doc = CargarXml();

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement == null)
            {
                alumnosElement = new XElement("alumnos");
                doc.Root.Add(alumnosElement);
            }

            if (bEAlumno.Codigo > 0)
            {
                XElement alumnoActualizar = alumnosElement.Elements("alumno")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == bEAlumno.Codigo);
                if (alumnoActualizar != null)
                {
                    alumnoActualizar.Element("dni").Value = bEAlumno.Dni.ToString().Trim();
                    alumnoActualizar.Element("nombre").Value = bEAlumno.Nombre.ToString().Trim();
                    alumnoActualizar.Element("apellido").Value = bEAlumno.Apellido.ToString().Trim();
                    alumnoActualizar.Element("fecha_de_nacimiento").Value = bEAlumno.FechaDeNacimiento.ToString().Trim();
                    alumnoActualizar.Element("email").Value = bEAlumno.Email.ToString().Trim();
                    alumnoActualizar.Element("telefono").Value = bEAlumno.Telefono.ToString().Trim();
                    alumnoActualizar.Element("direccion").Value = bEAlumno.Direccion.ToString().Trim();
                    alumnoActualizar.Element("matricula_pagada").Value = bEAlumno.MatriculaPagada.ToString().Trim();
                    alumnoActualizar.Element("becado").Value = bEAlumno.Becado.ToString().Trim();
                    doc.Save(xmlFilePath);
                    return true;
                }
            }

            XElement alumnoElement = alumnosElement.Elements("alumno")
            .FirstOrDefault(u => (string)u.Element("dni") == bEAlumno.Dni.ToString().Trim());
            if (alumnoElement != null)
            {
                throw new InvalidOperationException("El DNI ya se encuentra registrado.");
            }
            else
            {
                int numeroAlumnos = alumnosElement.Elements("alumno").Count();
                if (numeroAlumnos == 0)
                {

                    alumnosElement.Add(new XElement("alumno",
                    new XAttribute("codigo", 1),

                new XElement("dni", bEAlumno.Dni.ToString().Trim()),
                new XElement("nombre", bEAlumno.Nombre.ToString().Trim()),
                new XElement("apellido", bEAlumno.Apellido.ToString().Trim()),
                new XElement("fecha_de_nacimiento", bEAlumno.FechaDeNacimiento.ToString().Trim()),
                new XElement("direccion", bEAlumno.Direccion.ToString().Trim()),
                new XElement("telefono", bEAlumno.Telefono.ToString().Trim()),
                new XElement("email", bEAlumno.Email.ToString().Trim()),
                new XElement("becado", bEAlumno.Becado.ToString().Trim()),
                new XElement("matricula_pagada", bEAlumno.MatriculaPagada.ToString().Trim())


                ));


                }
                else
                {
                    int nuevoCodigo = 1;
                    if (alumnosElement.Elements("alumno").Any())
                    {
                        nuevoCodigo = alumnosElement.Elements("alumno")
                            .Max(u => (int)u.Attribute("codigo")) + 1;
                    }
                    bEAlumno.Codigo = nuevoCodigo;
                    alumnosElement.Add(new XElement("alumno",
                    new XAttribute("codigo", bEAlumno.Codigo.ToString().Trim()),
                new XElement("dni", bEAlumno.Dni.ToString().Trim()),
                new XElement("nombre", bEAlumno.Nombre.ToString().Trim()),
                new XElement("apellido", bEAlumno.Apellido.ToString().Trim()),
                new XElement("fecha_de_nacimiento", bEAlumno.FechaDeNacimiento.ToString().Trim()),
                new XElement("direccion", bEAlumno.Direccion.ToString().Trim()),
                new XElement("telefono", bEAlumno.Telefono.ToString().Trim()),
                new XElement("email", bEAlumno.Email.ToString().Trim()),
                new XElement("becado", bEAlumno.Becado.ToString().Trim()),
                new XElement("matricula_pagada", bEAlumno.MatriculaPagada.ToString().Trim())
                ));
                }

            }

            doc.Save(xmlFilePath);
            return true;



        }



        public List<BEAlumno> listarTodo()
        {
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();

            if (File.Exists(xmlFilePath))
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement alumnosElement = doc.Root.Element("alumnos");

                if (alumnosElement != null)
                {
                    foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                    {
                        string valorBecado = alumnoElement.Element("becado").Value;
                        bool esBecado = !string.IsNullOrEmpty(valorBecado) && valorBecado.ToLower().Equals("true");

                        string matriculaPagada = alumnoElement.Element("matricula_pagada").Value;
                        bool matricula = !string.IsNullOrEmpty(matriculaPagada) && matriculaPagada.ToLower().Equals("true");

                        BEAlumno bEAlumno = new BEAlumno
                        {
                            Codigo = int.Parse(alumnoElement.Attribute("codigo").Value),
                            Dni = int.Parse(alumnoElement.Element("dni").Value),
                            Nombre = alumnoElement.Element("nombre").Value,
                            Apellido = alumnoElement.Element("apellido").Value,
                            FechaDeNacimiento = DateTime.Parse(alumnoElement.Element("fecha_de_nacimiento").Value),
                            Direccion = alumnoElement.Element("direccion").Value,
                            Telefono = alumnoElement.Element("telefono").Value,
                            Email = alumnoElement.Element("email").Value,
                            Becado = esBecado,
                            MatriculaPagada = matricula
                        };


                        listaAlumnos.Add(bEAlumno);





                    }
                }
            }

            return listaAlumnos.Count > 0 ? listaAlumnos : null;

        }

        public bool Baja(BEAlumno alumno)
        {
            try
            {

                XDocument doc = XDocument.Load(xmlFilePath);
                XElement alumnosElement = doc.Root.Element("alumnos");
                XElement asistenciasElement = doc.Root.Element("asistencias");
                XElement notasElement = doc.Root.Element("notas");
                XElement carrerasElement = doc.Root.Element("carreras");

                bool estaAsociado = false;

                if (carrerasElement != null)
                {
                    estaAsociado = carrerasElement.Elements("carrera")
                        .Any(carrera => carrera.Element("alumnos")
                            .Elements("alumno")
                            .Any(a => (string)a.Attribute("codigo") == alumno.Codigo.ToString()));
                }

                if (estaAsociado)
                {
                    return false;
                }

                if (alumnosElement != null)
                {
                    XElement alumnoElement = alumnosElement.Elements("alumno")
                        .FirstOrDefault(u => (string)u.Attribute("codigo") == alumno.Codigo.ToString());

                    if (alumnoElement != null)
                    {
                        alumnoElement.Remove();

                    }
                    doc.Save(xmlFilePath);
                }
                return true;


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int TotalAlumnos()
        {
            int totalAlumnos = 0;
            XDocument doc;

            doc = CargarXml();

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement == null)
            {
                alumnosElement = new XElement("alumnos");
                doc.Root.Add(alumnosElement);
            }
            totalAlumnos = alumnosElement.Elements("alumno").Count();

            return totalAlumnos;

        }


        public DataTable TotalesMatricula()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Pagada", typeof(int));
            dt.Columns.Add("No Pagada", typeof(int));

            XDocument doc;
            doc = CargarXml();

            int matriculaPagadaCount = 0;
            int matriculaNoPagadaCount = 0;

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    bool matriculaPagada = (bool)alumnoElement.Element("matricula_pagada");
                    if (matriculaPagada)
                    {
                        matriculaPagadaCount++;
                    }
                    else
                    {
                        matriculaNoPagadaCount++;
                    }
                }
            }

            DataRow row = dt.NewRow();
            row["Pagada"] = matriculaPagadaCount;
            row["No Pagada"] = matriculaNoPagadaCount;
            dt.Rows.Add(row);

            return dt;
        }


        public DataTable TotalesBecados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Becado", typeof(int));
            dt.Columns.Add("Regular", typeof(int));

            XDocument doc;
            doc = CargarXml();

            int Becado = 0;
            int Regular = 0;

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    bool esBecado = (bool)alumnoElement.Element("becado");
                    if (esBecado)
                    {
                        Becado++;
                    }
                    else
                    {
                        Regular++;
                    }
                }
            }

            DataRow row = dt.NewRow();
            row["Becado"] = Becado;
            row["Regular"] = Regular;
            dt.Rows.Add(row);

            return dt;
        }


        public DataTable RangoEdades(BECarrera carrera)
        {
            XDocument doc;
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();
            doc = CargarXml();

            XElement carrerasElement = doc.Root.Element("carreras");
            XElement alumnosElement = doc.Root.Element("alumnos");

            if (carrera.Codigo != 0)
            {
                XElement carreraElement = carrerasElement.Elements("carrera")
                    .FirstOrDefault(c => (int)c.Attribute("codigo") == carrera.Codigo);
                if (carreraElement != null)
                {
                    XElement alumnosDeCarreraElement = carreraElement.Element("alumnos");
                    if (alumnosDeCarreraElement != null)
                    {
                        List<int> codigosAlumnos = carreraElement.Element("alumnos").Elements("alumno")
                    .Select(a => int.Parse(a.Attribute("codigo").Value))
                    .ToList();

                        foreach (int codigoAlumno in codigosAlumnos)
                        {
                            XElement alumnoElement = doc.Root.Element("alumnos").Elements("alumno")
                                .FirstOrDefault(a => (int)a.Attribute("codigo") == codigoAlumno);
                            if (alumnoElement != null)
                            {
                                string valorBecado = alumnoElement.Element("becado").Value;
                                bool esBecado = !string.IsNullOrEmpty(valorBecado) && valorBecado.ToLower().Equals("true");

                                BEAlumno bEAlumno = new BEAlumno
                                {
                                    Codigo = codigoAlumno,
                                    Dni = int.Parse(alumnoElement.Element("dni").Value),
                                    Nombre = alumnoElement.Element("nombre").Value,
                                    Apellido = alumnoElement.Element("apellido").Value,
                                    FechaDeNacimiento = DateTime.Parse(alumnoElement.Element("fecha_de_nacimiento").Value),
                                    Direccion = alumnoElement.Element("direccion").Value,
                                    Telefono = alumnoElement.Element("telefono").Value,
                                    Email = alumnoElement.Element("email").Value,
                                    Becado = esBecado
                                };

                                listaAlumnos.Add(bEAlumno);
                            }
                        }
                    }
                }
            }

            else
            {
                if (alumnosElement != null)
                {
                    foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                    {
                        string valorBecado = alumnoElement.Element("becado").Value;
                        bool esBecado = !string.IsNullOrEmpty(valorBecado) && valorBecado.ToLower().Equals("true");

                        BEAlumno bEAlumno = new BEAlumno
                        {
                            Codigo = int.Parse(alumnoElement.Attribute("codigo").Value),
                            Dni = int.Parse(alumnoElement.Element("dni").Value),
                            Nombre = alumnoElement.Element("nombre").Value,
                            Apellido = alumnoElement.Element("apellido").Value,
                            FechaDeNacimiento = DateTime.Parse(alumnoElement.Element("fecha_de_nacimiento").Value),
                            Direccion = alumnoElement.Element("direccion").Value,
                            Telefono = alumnoElement.Element("telefono").Value,
                            Email = alumnoElement.Element("email").Value,
                            Becado = esBecado
                        };


                        listaAlumnos.Add(bEAlumno);

                    }
                }
            }
            DataTable edades = new DataTable();
            edades.Columns.Add("18-30", typeof(int));
            edades.Columns.Add("31-40", typeof(int));
            edades.Columns.Add("41-50", typeof(int));
            edades.Columns.Add("51-60", typeof(int));
            edades.Columns.Add("60+", typeof(int));

            DataRow row = edades.NewRow();
            row["18-30"] = 0;
            row["31-40"] = 0;
            row["41-50"] = 0;
            row["51-60"] = 0;
            row["60+"] = 0;
            edades.Rows.Add(row);


            int edad;
            foreach (BEAlumno alumno in listaAlumnos)
            {
                edad = CalcularEdad(alumno.FechaDeNacimiento);
                if (edad > 18 && edad < 30)
                {
                    row["18-30"] = (int)row["18-30"] + 1;
                }
                else if (edad >= 31 && edad <= 40)
                {
                    row["31-40"] = (int)row["31-40"] + 1;
                }
                else if (edad >= 41 && edad <= 50)
                {
                    row["41-50"] = (int)row["41-50"] + 1;
                }
                else if (edad >= 51 && edad <= 60)
                {
                    row["51-60"] = (int)row["51-60"] + 1;
                }
                else if (edad > 60)
                {
                    row["60+"] = (int)row["60+"] + 1;
                }
            }

            return edades;

        }


        public List<BEAlumno> CargarReporteRegulares()
        {
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();
            XDocument doc;

            doc = CargarXml();

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    bool becado = (bool)alumnoElement.Element("becado");
                    if (!becado)
                    {
                        BEAlumno alumno = new BEAlumno
                        {
                            Codigo = (int)alumnoElement.Attribute("codigo"),
                            Nombre = (string)alumnoElement.Element("nombre"),
                            Apellido = (string)alumnoElement.Element("apellido"),
                            FechaDeNacimiento = DateTime.Parse((string)alumnoElement.Element("fecha_de_nacimiento")),
                            Direccion = (string)alumnoElement.Element("direccion"),
                            Telefono = (string)alumnoElement.Element("telefono"),
                            Email = (string)alumnoElement.Element("email"),
                            Dni = (int)alumnoElement.Element("dni"),
                            Becado = becado
                        };
                        listaAlumnos.Add(alumno);
                    }
                }
            }

            return listaAlumnos;




        }

        public List<BEAlumno> CargarReporteBecados()
        {
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();
            XDocument doc;

            doc = CargarXml();

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    bool becado = (bool)alumnoElement.Element("becado");
                    if (becado)
                    {
                        BEAlumno alumno = new BEAlumno
                        {
                            Codigo = (int)alumnoElement.Attribute("codigo"),
                            Nombre = (string)alumnoElement.Element("nombre"),
                            Apellido = (string)alumnoElement.Element("apellido"),
                            FechaDeNacimiento = DateTime.Parse((string)alumnoElement.Element("fecha_de_nacimiento")),
                            Direccion = (string)alumnoElement.Element("direccion"),
                            Telefono = (string)alumnoElement.Element("telefono"),
                            Email = (string)alumnoElement.Element("email"),
                            Dni = (int)alumnoElement.Element("dni"),
                            Becado = becado
                        };
                        listaAlumnos.Add(alumno);
                    }
                }
            }

            return listaAlumnos;




        }


        public List<BEAlumno> CargarMatriculasPagadas()
        {
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();
            XDocument doc;

            doc = CargarXml();

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    bool matriculaPagada = (bool)alumnoElement.Element("matricula_pagada");
                    if (matriculaPagada)
                    {
                        BEAlumno alumno = new BEAlumno
                        {
                            Codigo = (int)alumnoElement.Attribute("codigo"),
                            Nombre = (string)alumnoElement.Element("nombre"),
                            Apellido = (string)alumnoElement.Element("apellido"),
                            FechaDeNacimiento = DateTime.Parse((string)alumnoElement.Element("fecha_de_nacimiento")),
                            Direccion = (string)alumnoElement.Element("direccion"),
                            Telefono = (string)alumnoElement.Element("telefono"),
                            Email = (string)alumnoElement.Element("email"),
                            Dni = (int)alumnoElement.Element("dni")

                        };
                        listaAlumnos.Add(alumno);
                    }
                }
            }

            return listaAlumnos;
        }


        public List<BEAlumno> CargarMatriculasNoPagadas()
        {
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();
            XDocument doc;

            doc = CargarXml();

            XElement alumnosElement = doc.Root.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    bool matriculaPagada = (bool)alumnoElement.Element("matricula_pagada");
                    if (!matriculaPagada)
                    {
                        BEAlumno alumno = new BEAlumno
                        {
                            Codigo = (int)alumnoElement.Attribute("codigo"),
                            Nombre = (string)alumnoElement.Element("nombre"),
                            Apellido = (string)alumnoElement.Element("apellido"),
                            FechaDeNacimiento = DateTime.Parse((string)alumnoElement.Element("fecha_de_nacimiento")),
                            Direccion = (string)alumnoElement.Element("direccion"),
                            Telefono = (string)alumnoElement.Element("telefono"),
                            Email = (string)alumnoElement.Element("email"),
                            Dni = (int)alumnoElement.Element("dni")

                        };
                        listaAlumnos.Add(alumno);
                    }
                }
            }

            return listaAlumnos;
        }


        public List<BEAlumno> CargarAlumnosPorCarrera(BECarrera carrera)
        {
            List<BEAlumno> listaAlumnos = new List<BEAlumno>();
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

            XElement alumnosElement = carreraElement.Element("alumnos");
            if (alumnosElement != null)
            {
                foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                {
                    BEAlumno alumno = new BEAlumno();
                    alumno.Codigo = (int)alumnoElement.Attribute("codigo");
                    XElement alumnosElementNuevo = doc.Root.Element("alumnos");
                    XElement alumnoEncontrado = alumnosElementNuevo.Elements("alumno")
                                 .FirstOrDefault(m => (int)m.Attribute("codigo") == alumno.Codigo);
                    alumno.Nombre = alumnoEncontrado.Element("nombre").Value;
                    alumno.Apellido = alumnoEncontrado.Element("apellido").Value;
                    alumno.Dni = int.Parse(alumnoEncontrado.Element("dni").Value);
                    alumno.FechaDeNacimiento = DateTime.Parse(alumnoEncontrado.Element("fecha_de_nacimiento").Value);
                    alumno.Direccion = alumnoEncontrado.Element("direccion").Value;
                    alumno.Telefono = alumnoEncontrado.Element("telefono").Value;
                    alumno.Email = alumnoEncontrado.Element("email").Value;
                    listaAlumnos.Add(alumno);

                }
            }
            return listaAlumnos;

        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime ahora = DateTime.Now;
            int edad = ahora.Year - fechaNacimiento.Year;
            if (fechaNacimiento > ahora.AddYears(-edad)) edad--;
            return edad;
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
    }
}
