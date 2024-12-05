using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;
using System.Data;

namespace BLL
{
    public class BLLCarrera: IGestor<BECarrera>
    {
        #region "constructor"
        public BLLCarrera()
        {
            carrera = new MPPCarrera();

        }

        #endregion


        MPPCarrera carrera;

        #region "metodos"
        public List<BECarrera> ListarTodo()
        {
            return carrera.ListarTodo();
        }

        public bool Guardar(BECarrera BEcarrera)
        {
            return carrera.Guardar(BEcarrera);
        }

        public bool Baja(BECarrera BECarrera)
        {
            return carrera.Baja(BECarrera);
        }

        public bool AgregarMateria(BECarrera bECarrera, BEMateria bEMateria, bool materiaInicial)
        {
           return carrera.AgregarMateria(bECarrera, bEMateria, materiaInicial);
        }

        public bool AgregarAlumno(BECarrera bECarrera, BEAlumno bEAlumno)
        {
            return carrera.AgregarAlumno(bECarrera, bEAlumno);
        }

        public bool BorrarMateria(BECarrera bECarrera, BEMateria bEMateria)
        {

            return carrera.BorrarMateria(bECarrera, bEMateria);
        }

        public bool BorrarAlumno(BECarrera beCarrera, BEAlumno alumno)
        {
            return carrera.BorrarAlumno (beCarrera, alumno);
        }

        public List<BEMateria> ListarMaterias(BECarrera beCarrera)
        {
            return carrera.ListarMaterias(beCarrera);
        }

        public BECarrera ListarTodo(BECarrera objeto)
        {
            throw new NotImplementedException();
        }
        

        public int TotalCarreras()
        {
            return carrera.TotalCarreras();
        }

        

        public DataTable TotalesAlumnosPorCarrera()
        {
            return carrera.TotalesAlumnosPorCarrera();
        }
        #endregion
    }
}
