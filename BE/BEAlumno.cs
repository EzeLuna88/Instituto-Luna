using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAlumno: Entidad
    {

        #region "propiedades"

        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }

        public bool Becado { get; set; }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }

        public bool MatriculaPagada { get; set; }


        #endregion

        

        


    }
}
