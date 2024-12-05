using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPermiso : BEComponente
    {

        public BEPermiso(string nombre, int codigo) : base(nombre, codigo)
        {

        }

        public BEPermiso() { }

        public override IList<BEComponente> Hijos
        {
            get { return new List<BEComponente>(); }
        }
    }
}
