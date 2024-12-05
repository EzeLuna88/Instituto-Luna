using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECarrera: Entidad
    {
        #region "constructor"
        public BECarrera()
            {
            ListaMaterias = new List<BEMateria>();
            ListaAlumnos = new List<BEAlumno>();
        }

        public BECarrera(int codigo, string nombre, List<BEMateria> listaMaterias, List<BEAlumno> listaAlumnos)
        {
            Codigo = codigo;
            Nombre = nombre;
            ListaMaterias = listaMaterias;
            ListaAlumnos = listaAlumnos;
        }


        #endregion

        #region "propiedades"

       

        public string Nombre { get; set; }

        public List<BEMateria> ListaMaterias;
        public List<BEAlumno> ListaAlumnos;

        #endregion

        #region metodos
        public override string ToString()
        {
            return Nombre;
        }
        #endregion
    }
}
