using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLRoles : BLLComponente
    {
        MPPRoles mppRoles;

        #region "constructor"
        public BLLRoles() 
        { 
        mppRoles= new MPPRoles();
        }
        #endregion

        #region"metodos"
        public override void AgregarHijo(BEComponente padre, BEComponente hijo)
        {
            mppRoles.AgregarHijo(padre, hijo);

        }

        public override IList<BEComponente> CargarPermisos()
        {
            throw new NotImplementedException();
        }

        public override IList<BEComponente> CargarRoles()
        {
            return mppRoles.CargarRoles();
        }

        public override void EliminarHijo(BEComponente padre, BEComponente hijo, int hijoTipo)
        {
            mppRoles.EliminarHijo(padre, hijo, hijoTipo);
        }

        public override IList<BEComponente> ObtenerHijos()
        {
            throw new NotImplementedException();

        }

        public BERoles DevolverRol(int codigo)
        {
            return mppRoles.DevolverRol(codigo);
        }

        public override IList<BEComponente> CargarComponentes()
        {
            return mppRoles.CargarRoles();
        }

        public bool AgregarRol(BERoles rol)
        {
            return mppRoles.AgregarRol(rol);
        }

        public bool EliminarRol(BERoles rol)
        {
            return mppRoles.EliminarRol(rol);
        }
        #endregion
    }
}
