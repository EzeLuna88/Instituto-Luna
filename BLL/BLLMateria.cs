using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
using Abstraccion;
using System.Data;

namespace BLL
{

    
    public class BLLMateria: IGestor<BEMateria>
    {
        #region "constructor"
        public BLLMateria()
        {
            MPPMateria = new MPPMateria();
        }

        #endregion
        
        MPPMateria MPPMateria;

        #region "metodos"
        public List<BEMateria> ListarTodo()
        {
            return MPPMateria.ListarTodo();
        }

      

        public bool Guardar (BEMateria beMateria)
        {
            return MPPMateria.Guardar(beMateria);
        }

        public bool Baja (BEMateria beMateria)
        {
            return MPPMateria.Baja(beMateria);
        }

        public (bool exito, string mensaje) BajaMateria(BEMateria beMateria)
        {
            return MPPMateria.BajaMateria(beMateria);
        }



        public BEMateria ListarTodo(BEMateria objeto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarCorrelatividad(BEMateria materiaPrincipal, BEMateria materiaCorrelativa, BECarrera carrera)
        {
            return MPPMateria.GuardarCorrelatividad(materiaPrincipal, materiaCorrelativa, carrera);
        }

        public bool QuitarCorrelatividad(BECarrera carrera, BEMateria materia)
        {
            return MPPMateria.QuitarCorrelatividad(carrera, materia);
        }

        public bool GuardarProfesor(BEMateria materia, BECarrera carrera, BEProfesor profesor)
        {
            return MPPMateria.GuardarProfesor(materia, carrera, profesor);
        }

        public bool QuitarProfesor(BECarrera carrera, BEMateria materia)
        {
            return MPPMateria.QuitarProfesor(carrera, materia);
        }

        public DataTable ListarAlumnosAsistenciaNotas(BECarrera carrera, BEMateria materia)
        {
            return MPPMateria.ListarAlumnosAsistenciaNotas(carrera, materia);
        }
        #endregion
    }
}
