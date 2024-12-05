using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
    public class BLLBackup
    {
        MPPBackup mppBackup;

        #region "constructor"
        public BLLBackup() 
        { 
        mppBackup = new MPPBackup();
        }
        #endregion

        #region "metodos"

        public List<BEBackup> ListarBitacora()
        {
            return mppBackup.ListarBitacora();
        }

        public bool GuardarRegistroBackup(BEBackup backup)
        {
            return mppBackup.GuardarRegistroBackup(backup);
        }
        #endregion
    }
}
