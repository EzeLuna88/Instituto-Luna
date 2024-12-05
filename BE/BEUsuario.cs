using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuario
    {
        #region "propiedades"

        public int Codigo { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contrasenia { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }

        public List<BEComponente> listaComponentes  { get; set; }

        #endregion

        #region "constructor"
        public BEUsuario()
        { 
            listaComponentes = new List<BEComponente>();
        }
        #endregion
        #region metodos
        public override string ToString()
        {
            return NombreDeUsuario;
        }
        #endregion

        



    }
}
