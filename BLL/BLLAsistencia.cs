using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{

    public class BLLAsistencia
    {
        MPPAsistencia asistencia;
        #region "constructor"
        public BLLAsistencia()
        {
            asistencia = new MPPAsistencia();
        }
        #endregion

        #region "metodos"

        public bool GuardarAsistencia(List<BEAsistencia> listaAsistencia)
        {
            return asistencia.GuardarAsistencia(listaAsistencia);
        }

        public bool ComprobarAsistenciaEnFecha(BECarrera carrera, BEMateria materia, string fecha)
        {
            return asistencia.ComprobarAsistenciaEnFecha(carrera, materia, fecha);
        }

        public DataTable DevolverAsistencia(BECarrera carrera, BEMateria materia, string fecha)
        {
            return asistencia.DevolverAsistencia(carrera, materia, fecha);
        }

        public bool ModificarAsistencia(BEAsistencia beAsistencia)
        {
            return asistencia.ModificarAsistencia(beAsistencia);
        }

        public DataTable DevolverAsistenciaPorFecha(BECarrera carrera, BEMateria materia)
        {
            return asistencia.DevolverAsistenciaPorFecha(carrera, materia);
        }

        public void GuardarAsistenciaPorFecha(List<BEAsistencia> listaAsistencia)
        {
            asistencia.GuardarAsistenciaPorFecha(listaAsistencia);
        }

        public List<BEAsistencia> AsistenciaHoy()
        {
            return asistencia.AsistenciaHoy();
        }

        public List<BEAsistencia> AsistenciaUltimaSemana()
        {
            return asistencia.AsistenciaUltimaSemana();
        }

        public List<BEAsistencia> AsistenciaUltimoMes()
        {
            return asistencia.AsistenciaUltimoMes();
        }

        public List<BEAsistencia> AsistenciaIntervalo(DateTime desde, DateTime hasta)
        {
            return asistencia.AsistenciaIntervalo(desde,hasta);
        }
        #endregion
    }
}
