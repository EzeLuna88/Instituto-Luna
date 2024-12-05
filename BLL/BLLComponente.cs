using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BLLComponente
    {

        #region "metodos"
        public abstract void AgregarHijo(BEComponente rol, BEComponente permiso);

        public abstract void EliminarHijo(BEComponente padre, BEComponente hijo, int hijoTipo);

        public abstract IList<BEComponente> ObtenerHijos();

        public abstract IList<BEComponente> CargarRoles();

        public abstract IList<BEComponente> CargarPermisos();

        public abstract IList<BEComponente> CargarComponentes();


        #endregion
    }
}
