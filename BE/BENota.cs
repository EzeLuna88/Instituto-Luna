using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BENota
    {

        #region propiedades
        public int Id { get; set; }
        public int CodigoCarrera { get; set; }
        public int CodigoMateria { get; set; }
        public int CodigoAlumno { get; set; }
        public decimal NotaParcial1 { get; set; }
        public decimal NotaParcial2 { get; set; }

        #endregion
    }
}
