using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProfesor: Entidad
    {

        #region "propiedades"

        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        #endregion

        #region "metodos"
        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }
        #endregion

        #region "constructores"
        public BEProfesor()
        {

        }

        public BEProfesor(int codigo, string nombre, string apellido, int dni)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }
        #endregion
    }
}
