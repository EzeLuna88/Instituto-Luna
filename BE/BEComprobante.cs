using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEComprobante
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }
        public int CodigoAlumno { get; set; }
    }
}
