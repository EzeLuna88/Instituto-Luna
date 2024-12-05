using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MPP
{
    public class MPPComprobante
    {
        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

        public bool GuardarComprobante(BEComprobante beComprobante)
        {
            try
            {
                XDocument doc;

                doc = CargarXml();

                XElement comprobantesElement = doc.Root.Element("comprobantes");
                if (comprobantesElement == null)
                {
                    comprobantesElement = new XElement("comprobantes");
                    doc.Root.Add(comprobantesElement);
                }

                comprobantesElement.Add(new XElement("comprobante",
                    new XAttribute("numero", beComprobante.Numero.ToString().Trim()),
                    new XElement("fecha", beComprobante.Fecha.ToString("dd/MM/yyyy").Trim()),
                    new XElement("total", beComprobante.Total.ToString().Trim()),
                    new XElement("descripcion", beComprobante.Descripcion.Trim()),
                    new XElement("codigo_alumno", beComprobante.CodigoAlumno.ToString().Trim())
                    ));

                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int SiguienteNumero()
        {
            XDocument doc;

            doc = CargarXml();

            XElement comprobantesElement = doc.Root.Element("comprobantes");
            if (comprobantesElement == null)
            {
                comprobantesElement = new XElement("comprobantes");
                doc.Root.Add(comprobantesElement);
            }
            int numeroComprobante = 0;
            int nuevoNumero = 1;
            if (comprobantesElement.Elements("comprobante").Any())
            {
                nuevoNumero = comprobantesElement.Elements("comprobante")
                    .Max(u => (int)u.Attribute("numero")) + 1;
            }
            else
            { nuevoNumero = 1; }
            numeroComprobante = nuevoNumero;


            return numeroComprobante;
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

        public List<BEComprobante> listaComprobantes(DateTime inicio, DateTime final)
        {
            XDocument doc;

            doc = CargarXml();
            XElement comprobantesElement = doc.Root.Element("comprobantes");
            if (comprobantesElement == null)
            {
                comprobantesElement = new XElement("comprobantes");
                doc.Root.Add(comprobantesElement);
            }

            var comprobantes = comprobantesElement.Elements("comprobante")
        .Select(x => new BEComprobante
        {
            Numero = int.Parse(x.Attribute("numero").Value),
            Fecha = DateTime.ParseExact(x.Element("fecha").Value, "dd/MM/yyyy", null),
            Total = decimal.Parse(x.Element("total").Value),
            Descripcion = x.Element("descripcion").Value,
            CodigoAlumno = int.Parse(x.Element("codigo_alumno").Value)
        })
        .Where(c => c.Fecha.Date >= inicio.Date && c.Fecha.Date <= final.Date)
        .ToList();

            return comprobantes;

        }
    }
}
