using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public abstract class BEComponente
    {
        public string _nombre;
        public int _codigo;
        private string nombre;

        public BEComponente(string nombre, int codigo)
        {
            _nombre = nombre;
            _codigo = codigo;
        }

        public BEComponente() { }

        protected BEComponente(string nombre)
        {
            this.nombre = nombre;
        }

        public abstract IList<BEComponente> Hijos { get; }

        public string Nombre { get { return _nombre; } }
        public int Codigo { get { return _codigo; } }

       
    }
}
