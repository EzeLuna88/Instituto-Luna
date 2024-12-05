using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Xml;
using System.Collections;
using System.Configuration;

namespace MPP
{
    public class MPPRoles : MPPComponente
    {

        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

        public override void AgregarHijo(BEComponente padre, BEComponente hijo)
        {

            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement padresHijosElement = doc.Root.Element("padres_hijos");

                if (padresHijosElement == null)
                {
                    padresHijosElement = new XElement("padres_hijos");
                    doc.Root.Add(padresHijosElement);
                }

                int hijoTipo = hijo is BERoles ? 1 : 2;

                bool existeAsociacion = padresHijosElement.Elements("padre_hijo")
                    .Any(ur => (int)ur.Element("padre_id") == padre.Codigo &&
                               (int)ur.Element("hijo_id") == hijo.Codigo &&
                               (int)ur.Element("hijo_tipo") == hijoTipo);

                if (!existeAsociacion)
                {

                    int nuevoId = padresHijosElement.Elements("padre_hijo").Count() + 1;
                    padresHijosElement.Add(new XElement("padre_hijo",
                        new XAttribute("id", nuevoId),
                        new XElement("padre_id", padre.Codigo),
                        new XElement("hijo_id", hijo.Codigo),
                        new XElement("hijo_tipo", (hijo is BERoles ? "1" : "2"))

                    ));
                    doc.Save(xmlFilePath);
                     
                }
                else
                {
                    throw new InvalidOperationException("El hijo ya está asignado al padre.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el padre/hijo: {ex.Message}");
            }

        }

        public override IList<BEComponente> CargarPermisos()
        {
            throw new NotImplementedException();
        }

        public override IList<BEComponente> CargarRoles()
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
            XElement rolesElement = doc.Root.Element("roles");

            if (rolesElement == null)
            {
                rolesElement = new XElement("roles");
                doc.Root.Add(rolesElement);
                doc.Save(xmlFilePath);
                List<BEComponente> roles = new List<BEComponente>();
                return roles;
            }
            else
            {
                var permisosDiccionario = doc.Root.Element("permisos")?.Elements("permiso")
        .ToDictionary(
            p => (int)p.Attribute("codigo"),
            p => p.Element("nombre").Value.Trim()) ?? new Dictionary<int, string>();


                if (rolesElement == null)
                {
                    throw new InvalidOperationException("La estructura de roles no existe en el XML.");
                }


                var consulta = from Roles in rolesElement.Elements("rol")
                               select new BERoles(Roles.Element("nombre").Value.Trim(),
                                   int.Parse(Roles.Attribute("codigo").Value.Trim()))
                               {
                                   Permisos = Roles.Element("permisos") != null
                                       ? Roles.Element("permisos").Elements("codigo_permiso")
                                           .Select(p =>
                                           {
                                               int codigoPermiso = Convert.ToInt32(p.Value.Trim());
                                               string nombrePermiso = permisosDiccionario.ContainsKey(codigoPermiso)
                                                   ? permisosDiccionario[codigoPermiso]
                                                   : "permiso desconocido";

                                               return new BEPermiso(nombrePermiso, codigoPermiso);
                                           })
                                           .Cast<BEComponente>().ToList()
                                       : new List<BEComponente>()
                               };

                return consulta.ToList<BEComponente>();
            }
        }

        public void EliminarHijo(BEComponente padre, BEComponente hijo, int hijoTipo)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement padresHijosElement = doc.Root.Element("padres_hijos");

                if (padresHijosElement != null)
                {
                    if (hijoTipo == 2)
                    {
                        XElement asociacionElement = padresHijosElement.Elements("padre_hijo")
                            .FirstOrDefault(ur => (int)ur.Element("padre_id") == padre.Codigo &&
                                                  (int)ur.Element("hijo_id") == hijo.Codigo &&
                                                  (int)ur.Element("hijo_tipo") == 2);

                        if (asociacionElement != null)
                        {
                            asociacionElement.Remove();
                            doc.Save(xmlFilePath);
                        }
                        else
                        {
                            throw new Exception("La asociación entre el padre y el hijo no existe.");
                        }
                    }
                    else if (hijoTipo == 1)
                    {
                        XElement asociacionElement = padresHijosElement.Elements("padre_hijo")
                            .FirstOrDefault(ur => (int)ur.Element("padre_id") == padre.Codigo &&
                                                  (int)ur.Element("hijo_id") == hijo.Codigo &&
                                                  (int)ur.Element("hijo_tipo") == 1);

                        if (asociacionElement != null)
                        {
                            asociacionElement.Remove();
                            doc.Save(xmlFilePath);
                        }
                        else
                        {
                            throw new Exception("La asociación entre el padre y el hijo no existe.");
                        }
                    }
                }
                else
                {
                    throw new Exception("No se encontró el elemento roles_permisos en el archivo XML.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el hijo: {ex.Message}");
            }


        }

        public BERoles DevolverRol(int codigo)
        {


            XDocument doc;
            doc = XDocument.Load(xmlFilePath);
            var rolElement = doc.Root.Element("roles").Elements("rol")
           .FirstOrDefault(r => (int)r.Attribute("codigo") == codigo);

            var permisosDiccionario = doc.Root.Element("permisos").Elements("permiso")
        .ToDictionary(
            p => (int)p.Attribute("codigo"),
            p => p.Element("nombre").Value.Trim());

            BERoles rol = new BERoles(
        rolElement.Element("nombre").Value.Trim(),
        int.Parse(rolElement.Attribute("codigo").Value.Trim())
            );

            var permisos = rolElement.Element("permisos") != null
                ? rolElement.Element("permisos").Elements("codigo_permiso")
                    .Select(p =>
                    {
                        int codigoPermiso = Convert.ToInt32(p.Value.Trim());
                        string nombrePermiso = permisosDiccionario.ContainsKey(codigoPermiso)
                            ? permisosDiccionario[codigoPermiso]
                            : "permiso desconocido";

                        return new BEPermiso(nombrePermiso, codigoPermiso);
                    })
                    .Cast<BEComponente>()
                    .ToList()
                : new List<BEComponente>();

            rol.Permisos = permisos;

            return rol;
        }

        public bool AgregarRol(BERoles beRoles)
        {
            XDocument doc;
            XElement rolesElement;

            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);
                rolesElement = doc.Root.Element("roles");

                if (rolesElement == null)
                {
                    rolesElement = new XElement("roles");
                    doc.Root.Add(rolesElement);
                }
            }
            else
            {
                doc = new XDocument(
                    new XElement("sistema",
                        new XElement("roles")
                    )
                );
                rolesElement = doc.Root.Element("roles");
            }

            int codigoRoles = 0;
            if (rolesElement != null && rolesElement.Elements("rol").Any())
            {
                codigoRoles = rolesElement.Elements("rol")
                    .Max(x => (int)x.Attribute("codigo"));
            }

            XElement nuevoRol = new XElement("rol",
        new XAttribute("codigo", codigoRoles + 1),
        new XElement("nombre", beRoles.Nombre)
    );

            rolesElement.Add(nuevoRol);

            doc.Save(xmlFilePath);

            return true;
        }

        public bool EliminarRol(BERoles beRoles)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement rolesElement = doc.Root.Element("roles");

                if (rolesElement != null)
                {
                    XElement rolElement = rolesElement.Elements("rol")
                        .FirstOrDefault(u => (string)u.Attribute("codigo") == beRoles.Codigo.ToString());

                    if (rolesElement != null)
                    {
                        rolElement.Remove();

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
    }
}
