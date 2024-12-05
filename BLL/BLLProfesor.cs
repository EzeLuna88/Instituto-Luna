using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
using Abstraccion;

namespace BLL
{
    #region "constructor"
    public class BLLProfesor: IGestor<BEProfesor>
    {

        
        public BLLProfesor()
        {
            mPPProfesor = new MPPProfesor();
        }

        #endregion

        MPPProfesor mPPProfesor;

        #region "metodos"
        public List<BEProfesor> ListarTodo()
        {
            return mPPProfesor.ListarProfesor();
        }

        

        public List<BECarrera> ListarCarreras(BEProfesor profesor)
        {
            return mPPProfesor.ListarCarreras(profesor);
        }

        public List<BEAlumno> ListasAlumnosDeMaterias(BECarrera carrera, BEMateria materia)
        {
            return mPPProfesor.ListasAlumnosDeMaterias(carrera, materia);
        }

        public List<BEMateria> ListarMaterias(BEProfesor profesor, BECarrera carrera)
        {
            return mPPProfesor.ListarMaterias(profesor, carrera);
        }

        public bool Guardar(BEProfesor bEProfesor)
        {
            return mPPProfesor.Guardar(bEProfesor);
        }

        public bool Baja(BEProfesor beProfesor)
        {
            return mPPProfesor.Baja(beProfesor);
        }

        public BEProfesor ListarTodo(BEProfesor objeto)
        {
            throw new NotImplementedException();
        }

        public int TotalProfesores()
        {
            return mPPProfesor.TotalProfesores();
        }

        public BEProfesor DevolverProfesor(BEUsuario usuario)
        {
            return mPPProfesor.DevolverProfesor(usuario);
        }
        #endregion

    }
}
