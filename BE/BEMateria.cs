using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEMateria: Entidad
    {
        #region "propiedades"

        
        public string Nombre { get; set; }
        public List<BEMateria> Correlatividad { get; set; }
        public BEProfesor Profesor { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        #endregion

        #region "constructores"
        public BEMateria()
        { }

        public BEMateria(int codigo, string nombre, List<BEMateria> correlativas)
        {
            Codigo = codigo;
            Nombre = nombre;
            Correlatividad = correlativas;
            
        }
        #endregion

        
    }
}
