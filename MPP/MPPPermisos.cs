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
    public class MPPPermisos : MPPComponente
    {
        readonly string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

        public override void AgregarHijo(BEComponente rol, BEComponente permiso)
        {
            throw new NotImplementedException();
        }

        public override IList<BEComponente> CargarPermisos()
        {
            XDocument doc;
            if (File.Exists(xmlFilePath))
            {
                doc = XDocument.Load(xmlFilePath);
                XElement permisosElement = doc.Root.Element("permisos");
                if (permisosElement == null)
                {

                    permisosElement = new XElement("permisos");
                    doc.Root.Add(permisosElement);

                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 1),
                        new XElement("nombre", "Reportes")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 2),
                        new XElement("nombre", "Carreras")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 3),
                        new XElement("nombre", "Materias")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 4),
                        new XElement("nombre", "Alumnos")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 5),
                        new XElement("nombre", "Profesores")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 6),
                        new XElement("nombre", "Informe de asistencia")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 7),
                        new XElement("nombre", "Control de asistencia")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 8),
                        new XElement("nombre", "Notas")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 9),
                        new XElement("nombre", "Matricula")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 10),
                        new XElement("nombre", "Realizar backup")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 11),
                        new XElement("nombre", "Realizar restore")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 12),
                        new XElement("nombre", "Bitacora")));
                    permisosElement.Add(new XElement("permiso",
                        new XAttribute("codigo", 13),
                        new XElement("nombre", "Dashboard")));

                    doc.Save(xmlFilePath);

                }
            }
            else
            {
                doc = new XDocument(
            new XElement("sistema",
                new XElement("permisos",
                    new XElement("permiso",
                        new XAttribute("codigo", 1),
                        new XElement("nombre", "informes")),
                    new XElement("permiso",
                        new XAttribute("codigo", 2),
                        new XElement("nombre", "abm carrera")),
                    new XElement("permiso",
                        new XAttribute("codigo", 3),
                        new XElement("nombre", "abm materia")),
                    new XElement("permiso",
                        new XAttribute("codigo", 4),
                        new XElement("nombre", "abm alumno")),
                    new XElement("permiso",
                        new XAttribute("codigo", 5),
                        new XElement("nombre", "abm profesor")),
                    new XElement("permiso",
                        new XAttribute("codigo", 6),
                        new XElement("nombre", "informe de asistencia")),
                    new XElement("permiso",
                        new XAttribute("codigo", 7),
                        new XElement("nombre", "control de asistencia")),
                    new XElement("permiso",
                        new XAttribute("codigo", 8),
                        new XElement("nombre", "notas")),
                    new XElement("permiso",
                        new XAttribute("codigo", 9),
                        new XElement("nombre", "cobrar matricula")))));

                doc.Save(xmlFilePath);

            }

            var consulta = from Permisos in XElement.Load(xmlFilePath).Element("permisos").Elements("permiso")
                           select new BEPermiso(Permisos.Element("nombre").Value.Trim(), int.Parse(Permisos.Attribute("codigo").Value.Trim()));

            return consulta.ToList<BEComponente>();
        }

        public override IList<BEComponente> CargarRoles()
        {
            throw new NotImplementedException();
        }

        public List<string> TraerPermisosPorUsuario(int id)
        {
            List<String> listaPermisos = new List<string>();

            XDocument doc = XDocument.Load(xmlFilePath);
            XElement usuariosPermisosElement = doc.Root.Element("usuarios_permisos");
            XElement permisosElement = doc.Root.Element("permisos");
            XElement padresHijosElement = doc.Root.Element("padres_hijos");
            XElement rolesElement = doc.Root.Element("roles");


            if (usuariosPermisosElement != null && permisosElement != null && padresHijosElement != null && rolesElement != null)
            {

                var permisosDirectos = usuariosPermisosElement.Elements("usuario_permiso")
                    .Where(up => (int)up.Element("usuario_id") == id)
                    .Select(up => (int)up.Element("permiso_id"));

                foreach (int permisoId in permisosDirectos)
                {
                    XElement permisoElement = permisosElement.Elements("permiso")
                        .FirstOrDefault(p => (int)p.Attribute("codigo") == permisoId);

                    if (permisoElement != null)
                    {
                        string nombrePermiso = permisoElement.Element("nombre").Value;
                        listaPermisos.Add(nombrePermiso);
                    }
                }

                var rolesAsignados = doc.Root.Element("usuarios_roles")
                    .Elements("usuario_rol")
                    .Where(ur => (int)ur.Element("usuario_id") == id)
                    .Select(ur => (int)ur.Element("rol_id"));

                foreach (int rolId in rolesAsignados)
                {

                    var permisosRolDirectos = padresHijosElement.Elements("padre_hijo")
                        .Where(ph => (int)ph.Element("padre_id") == rolId && (string)ph.Element("hijo_tipo") == "2")
                        .Select(ph => (int)ph.Element("hijo_id"));

                    foreach (int permisoId in permisosRolDirectos)
                    {
                        XElement permisoElement = permisosElement.Elements("permiso")
                            .FirstOrDefault(p => (int)p.Attribute("codigo") == permisoId);

                        if (permisoElement != null)
                        {
                            string nombrePermiso = permisoElement.Element("nombre").Value;
                            listaPermisos.Add(nombrePermiso);
                        }
                    }


                    var rolesDentroDeRol = padresHijosElement.Elements("padre_hijo")
                        .Where(ph => (int)ph.Element("padre_id") == rolId && (string)ph.Element("hijo_tipo") == "1")
                        .Select(ph => (int)ph.Element("hijo_id"));

                    foreach (int rolHijoId in rolesDentroDeRol)
                    {

                        XElement rolElement = rolesElement.Elements("rol")
                            .FirstOrDefault(r => (int)r.Attribute("codigo") == rolHijoId);

                        if (rolElement != null)
                        {
                            string nombreRolHijo = rolElement.Element("nombre").Value;
                            listaPermisos.Add(nombreRolHijo);


                            var permisosRolHijoDirectos = padresHijosElement.Elements("padre_hijo")
                                .Where(ph => (int)ph.Element("padre_id") == rolHijoId && (string)ph.Element("hijo_tipo") == "2")
                                .Select(ph => (int)ph.Element("hijo_id"));

                            foreach (int permisoId in permisosRolHijoDirectos)
                            {
                                XElement permisoElement = permisosElement.Elements("permiso")
                                    .FirstOrDefault(p => (int)p.Attribute("codigo") == permisoId);

                                if (permisoElement != null)
                                {
                                    string nombrePermiso = permisoElement.Element("nombre").Value;
                                    listaPermisos.Add(nombrePermiso);
                                }
                            }
                        }
                    }
                }
            }

            return listaPermisos;
        }
    }
}
