using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAsistencia
    {

        #region propiedades
        public int Id { get; set; }
        public int IdCarrera { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; }

        #endregion

        #region constructores
        public BEAsistencia(int id, int idCarrera, int idMateria, int idAlumno, DateTime fecha, bool asistencia) 
        {
            Id = id;
            IdCarrera = idCarrera;
            IdMateria = idMateria;
            IdAlumno = idAlumno;
            Fecha = fecha;
            Asistencia = asistencia;
        }

        public BEAsistencia()
        { }
        #endregion
    }
}
