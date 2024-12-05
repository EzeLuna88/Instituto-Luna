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
    public class MPPMatricula
    {
        readonly string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

        public void GuardarPrecio(BEMatricula matricula)
        {
            XDocument doc;
            doc = CargarXml();

            XElement matriculaElement = doc.Root.Element("matricula");
            if (matriculaElement == null)
            {
                matriculaElement = new XElement("matricula");
                doc.Root.Add(matriculaElement);
            }

            XElement precioElement = matriculaElement.Element("precio");
            if (precioElement == null)
            {
                precioElement = new XElement("precio", matricula.Precio);
                matriculaElement.Add(precioElement);
            }
            else
            {
                precioElement.Value = matricula.Precio.ToString();
            }

            doc.Save(xmlFilePath);

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

        public decimal DevolverPrecio()
        {
            decimal precio = 0;
            XDocument doc = CargarXml();

            XElement matriculaElement = doc.Root.Element("matricula");
            if (matriculaElement == null)
            {
                matriculaElement = new XElement("matricula");
                doc.Root.Add(matriculaElement);
            }

            XElement precioElement = matriculaElement.Element("precio");
            if (precioElement == null)
            {
                precioElement = new XElement("precio",precio.ToString());
                matriculaElement.Add(precioElement);
            }
            else
            {
                precio = Convert.ToDecimal(precioElement.Value);
            }
            doc.Save(xmlFilePath);



            return precio;
        }
    }
}
