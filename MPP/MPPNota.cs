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
using static BE.BEMateria;

namespace MPP
{
    public class MPPNota
    {

        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

        public DataTable Listar(BECarrera carrera, BEMateria materia)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Codigo", typeof(int));
                dataTable.Columns.Add("Nombre", typeof(string));
                dataTable.Columns.Add("Apellido", typeof(string));
                dataTable.Columns.Add("DNI", typeof(int));
                dataTable.Columns.Add("Parcial 1", typeof(decimal));

                XDocument doc;
                doc = CargarXml();

                XElement notasElement = doc.Root.Element("notas");
                if (notasElement == null)
                {
                    notasElement = new XElement("notas");
                    doc.Root.Add(notasElement);
                }

                XElement carreraElement = doc.Descendants("carrera")
            .FirstOrDefault(c => (int)c.Attribute("codigo") == carrera.Codigo);

                if (carreraElement != null)
                {
                    XElement alumnosElement = carreraElement.Element("alumnos");
                    if (alumnosElement != null)
                    {
                        foreach (XElement alumnoElement in alumnosElement.Elements("alumno"))
                        {
                            int codigoAlumno = (int)alumnoElement.Attribute("codigo");
                            XElement alumnoInfoElement = doc.Root.Element("alumnos")
                                .Elements("alumno")
                                .FirstOrDefault(a => (int)a.Attribute("codigo") == codigoAlumno);

                            if (alumnoInfoElement != null)
                            {
                                DataRow row = dataTable.NewRow();
                                row["Codigo"] = codigoAlumno;
                                row["Nombre"] = (string)alumnoInfoElement.Element("nombre");
                                row["Apellido"] = (string)alumnoInfoElement.Element("apellido");
                                row["DNI"] = (int)alumnoInfoElement.Element("dni");

                                XElement notaElement = notasElement.Elements("nota")
                                    .FirstOrDefault(n =>
                                        (int)n.Element("codigo_carrera") == carrera.Codigo &&
                                        (int)n.Element("codigo_materia") == materia.Codigo &&
                                        (int)n.Element("codigo_alumno") == codigoAlumno);

                                if (notaElement != null)
                                {

                                    row["Parcial 1"] = (decimal)notaElement.Element("nota_parcial_1");
                                    if (!dataTable.Columns.Contains("Parcial 2"))
                                    {
                                        dataTable.Columns.Add("Parcial 2", typeof(decimal));
                                    }
                                    row["Parcial 2"] = (decimal)notaElement.Element("nota_parcial_2");
                                }
                                else
                                {
                                    row["Parcial 1"] = DBNull.Value;
                                }

                                dataTable.Rows.Add(row);
                            }
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("La carrera no se encontró.");
                }

                return dataTable;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<BENota> ListarNotas()
        {
            List<BENota> listaNotas = new List<BENota>();
            XDocument doc;
            doc = CargarXml();

            XElement notasElement = doc.Root.Element("notas");
            if (notasElement == null)
            {
                notasElement = new XElement("notas");
                doc.Root.Add(notasElement);
            }

            foreach(XElement notaElement in  notasElement.Elements("nota"))
            {
                BENota nota = new BENota
                {
                    Id = int.Parse(notaElement.Attribute("codigo").Value),
                    CodigoCarrera = int.Parse(notaElement.Element("codigo_carrera").Value),
                    CodigoMateria = int.Parse(notaElement.Element("codigo_materia").Value),
                    CodigoAlumno = int.Parse(notaElement.Element("codigo_alumno").Value),
                    NotaParcial1 = decimal.Parse(notaElement.Element("nota_parcial_1").Value),
                    NotaParcial2 = decimal.Parse(notaElement.Element("nota_parcial_2").Value)
                };

                listaNotas.Add(nota);
            }
            return listaNotas;
        }

        public bool GuardarNotas(List<BENota> listaNotas)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                XElement notasElement = doc.Root.Element("notas");
                if (notasElement == null)
                {
                    notasElement = new XElement("notas");
                    doc.Root.Add(notasElement);
                }

                foreach (BENota beNota in listaNotas)
                {
                    XElement notaElement = notasElement.Elements("nota")
                        .FirstOrDefault(n =>
                    (int)n.Element("codigo_carrera") == beNota.CodigoCarrera &&
                    (int)n.Element("codigo_materia") == beNota.CodigoMateria &&
                    (int)n.Element("codigo_alumno") == beNota.CodigoAlumno);

                    if (notaElement != null)
                    {
                        notaElement.Element("nota_parcial_1").Value = beNota.NotaParcial1.ToString();
                        notaElement.Element("nota_parcial_2").Value = beNota.NotaParcial2.ToString();
                    }
                    else
                    {
                        int numeroMaterias = notasElement.Elements("nota").Count();

                        int nuevoCodigo;
                        if (numeroMaterias == 0)
                        {
                            nuevoCodigo = 1;
                        }
                        else
                        {
                            nuevoCodigo = notasElement.Elements("nota")
                                .Max(u => (int)u.Attribute("codigo")) + 1;
                        }

                        notaElement = new XElement("nota",
                    new XAttribute("codigo", nuevoCodigo),
                    new XElement("codigo_carrera", beNota.CodigoCarrera),
                    new XElement("codigo_materia", beNota.CodigoMateria),
                    new XElement("codigo_alumno", beNota.CodigoAlumno),
                    new XElement("nota_parcial_1", beNota.NotaParcial1),
                    new XElement("nota_parcial_2", beNota.NotaParcial2)
                );
                        notasElement.Add(notaElement);
                        numeroMaterias++;
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
