using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Security;

namespace MPP
{
    public class MPPBackup
    {
        readonly string xmlBitacoraFilePath = ConfigurationManager.AppSettings["XmlBitacoraFilePath"];
        readonly string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];


        public List<BEBackup> ListarBitacora()
        {
            XDocument docBitacora;
            XDocument docXml;
            List<BEBackup> listaBackups = new List<BEBackup>();
            docBitacora = CargarXmlBitacora();

            XElement backupsElement = docBitacora.Root.Element("backups");
            if (backupsElement == null)
            {
                backupsElement = new XElement("backups");
                docBitacora.Root.Add(backupsElement);
            }

            docXml = CargarXml();

            XElement usuariosElement = docXml.Root.Element("usuarios");
            if (usuariosElement == null)
            {
                usuariosElement = new XElement("usuarios");
                docXml.Root.Add(usuariosElement);
            }


            if (backupsElement != null)
            {
                foreach (XElement backupElement in backupsElement.Elements("backup"))
                {
                    string dniUsuario = backupElement.Element("usuario").Value;
                    XElement usuarioElement = usuariosElement.Elements("usuario")
                        .FirstOrDefault(u => (string)u.Attribute("dni") == dniUsuario);

                    BEUsuario usuario = null;
                    if (usuarioElement != null)
                    {
                        usuario = new BEUsuario
                        {
                            Dni = int.Parse(usuarioElement.Attribute("dni").Value),
                            NombreDeUsuario = Encriptar.Desencriptacion(usuarioElement.Element("nombre_de_usuario").Value),
                            Contrasenia = usuarioElement.Element("contrasenia").Value,
                            Nombre = usuarioElement.Element("nombre").Value,
                            Apellido = usuarioElement.Element("apellido").Value,
                            //CodigoRol = int.Parse(usuarioElement.Element("codigo_rol").Value)
                        };
                    }

                    BEBackup backup = new BEBackup
                    {
                        Codigo = int.Parse(backupElement.Attribute("codigo").Value),
                        Fecha = backupElement.Element("fecha").Value,
                        Hora = backupElement.Element("hora").Value,
                        NombreArchivo = backupElement.Element("nombre_del_archivo").Value,
                        Tipo = backupElement.Element("tipo").Value,
                        Usuario = usuario
                    };

                    listaBackups.Add(backup);
                }
            }

            return listaBackups;
        }

        private XDocument CargarXml()
        {
            XDocument docXml;
            if (File.Exists(xmlFilePath))
            {
                docXml = XDocument.Load(xmlFilePath);
            }
            else
            {
                docXml = new XDocument(new XElement("sistema"));
            }

            return docXml;
        }

        private XDocument CargarXmlBitacora()
        {
            XDocument docBitacora;
            if (File.Exists(xmlBitacoraFilePath))
            {
                docBitacora = XDocument.Load(xmlBitacoraFilePath);
            }
            else
            {
                docBitacora = new XDocument(new XElement("sistema"));
            }

            return docBitacora;
        }

        public bool GuardarRegistroBackup(BEBackup backup)
        {
            try
            {
                XDocument doc;

                doc = CargarXmlBitacora();


                XElement backupsElement = doc.Root.Element("backups");
                if (backupsElement == null)
                {
                    backupsElement = new XElement("backups");
                    doc.Root.Add(backupsElement);
                }

                int nuevoCodigo = 1;
                if (backupsElement.Elements("backup").Any())
                {
                    nuevoCodigo = backupsElement.Elements("backup")
                        .Max(u => (int)u.Attribute("codigo")) + 1;
                }
                backup.Codigo = nuevoCodigo;

                XElement backupElement = new XElement("backup",
                    new XAttribute("codigo", backup.Codigo),
                    new XElement("fecha", backup.Fecha),
                    new XElement("hora", backup.Hora),
                    new XElement("usuario", backup.Usuario.Dni),
                    new XElement("nombre_del_archivo", backup.NombreArchivo),
                    new XElement("tipo", backup.Tipo)
                );

                backupsElement.Add(backupElement);
                doc.Save(xmlBitacoraFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el registro de backup: " + ex.Message);
                return false;
            }
        }

    }
}
