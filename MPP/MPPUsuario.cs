using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Net;


namespace MPP
{
    public class MPPUsuario
    {
        readonly string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];



        public BEUsuario BuscarUsuario(BEUsuario beUsuario)
        {
            XDocument doc;

            doc = CargarXml();
            XElement usuariosElement = doc.Root.Element("usuarios");
            if (usuariosElement != null)
            {
                XElement usuarioElement = usuariosElement.Elements("usuario")
                    .FirstOrDefault(u =>
                        (string)u.Element("nombre_de_usuario") == beUsuario.NombreDeUsuario &&
                        (string)u.Element("contrasenia") == beUsuario.Contrasenia);

                if (usuarioElement != null)
                {
                    BEUsuario usuarioEncontrado = new BEUsuario
                    {
                        Codigo = Convert.ToInt32(usuarioElement.Attribute("codigo").Value),
                        Dni = Convert.ToInt32(usuarioElement.Element("dni").Value),
                        NombreDeUsuario = (string)usuarioElement.Element("nombre_de_usuario"),
                        Contrasenia = (string)usuarioElement.Element("contrasenia"),
                        Nombre = (string)usuarioElement.Element("nombre"),
                        Apellido = (string)usuarioElement.Element("apellido"),
                        //CodigoRol = Convert.ToInt32(usuarioElement.Element("codigo_rol").Value)
                    };
                    return usuarioEncontrado;

                }
            }
            return null;
        }

        private XDocument CargarXml()
        {
            XDocument doc;
            try
            {
                string directoryPath = Path.GetDirectoryName(xmlFilePath);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(xmlFilePath))
                {
                    doc = XDocument.Load(xmlFilePath);

                    if (doc.Root == null || doc.Root.Name != "sistema")
                    {
                        throw new Exception("El archivo XML no tiene la estructura esperada.");
                    }
                }
                else
                {
                    doc = new XDocument(new XElement("sistema"));

                    doc.Save(xmlFilePath);
                }
            }
            catch (Exception ex)
            {
                doc = new XDocument(new XElement("sistema")); 
            }

            return doc;
        }

        public bool BorrarUsuario(BEUsuario beUsuario)
        {
            try
            {
                XDocument doc;
                XElement usuariosElement;
                XElement usuariosRolesElement;
                XElement usuariosPermisosElement;

                if (File.Exists(xmlFilePath))
                {
                    doc = XDocument.Load(xmlFilePath);
                    usuariosElement = doc.Root.Element("usuarios");
                    usuariosRolesElement = doc.Root.Element("usuarios_roles");
                    usuariosPermisosElement = doc.Root.Element("usuarios_permisos");
                }
                else
                {
                    
                    return false;
                }

                XElement usuarioElement = usuariosElement.Elements("usuario")
            .FirstOrDefault(u => (int)u.Attribute("codigo") == beUsuario.Codigo);

                if (usuarioElement != null)
                {
                    usuarioElement.Remove();
                }
                else
                {
                    
                    return false;
                }

                if (usuariosRolesElement != null)
                {
                    var rolesDelUsuario = usuariosRolesElement.Elements("usuario_rol")
                        .Where(ur => (int)ur.Element("usuario_id") == beUsuario.Codigo)
                        .ToList();

                    foreach (var rol in rolesDelUsuario)
                    {
                        rol.Remove();
                    }
                }

                if (usuariosPermisosElement != null)
                {
                    var permisosDelUsuario = usuariosPermisosElement.Elements("usuario_permiso")
                        .Where(up => (int)up.Element("usuario_id") == beUsuario.Codigo)
                        .ToList();

                    foreach (var permiso in permisosDelUsuario)
                    {
                        permiso.Remove();
                    }
                }



                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GuardarUsuario(BEUsuario beUsuario)
        {
            try
            {
                XDocument doc;
                doc = CargarXml();

                
                XElement usuariosElement;

                if (File.Exists(xmlFilePath))
                {
                    usuariosElement = doc.Root.Element("usuarios");
                    if (usuariosElement == null)
                    {
                        usuariosElement = new XElement("usuarios");
                        doc.Root.Add(usuariosElement);
                    }
                }
                else
                {
                    doc = new XDocument(
                        new XElement("sistema",
                            new XElement("usuarios")));
                    usuariosElement = doc.Root.Element("usuarios");
                }
                XElement usuariosPermisosElement = doc.Root.Element("usuarios_permisos");

                if (usuariosPermisosElement == null)
                {
                    usuariosPermisosElement = new XElement("usuarios_permisos");
                    doc.Root.Add(usuariosPermisosElement);
                }

                XElement usuariosRolesElement = doc.Root.Element("usuarios_roles");

                if (usuariosRolesElement == null)
                {
                    usuariosRolesElement = new XElement("usuarios_roles");
                    doc.Root.Add(usuariosRolesElement);
                }

                // Verificar existencia de DNI y nombre de usuario
                if (usuariosElement.Elements("usuario").Any(u => (string)u.Element("dni") == beUsuario.Dni.ToString()))
                {
                    throw new Exception("El DNI ingresado ya está asociado a otro usuario.");
                }
                if (usuariosElement.Elements("usuario").Any(u => (string)u.Element("nombre_de_usuario") == beUsuario.NombreDeUsuario))
                {
                    throw new Exception("El nombre de usuario ingresado ya está en uso.");
                }

                // Determinar el próximo código
                int nextCodigo = 1;
                if (usuariosElement.Elements("usuario").Any())
                {
                    nextCodigo = usuariosElement.Elements("usuario")
                                                 .Max(u => (int)u.Attribute("codigo")) + 1;
                }

                // Agregar nuevo usuario
                usuariosElement.Add(new XElement("usuario",
                    new XAttribute("codigo", nextCodigo.ToString().Trim()),
                    new XElement("dni", beUsuario.Dni.ToString().Trim()),
                    new XElement("nombre_de_usuario", beUsuario.NombreDeUsuario.ToString().Trim()),
                    new XElement("contrasenia", beUsuario.Contrasenia.ToString().Trim()),
                    new XElement("nombre", beUsuario.Nombre.ToString().Trim()),
                    new XElement("apellido", beUsuario.Apellido.ToString().Trim())
                ));

                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarUsuario(BEUsuario beUsuario, BEUsuario usuarioDatosViejos)
        {
            try
            {
                XDocument doc = CargarXml();

                // Obtener el elemento de usuarios
                XElement usuariosElement = doc.Root.Element("usuarios");

                if (usuariosElement == null)
                {
                    throw new Exception("El elemento 'usuarios' no se encontró en el XML.");
                }

                // Buscar el usuario por su código
                XElement usuarioElement = usuariosElement.Elements("usuario")
                                                 .FirstOrDefault(u => (string)u.Element("nombre_de_usuario") == usuarioDatosViejos.NombreDeUsuario.ToString().Trim());
                if (usuarioElement == null)
                {
                    throw new Exception("El usuario con el código especificado no se encontró.");
                }

                // Actualizar los campos del usuario
                usuarioElement.SetElementValue("dni", beUsuario.Dni.ToString().Trim());
                usuarioElement.SetElementValue("nombre_de_usuario", beUsuario.NombreDeUsuario.ToString().Trim());
                usuarioElement.SetElementValue("contrasenia", beUsuario.Contrasenia.ToString().Trim());
                usuarioElement.SetElementValue("nombre", beUsuario.Nombre.ToString().Trim());
                usuarioElement.SetElementValue("apellido", beUsuario.Apellido.ToString().Trim());

                // Guardar los cambios en el archivo XML
                doc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CargarRolesYPermisosRecursivo(BERoles rol, XElement rolesElement, XElement permisosElement, XElement padresHijosElement, HashSet<int> rolesProcesados)
        {
            // Evitar ciclos
            if (rolesProcesados.Contains(rol.Codigo))
            {
                return; // Evitar recursión infinita
            }

            // Marcar rol como procesado
            rolesProcesados.Add(rol.Codigo);

            var hijosAsociados = padresHijosElement.Elements("padre_hijo")
                .Where(ph => (int)ph.Element("padre_id") == rol.Codigo)
                .Select(ph => new
                {
                    HijoId = (int)ph.Element("hijo_id"),
                    HijoTipo = (int)ph.Element("hijo_tipo")
                });

            foreach (var hijo in hijosAsociados)
            {
                if (hijo.HijoTipo == 1) // Hijo es un rol
                {
                    XElement rolHijoElement = rolesElement.Elements("rol")
                        .FirstOrDefault(r => (int)r.Attribute("codigo") == hijo.HijoId);

                    if (rolHijoElement != null)
                    {
                        BERoles rolHijo = new BERoles(rolHijoElement.Element("nombre").Value, hijo.HijoId);

                        // Recursividad: cargar roles y permisos para este rol hijo
                        CargarRolesYPermisosRecursivo(rolHijo, rolesElement, permisosElement, padresHijosElement, rolesProcesados);

                        rol.Permisos.Add(rolHijo); // Agregar el rol hijo al rol padre
                    }
                }
                else if (hijo.HijoTipo == 2) // Hijo es un permiso
                {
                    XElement permisoElement = permisosElement.Elements("permiso")
                        .FirstOrDefault(p => (int)p.Attribute("codigo") == hijo.HijoId);

                    if (permisoElement != null)
                    {
                        BEPermiso permiso = new BEPermiso(permisoElement.Element("nombre").Value, hijo.HijoId);
                        rol.Permisos.Add(permiso); // Agregar el permiso al rol
                    }
                }
            }
        }

        public List<BEUsuario> listaUsuarios()
        {
            List<BEUsuario> listaUsuarios = new List<BEUsuario>();

            XDocument doc = XDocument.Load(xmlFilePath);
            XElement usuariosElement = doc.Root.Element("usuarios");
            XElement usuariosRolesElement = doc.Root.Element("usuarios_roles");
            XElement rolesElement = doc.Root.Element("roles");
            XElement permisosElement = doc.Root.Element("permisos");
            XElement padresHijosElement = doc.Root.Element("padres_hijos");
            XElement usuariosPermisosElement = doc.Root.Element("usuarios_permisos");

            if (padresHijosElement == null)
            {
                padresHijosElement = new XElement("padres_hijos");
                doc.Root.Add(padresHijosElement);
                doc.Save(xmlFilePath);
            }

            if (usuariosElement != null)
            {
                foreach (XElement usuarioElement in usuariosElement.Elements("usuario"))
                {
                    BEUsuario usuario = new BEUsuario
                    {
                        Codigo = Convert.ToInt32(usuarioElement.Attribute("codigo").Value),
                        Dni = Convert.ToInt32(usuarioElement.Element("dni").Value),
                        NombreDeUsuario = usuarioElement.Element("nombre_de_usuario").Value,
                        Contrasenia = usuarioElement.Element("contrasenia").Value,
                        Nombre = usuarioElement.Element("nombre").Value,
                        Apellido = usuarioElement.Element("apellido").Value
                    };

                    // Roles de usuario
                    if (usuariosRolesElement != null)
                    {
                        var rolesAsignados = usuariosRolesElement.Elements("usuario_rol")
                            .Where(ur => (int)ur.Element("usuario_id") == usuario.Codigo)
                            .Select(ur => (int)ur.Element("rol_id"));

                        foreach (int rolId in rolesAsignados)
                        {
                            XElement rolElement = rolesElement.Elements("rol")
                                .FirstOrDefault(r => (int)r.Attribute("codigo") == rolId);

                            if (rolElement != null)
                            {
                                BERoles rol = new BERoles(rolElement.Element("nombre").Value, rolId);

                                // Crear un nuevo HashSet para cada rol raíz
                                HashSet<int> rolesProcesados = new HashSet<int>();

                                // Llamar a la función recursiva con control de ciclos
                                CargarRolesYPermisosRecursivo(rol, rolesElement, permisosElement, padresHijosElement, rolesProcesados);

                                usuario.listaComponentes.Add(rol);
                            }
                        }
                    }

                    // Permisos directos de usuario
                    if (usuariosPermisosElement != null)
                    {
                        var permisosDirectos = usuariosPermisosElement.Elements("usuario_permiso")
                            .Where(up => (int)up.Element("usuario_id") == usuario.Codigo)
                            .Select(up => (int)up.Element("permiso_id"));

                        foreach (int permisoId in permisosDirectos)
                        {
                            XElement permisoElement = permisosElement.Elements("permiso")
                                .FirstOrDefault(p => (int)p.Attribute("codigo") == permisoId);

                            if (permisoElement != null)
                            {
                                BEPermiso permiso = new BEPermiso(
                                    permisoElement.Element("nombre").Value, permisoId);

                                usuario.listaComponentes.Add(permiso);
                            }
                        }
                    }

                    listaUsuarios.Add(usuario);
                }
            }

            return listaUsuarios;
        }









        public bool GuardarRolUsuario(BEUsuario usuario, BERoles rol)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement usuariosRolesElement = doc.Root.Element("usuarios_roles");

                if (usuariosRolesElement == null)
                {
                    usuariosRolesElement = new XElement("usuarios_roles");
                    doc.Root.Add(usuariosRolesElement);
                }

                bool existeAsociacion = usuariosRolesElement.Elements("usuario_rol")
                    .Any(ur => (int)ur.Element("usuario_id") == usuario.Codigo &&
                               (int)ur.Element("rol_id") == rol.Codigo);

                if (!existeAsociacion)
                {

                    int nuevoId = usuariosRolesElement.Elements("usuario_rol").Count() + 1;
                    usuariosRolesElement.Add(new XElement("usuario_rol",
                        new XAttribute("id", nuevoId),
                        new XElement("usuario_id", usuario.Codigo),
                        new XElement("rol_id", rol.Codigo)
                    ));
                    doc.Save(xmlFilePath);
                    return true;
                }
                else
                {
                    throw new Exception("El rol ya está asignado al usuario.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el rol del usuario: {ex.Message}");
            }
        }

        public bool EliminarRolUsuario(BEUsuario usuario, BERoles rol)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement usuariosRolesElement = doc.Root.Element("usuarios_roles");

                if (usuariosRolesElement == null)
                {
                    throw new Exception("No hay roles asignados.");
                }

                XElement rolUsuarioElement = usuariosRolesElement.Elements("usuario_rol")
                    .FirstOrDefault(ur => (int)ur.Element("usuario_id") == usuario.Codigo &&
                                          (int)ur.Element("rol_id") == rol.Codigo);

                if (rolUsuarioElement != null)
                {
                    rolUsuarioElement.Remove();
                    doc.Save(xmlFilePath);
                    return true;
                }
                else
                {
                    throw new Exception("El rol no está asignado al usuario.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al quitar el rol del usuario: {ex.Message}");
            }
        }

        public bool GuardarPermisoUsuario(BEUsuario usuario, BEPermiso permiso)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement usuariosPermisosElement = doc.Root.Element("usuarios_permisos");

                if (usuariosPermisosElement == null)
                {
                    usuariosPermisosElement = new XElement("usuarios_permisos");
                    doc.Root.Add(usuariosPermisosElement);
                }

                bool existeAsociacion = usuariosPermisosElement.Elements("usuario_permiso")
                    .Any(ur => (int)ur.Element("usuario_id") == usuario.Codigo &&
                               (int)ur.Element("permiso_id") == permiso.Codigo);

                if (!existeAsociacion)
                {

                    int nuevoId = usuariosPermisosElement.Elements("usuario_permiso").Count() + 1;
                    usuariosPermisosElement.Add(new XElement("usuario_permiso",
                        new XAttribute("id", nuevoId),
                        new XElement("usuario_id", usuario.Codigo),
                        new XElement("permiso_id", permiso.Codigo)
                    ));
                    doc.Save(xmlFilePath);
                    return true;
                }
                else
                {
                    throw new Exception("El permiso ya está asignado al usuario.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el permiso del usuario: {ex.Message}");
            }
        }

        public bool EliminarPermisoUsuario(BEUsuario usuario, BEPermiso permiso)
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                XElement usuariosPermisosElement = doc.Root.Element("usuarios_permisos");

                if (usuariosPermisosElement == null)
                {
                    throw new Exception("No hay permisos asignados.");
                }

                XElement permisoUsuarioElement = usuariosPermisosElement.Elements("usuario_permiso")
                    .FirstOrDefault(ur => (int)ur.Element("usuario_id") == usuario.Codigo &&
                                          (int)ur.Element("permiso_id") == permiso.Codigo);

                if (permisoUsuarioElement != null)
                {
                    permisoUsuarioElement.Remove();
                    doc.Save(xmlFilePath);
                    return true;
                }
                else
                {
                    throw new Exception("El permiso no está asignado al usuario.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al quitar el permiso del usuario: {ex.Message}");
            }
        }


        public bool EliminarComponente(BEUsuario usuario, BEComponente componente)
        {
            try
            {
                XDocument doc;
                doc = XDocument.Load(xmlFilePath);
                XElement usuariosElement = doc.Root.Element("usuarios");

                XElement usuarioElement = usuariosElement.Elements("usuario")
                    .FirstOrDefault(u => (int)u.Attribute("codigo") == usuario.Codigo);

                if (usuarioElement != null)
                {
                    XElement rolUsuarioElement = usuarioElement.Element("usuario_roles");

                    if (rolUsuarioElement != null)
                    {
                        XElement Element = rolUsuarioElement.Elements("usuario_rol")
                            .FirstOrDefault(c => (int)c.Attribute("codigo") == componente.Codigo);

                        if (Element != null)
                        {
                            Element.Remove();
                            doc.Save(xmlFilePath);
                            return true;
                        }
                        else
                        {
                            throw new Exception($"El componente con código {componente.Codigo} no está asociado al usuario.");
                        }
                    }
                    else
                    {
                        throw new Exception("No se encontraron componentes asociados al usuario.");
                    }
                }
                else
                {
                    throw new Exception($"Usuario con código {usuario.Codigo} no encontrado en el archivo XML.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar componente del usuario: {ex.Message}");
            }
        }





    }
}
