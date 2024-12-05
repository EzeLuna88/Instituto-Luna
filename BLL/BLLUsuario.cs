using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLUsuario
    {
        #region "constructor"
        public BLLUsuario()
        {
            mPPUsuario = new MPPUsuario();
        }
        #endregion

        MPPUsuario mPPUsuario;

        #region "metodos"
        public BEUsuario BuscarUsuario(BEUsuario bEUsuario)
        {
            return mPPUsuario.BuscarUsuario(bEUsuario);
        }

        public bool GuardarUsuario(BEUsuario usuario)
        {
            return mPPUsuario.GuardarUsuario(usuario);
        }

        public bool GuardarRolUsuario(BEUsuario usuario, BERoles rol)
        {
            return mPPUsuario.GuardarRolUsuario(usuario,rol);
        }

        public bool ModificarUsuario(BEUsuario usuario, BEUsuario usuarioDatosViejos)
        {
            return mPPUsuario.ModificarUsuario(usuario, usuarioDatosViejos);
        }

        public bool EliminarRolUsuario(BEUsuario usuario, BERoles rol)
        {
            return mPPUsuario.EliminarRolUsuario(usuario, rol);
        }

        public bool AgregarPermisoUsuario(BEUsuario usuario, BEPermiso permiso)
        {
            return mPPUsuario.GuardarPermisoUsuario(usuario, permiso);
        }

        public bool EliminarPermisoUsuario(BEUsuario usuario, BEPermiso permiso)
        {
            return mPPUsuario.EliminarPermisoUsuario(usuario, permiso);
        }

        public List<BEUsuario> ListaUsuarios()
        {
            return mPPUsuario.listaUsuarios();
        }

        public bool BorrarUsuario(BEUsuario usuario)
        {
            return mPPUsuario.BorrarUsuario(usuario);
        }
        #endregion

    }
}
