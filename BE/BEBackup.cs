using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBackup
    {
        #region propiedades
        public int Codigo { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public BEUsuario Usuario { get; set; }
        public string NombreArchivo { get; set; }
        public string Tipo { get; set; }
        #endregion
    }
}
