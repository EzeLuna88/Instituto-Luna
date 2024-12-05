using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLComprobante
    {
        MPPComprobante mppComprobante;

        public BLLComprobante() { mppComprobante = new MPPComprobante(); }

        public bool GuardarComprobante(BEComprobante beComprobante)
        {
            return mppComprobante.GuardarComprobante(beComprobante);
        }

        public int SiguienteNumero()
        {
            return mppComprobante.SiguienteNumero();
        }

        public List<BEComprobante> listaComprobantes(DateTime inicio, DateTime final)
        {
            return mppComprobante.listaComprobantes(inicio, final);
        }
    }
}
