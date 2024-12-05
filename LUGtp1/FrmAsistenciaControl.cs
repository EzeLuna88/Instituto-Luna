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
    public partial class FrmAsistenciaControl : Form
    {
        BLLAsistencia bllAsistencia;
        BLLProfesor bllProfesor;
        BEProfesor beProfesor;
        BEMateria beMateria;
        BECarrera beCarrera;
        bool modificarAsistencia;
        bool asistenciaHoy;
        DateTime fechaAsistencia;

        public FrmAsistenciaControl(BEProfesor profesor)
        {
            beProfesor = profesor;
            beCarrera = new BECarrera();
            beMateria = new BEMateria();
            bllProfesor = new BLLProfesor();
            bllAsistencia = new BLLAsistencia();
            InitializeComponent();
            CargarComboBox();
            labelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            modificarAsistencia = false;
        }

        void CargarComboBox()
        {
            try
            {
                comboBoxCarreraProfesor.DataSource = null;
                comboBoxCarreraProfesor.DataSource = bllProfesor.ListarCarreras(beProfesor);
                comboBoxCarreraProfesor.ValueMember = "Codigo";
                comboBoxCarreraProfesor.DisplayMember = "Nombre";
                comboBoxCarreraProfesor.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBoxCarreraProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            beCarrera = (BECarrera)comboBoxCarreraProfesor.SelectedItem;
            CargarComboBoxMaterias();

        }

        void CargarComboBoxMaterias()
        {
            try
            {
                comboBoxMateriaProfesor.DataSource = null;
                comboBoxMateriaProfesor.DataSource = bllProfesor.ListarMaterias(beProfesor, beCarrera);
                comboBoxMateriaProfesor.ValueMember = "Codigo";
                comboBoxMateriaProfesor.DisplayMember = "Nombre";
                comboBoxMateriaProfesor.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            modificarAsistencia = false;
            asistenciaHoy = true;
            beMateria = comboBoxMateriaProfesor.SelectedItem as BEMateria;
            if (beMateria != null)
            {
                bool asistenciaCargada = bllAsistencia.ComprobarAsistenciaEnFecha(beCarrera, beMateria, DateTime.Now.ToString("MM/dd/yyyy"));
                if (asistenciaCargada)
                {
                    MostrarAsistenciaCargada();
                    dataGridViewAlumnos.Columns["Asistencia"].DisplayIndex = 0;
                }
                else
                {
                    MostrarAlumnosParaAsistencia();

                }
            }
        }

        private void MostrarAsistenciaCargada()
        {
            buttonGuardarAsistencia.Visible = false;
            buttonModificarAsistencia.Visible = true;
            EliminarColumnaAsistencia();
            ConfigurarDataGridViewSoloLectura();
            MostrarDatosAsistencia();
        }

        private void MostrarAlumnosParaAsistencia()
        {
            buttonGuardarAsistencia.Visible = true;
            buttonModificarAsistencia.Visible = false;
            EliminarColumnaAsistencia();
            AgregarColumnaAsistencia();
            ConfigurarDataGridViewEditable();
        }

        private void EliminarColumnaAsistencia()
        {
            DataGridViewColumn columnaAsistencia = dataGridViewAlumnos.Columns["Asistencia"];
            if (columnaAsistencia != null)
            {
                dataGridViewAlumnos.Columns.Remove(columnaAsistencia);
            }
        }

        private void AgregarColumnaAsistencia()
        {
            DataGridViewCheckBoxColumn columnaAsistenciaCheckbox = new DataGridViewCheckBoxColumn();
            columnaAsistenciaCheckbox.Name = "Asistencia";
            columnaAsistenciaCheckbox.HeaderText = "Asistencia";
            dataGridViewAlumnos.Columns.Add(columnaAsistenciaCheckbox);
            dataGridViewAlumnos.Columns["Asistencia"].DisplayIndex = 0;
        }

        private void ConfigurarDataGridViewSoloLectura()
        {
            dataGridViewAlumnos.ReadOnly = true;
            dataGridViewAlumnos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            MostrarDatosAsistencia();
        }

        private void ConfigurarDataGridViewEditable()
        {
            dataGridViewAlumnos.ReadOnly = false;
            dataGridViewAlumnos.RowsDefaultCellStyle.BackColor = Color.White;
            var listaAlumnos = bllProfesor.ListasAlumnosDeMaterias(beCarrera, beMateria);
            var listaAlumnosOrdenada = listaAlumnos.OrderBy(alumno => alumno.Apellido).ToList();
            dataGridViewAlumnos.DataSource = listaAlumnosOrdenada;

            dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 1;
            dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 2;

            foreach (DataGridViewColumn column in dataGridViewAlumnos.Columns)
            {
                if (column.Name != "Asistencia")
                {
                    column.ReadOnly = true;
                }
            }

            ConfigurarDataGridViewVisualizacion();
        }

        private void ConfigurarDataGridViewVisualizacion()
        {
            if (dataGridViewAlumnos.DataSource != null)
            {
                dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewAlumnos.ClearSelection();
                OcultarColumnasInnecesarias();
            }
        }

        private void MostrarDatosAsistencia()
        {
            string fechaFormateada = fechaAsistencia.ToString("MM/dd/yyyy");

            if (asistenciaHoy)
            {
                DataTable dt = bllAsistencia.DevolverAsistencia(beCarrera, beMateria, DateTime.Now.ToString("MM/dd/yyyy"));
                dataGridViewAlumnos.DataSource = dt;
                dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 1;
                dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 2;
                dataGridViewAlumnos.Columns["CodigoAlumno"].HeaderText = "Codigo";

                foreach (DataGridViewColumn column in dataGridViewAlumnos.Columns)
                {
                    if (column.Name != "Asistencia")
                    {
                        column.ReadOnly = true;
                    }
                }

                ConfigurarDataGridViewVisualizacion();
            }
            else if (!asistenciaHoy)
            {
                DataTable dt = bllAsistencia.DevolverAsistencia(beCarrera, beMateria, fechaFormateada);
                dataGridViewAlumnos.DataSource = dt;
                dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 1;
                dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 2;
                dataGridViewAlumnos.Columns["CodigoAlumno"].HeaderText = "Codigo";

                foreach (DataGridViewColumn column in dataGridViewAlumnos.Columns)
                {
                    if (column.Name != "Asistencia")
                    {
                        column.ReadOnly = true;
                    }
                }

                ConfigurarDataGridViewVisualizacion();
            }

        }

        private void OcultarColumnasInnecesarias()
        {
            string[] columnasOcultas = { "FechaDeNacimiento", "Direccion", "telefono", "Email", "MatriculaPagada", "Becado" };
            foreach (string columna in columnasOcultas)
            {
                DataGridViewColumn columnaVisible = dataGridViewAlumnos.Columns[columna];
                if (columnaVisible != null)
                {
                    columnaVisible.Visible = false;
                }
            }
        }

        private void buttonGuardarAsistencia_Click(object sender, EventArgs e)
        {
            if (!modificarAsistencia)
            {
                List<BEAsistencia> listaAsistencia = new List<BEAsistencia>();
                foreach (DataGridViewRow fila in dataGridViewAlumnos.Rows)
                {
                    BEAsistencia asistencia = new BEAsistencia();
                    asistencia.IdCarrera = beCarrera.Codigo;
                    asistencia.IdMateria = beMateria.Codigo;
                    asistencia.IdAlumno = Convert.ToInt32(fila.Cells["Codigo"].Value);
                    if (asistenciaHoy)
                    {
                        asistencia.Fecha = DateTime.Now;
                    }
                    else if (!asistenciaHoy)
                    {
                        asistencia.Fecha = fechaAsistencia;
                    }
                    asistencia.Asistencia = Convert.ToBoolean(fila.Cells["Asistencia"].Value);
                    listaAsistencia.Add(asistencia);
                }
                bllAsistencia.GuardarAsistencia(listaAsistencia);
                MessageBox.Show("Se guardo la asistencia del dia");
                modificarAsistencia = false;
                buttonMostrar_Click(sender, e);
            }
            else
            {
                foreach (DataGridViewRow fila in dataGridViewAlumnos.Rows)
                {
                    BEAsistencia asistencia = new BEAsistencia();
                    asistencia.IdCarrera = beCarrera.Codigo;
                    asistencia.IdMateria = beMateria.Codigo;
                    asistencia.IdAlumno = Convert.ToInt32(fila.Cells[4].Value);
                    asistencia.Fecha = DateTime.Now;
                    asistencia.Asistencia = Convert.ToBoolean(fila.Cells["Asistencia"].Value);
                    bllAsistencia.ModificarAsistencia(asistencia);

                }
                MessageBox.Show("Se modifico la asistencia del dia");
                buttonGuardarAsistencia.Visible = false;
                buttonModificarAsistencia.Visible = true;
                modificarAsistencia = false;
                ConfigurarDataGridViewSoloLectura();
            }

        }

        private void buttonModificarAsistencia_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridViewEditable();
            MostrarDatosAsistencia();
            DataGridViewColumn columnaAsistencia = dataGridViewAlumnos.Columns["Asistencia"];
            if (columnaAsistencia != null)
            {
                columnaAsistencia.DisplayIndex = 0;
            }
            buttonModificarAsistencia.Visible = false;
            buttonGuardarAsistencia.Visible = true;
            modificarAsistencia = true;
        }

        private void buttonFechasAnteriores_Click(object sender, EventArgs e)
        {
            FrmAsistenciaAnteriores asistenciaAnteriores = new FrmAsistenciaAnteriores(beCarrera, beMateria);
            DialogResult result = asistenciaAnteriores.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Asistencia guardada exitosamente.");
            }
            else if (result == DialogResult.Cancel)
            {
            }

        }

        private void buttonAsistenciaFechaElegida_Click(object sender, EventArgs e)
        {
            modificarAsistencia = false;
            asistenciaHoy = false;
            beMateria = comboBoxMateriaProfesor.SelectedItem as BEMateria;
            if (beMateria != null)
            {
                if (DateTime.TryParseExact(textBoxAsistenciaFecha.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaAsistencia))
                {

                    string fechaFormateada = fechaAsistencia.ToString("MM/dd/yyyy");

                    bool asistenciaCargada = bllAsistencia.ComprobarAsistenciaEnFecha(beCarrera, beMateria, fechaFormateada);
                    if (asistenciaCargada)
                    {
                        MostrarAsistenciaCargada();
                        dataGridViewAlumnos.Columns["Asistencia"].DisplayIndex = 0;
                    }
                    else
                    {
                        MostrarAlumnosParaAsistencia();
                    }
                }
                else
                {
                    MessageBox.Show("Fecha inválida. Por favor, ingrese una fecha válida en el formato dd/MM/yyyy.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una materia.", "Error de Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
