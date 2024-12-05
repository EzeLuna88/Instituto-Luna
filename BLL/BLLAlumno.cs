using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using MPP;

namespace BLL
{
    public class BLLAlumno
    {
        #region "constructor"
        public BLLAlumno()
        {
            mPPAlumno = new MPPAlumno();
        }
        #endregion

        MPPAlumno mPPAlumno;

        #region "metodos"
        public List<BEAlumno> ListarTodo()
        {
            return mPPAlumno.listarTodo();
        }

        public bool Guardar(BEAlumno beAlumno)
        {
            return mPPAlumno.Guardar(beAlumno);
        }

        public bool Baja(BEAlumno BEAlumno)
        {
            return mPPAlumno.Baja(BEAlumno);
        }

     
        public int CalcularMatricula()
        {
            return 10000;
        }



        public int TotalAlumnos()
        {
            return mPPAlumno.TotalAlumnos();
        }

        public DataTable TotalesMatricula()
        {
            return mPPAlumno.TotalesMatricula();
        }

        public DataTable TotalesBecados()
        {
            return mPPAlumno.TotalesBecados();
        }

        public DataTable RangoEdades(BECarrera carrera)
        {
            return mPPAlumno.RangoEdades(carrera);
        }

        public List<BEAlumno> CargarReporteRegulares()
        {
            return mPPAlumno.CargarReporteRegulares();
        }

        public List<BEAlumno> CargarReporteBecados()
        {
            return mPPAlumno.CargarReporteBecados();
        }

        public List<BEAlumno> CargarMatriculasPagadas()
        {
            return mPPAlumno.CargarMatriculasPagadas();
        }

        public List<BEAlumno> CargarMatriculasNoPagadas()
        {
            return mPPAlumno.CargarMatriculasNoPagadas();
        }

        public List<BEAlumno> CargarAlumnosPorCarrera(BECarrera carrera)
        { return mPPAlumno.CargarAlumnosPorCarrera(carrera); }

        #endregion

    }
}
