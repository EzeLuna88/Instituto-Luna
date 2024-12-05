using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BERoles : BEComponente
    {
        private IList<BEComponente> _permisos;

                

        public BERoles(string nombre, int codigo) : base(nombre, codigo)
        {
            _permisos = new List<BEComponente>();
        }

        public BERoles()
        { }

        public IList<BEComponente> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }

        public override IList<BEComponente> Hijos
        {
            get { return _permisos; }
        }
    }
}
