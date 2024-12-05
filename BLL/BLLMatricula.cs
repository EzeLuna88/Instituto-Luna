using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLMatricula
    {
        MPPMatricula mppMatricula;

        public BLLMatricula() 
        { 
            mppMatricula = new MPPMatricula();
        }

        public void GuardarPrecio(BEMatricula beMatricula)
        {
            mppMatricula.GuardarPrecio(beMatricula);
        }

        public decimal DevolverPrecio()
        {
            return mppMatricula.DevolverPrecio();
        }
    }
}
