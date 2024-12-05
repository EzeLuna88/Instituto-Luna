using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUGtp1
{
    public partial class FrmAsistenciaAnteriores : Form
    {
        BECarrera beCarrera;
        BEMateria beMateria;

        BLLAsistencia bllAsistencia;

        public FrmAsistenciaAnteriores(BECarrera carrera, BEMateria materia)
        {
            beCarrera = carrera;
            beMateria = materia;

            bllAsistencia = new BLLAsistencia();
            InitializeComponent();
            MostrarDatosAsistencia();
            buttonGuardarAsistencia.Visible = false;
            buttonModificarAsistencia.Visible = true;
            ConfigurarDataGridViewSoloLectura();
        }


        private void MostrarDatosAsistencia()
        {
            dataGridViewAlumnos.ReadOnly = false;
            dataGridViewAlumnos.RowsDefaultCellStyle.BackColor = Color.White;
            var listaAlumnos = bllAsistencia.DevolverAsistenciaPorFecha(beCarrera, beMateria);
            if (listaAlumnos != null && listaAlumnos.Rows.Count > 0)
            {
                var dtAlumnosOrdenado = listaAlumnos.AsEnumerable()
                                                     .OrderBy(row => row.Field<string>("Apellido"))
                                                     .CopyToDataTable();
                dataGridViewAlumnos.DataSource = dtAlumnosOrdenado;
                ConfigurarDataGridView();
            }


        }

        private void ConfigurarDataGridView()
        {
            int index = 0;

            dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = index++;
            dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = index++;
            dataGridViewAlumnos.Columns["Dni"].DisplayIndex = index++;
            dataGridViewAlumnos.Columns["CodigoAlumno"].DisplayIndex = index++;
            dataGridViewAlumnos.Columns["CodigoAlumno"].HeaderText = "Codigo";

            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewAlumnos.AllowUserToAddRows = false;
            dataGridViewAlumnos.Font = new Font("Segoe UI", 10);

            foreach (DataGridViewColumn column in dataGridViewAlumnos.Columns)
            {
                if (column.Name != "Apellido" && column.Name != "Nombre" && column.Name != "Dni" && column.Name != "CodigoAlumno")
                {
                    column.DisplayIndex = index++;
                }
            }
        }

        private void ConfigurarDataGridViewSoloLectura()
        {
            dataGridViewAlumnos.ReadOnly = true;
            dataGridViewAlumnos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void buttonModificarAsistencia_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridViewEditable();
        }

        private void ConfigurarDataGridViewEditable()
        {
            dataGridViewAlumnos.ReadOnly = false;
            dataGridViewAlumnos.RowsDefaultCellStyle.BackColor = Color.White;
            buttonGuardarAsistencia.Visible = true;
            buttonModificarAsistencia.Visible = false;

            foreach (DataGridViewColumn column in dataGridViewAlumnos.Columns)
            {
                if (column.Name == "Apellido" || column.Name == "Nombre" || column.Name == "Dni"
                    || column.Name == "CodigoAlumno")
                {
                    column.ReadOnly = true;
                }
            }


        }

        private void buttonGuardarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                List<BEAsistencia> listaAsistencia = new List<BEAsistencia>();

                foreach (DataGridViewRow fila in dataGridViewAlumnos.Rows)
                {
                    int codigoAlumno = Convert.ToInt32(fila.Cells["CodigoAlumno"].Value);

                    foreach (DataGridViewColumn columna in dataGridViewAlumnos.Columns)
                    {
                        if (columna.Name != "Nombre" && columna.Name != "Apellido" && columna.Name != "Dni" && columna.Name != "CodigoAlumno")
                        {
                            DateTime fecha;
                            if (DateTime.TryParse(columna.Name, out fecha))
                            {
                                bool asistencia = Convert.ToBoolean(fila.Cells[columna.Index].Value);

                                BEAsistencia asistenciaObj = new BEAsistencia
                                {
                                    IdCarrera = beCarrera.Codigo,
                                    IdMateria = beMateria.Codigo,
                                    IdAlumno = codigoAlumno,
                                    Fecha = fecha,
                                    Asistencia = asistencia
                                };

                                listaAsistencia.Add(asistenciaObj);
                            }
                        }
                    }
                }

                bllAsistencia.GuardarAsistenciaPorFecha(listaAsistencia);
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
