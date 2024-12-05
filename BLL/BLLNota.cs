using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLNota
    {
        MPPNota mppNota;

        #region "constructor"
        public BLLNota()
        { mppNota = new MPPNota(); }

        #endregion

        #region "metodos"
        public DataTable Listar(BECarrera carrera, BEMateria materia)
        {
            return mppNota.Listar(carrera, materia);
        }

        public List<BENota> ListarNotas()
        {
            return mppNota.ListarNotas();
        }

        public bool GuardarNotas(List<BENota> listaNotas)
        {
            return mppNota.GuardarNotas(listaNotas);
        }
        #endregion
    }
}
