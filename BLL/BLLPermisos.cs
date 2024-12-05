using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPermisos : BLLComponente
    {
        MPPPermisos mppPermisos;

        #region "constructor"
        public BLLPermisos()
        {
            mppPermisos= new MPPPermisos();
        }
        #endregion

        #region "metodos"

        public override void AgregarHijo(BEComponente rol, BEComponente permiso)
        {
            throw new NotImplementedException();
        }

        public override IList<BEComponente> CargarComponentes()
        {
            throw new NotImplementedException();
        }

        public override IList<BEComponente> CargarPermisos()
        {
            return mppPermisos.CargarPermisos();
        }

        public override IList<BEComponente> CargarRoles()
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo(BEComponente rol, BEComponente permiso, int hijoTipo)
        {
            throw new NotImplementedException();
        }

        public List<string> TraerPermisosPorUsuario(int id)
        {
            return mppPermisos.TraerPermisosPorUsuario(id);
        }

        public override IList<BEComponente> ObtenerHijos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
