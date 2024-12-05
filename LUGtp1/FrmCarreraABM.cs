using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using System.Text.RegularExpressions;

namespace LUGtp1
{
    public partial class FrmCarreraABM : Form
    {
        BECarrera BECarrera;
        BLLCarrera BLLCarrera;
        BLLMateria BLLMateria;
        BEMateria BEMateria;
        BLLProfesor bLLProfesor;
        BEAlumno beAlumno;

        #region "constructor"
        public FrmCarreraABM()
        {
            InitializeComponent();
            BECarrera = new BECarrera();
            BLLCarrera = new BLLCarrera();
            BLLMateria = new BLLMateria();
            BEMateria = new BEMateria();
            bLLProfesor = new BLLProfesor();

            CargarDataGridView();
            OcultarGroupBox();

        }
        #endregion




        #region "metodos"


        private void buttonCarreraAlta_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCarreraAlta frmAltaCarrera = new FrmCarreraAlta();
                frmAltaCarrera.ShowDialog();
                CargarDataGridView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void buttonCarreraBaja_Click(object sender, EventArgs e)
        {

            try
            {
                Asignar();
                DialogResult respuesta;
                respuesta = MessageBox.Show("Confirmar la baja de la carrera", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    BLLCarrera.Baja(BECarrera);
                    CargarDataGridView();
                    MessageBox.Show("La carrera se elimino correctamente");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void CargarDataGridView()
        {
            if (BECarrera.Nombre != null)
            {
                var listaCarreras = BLLCarrera.ListarTodo().OrderBy(c => c.Nombre).ToList();
                uC_dgvCarreras.dataGridView1.DataSource = null;
                uC_dgvCarreras.dataGridView1.DataSource = listaCarreras;
                uC_dgvCarreras.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                uC_dgvCarreras.dataGridView1.Font = new Font("Segoe UI", 10);
                uC_dgvCarreras.dataGridView1.Size = new Size(444, 308);
                uC_dgvCarreras.dataGridView1.ClearSelection();

                BECarrera carreraEnFila = BECarrera;
                foreach (DataGridViewRow row in uC_dgvCarreras.dataGridView1.Rows)
                {
                    if (carreraEnFila.Codigo == Convert.ToInt32(row.Cells[1].Value))
                    {
                        row.Selected = true;
                        BECarrera = (BECarrera)row.DataBoundItem;

                        break;
                    }
                }
                uC_dgvCarreras.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            else
            {
                try
                {
                    var listaCarreras = BLLCarrera.ListarTodo().OrderBy(c => c.Nombre).ToList();
                    uC_dgvCarreras.dataGridView1.DataSource = null;
                    uC_dgvCarreras.dataGridView1.DataSource = listaCarreras;
                    uC_dgvCarreras.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    uC_dgvCarreras.dataGridView1.Font = new Font("Segoe UI", 10);
                    uC_dgvCarreras.dataGridView1.Size = new Size(444, 308);
                    uC_dgvCarreras.dataGridView1.CellClick += dataGridViewCarrera_CellClick;

                    uC_dgvCarreras.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        public void CargarDataGridViewMaterias()
        {
            try
            {
                var listaOrdenada = BECarrera.ListaMaterias.OrderBy(m => m.Nombre).ToList();

                uC_dgvMaterias.dataGridView1.DataSource = null;
                uC_dgvMaterias.dataGridView1.DataSource = listaOrdenada;
                uC_dgvMaterias.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                uC_dgvMaterias.dataGridView1.Font = new Font("Segoe UI", 10);
                uC_dgvMaterias.dataGridView1.Size = new Size(713, 201);

                DataGridViewColumn correlativasColumn = uC_dgvMaterias.dataGridView1.Columns["Correlatividad"];
                bool columnaExistente = (correlativasColumn != null);

                if (columnaExistente)
                {
                    uC_dgvMaterias.dataGridView1.Columns.Remove(correlativasColumn);
                }

                correlativasColumn = new DataGridViewTextBoxColumn();
                correlativasColumn.Name = "Correlatividad";
                correlativasColumn.HeaderText = "Correlatividad";
                uC_dgvMaterias.dataGridView1.Columns.Add(correlativasColumn);
                uC_dgvMaterias.dataGridView1.Columns["Correlatividad"].DisplayIndex = uC_dgvMaterias.dataGridView1.Columns.Count - 1;
                uC_dgvMaterias.dataGridView1.Columns["Codigo"].Visible = false;

                foreach (DataGridViewRow row in uC_dgvMaterias.dataGridView1.Rows)
                {
                    BEMateria materia = (BEMateria)row.DataBoundItem;
                    row.Cells["Correlatividad"].Value = ObtenerNombresCorrelativas(materia.Correlatividad);
                }

                uC_dgvMaterias.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


                if (uC_dgvMaterias.dataGridView1.Rows.Count > 0)
                {
                    uC_dgvMaterias.dataGridView1.Rows[0].Selected = true;
                    BEMateria = (BEMateria)uC_dgvMaterias.dataGridView1.Rows[0].DataBoundItem;

                }
                uC_dgvMaterias.dataGridView1.CellClick += dataGridViewMateria_CellClick;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private string ObtenerNombresCorrelativas(List<BEMateria> correlativas)
        {
            List<string> nombresCorrelativas = correlativas.Select(c => c.Nombre).ToList();
            return string.Join(", ", nombresCorrelativas);
        }

        private void buttonCarreraModificacion_Click(object sender, EventArgs e)
        {
            try
            {
                bool resultadoNombre = Regex.IsMatch(textBoxCarreraNombre.Text, @"^[a-zA-Záéíóú\s]+$");
                if (!resultadoNombre)
                { labelErrorNombre.Text = "El nombre tiene formato incorrecto"; }
                else
                {
                    DialogResult resultado = MessageBox.Show("¿Confirmar la modificación de la carrera?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        Asignar();
                        BLLCarrera.Guardar(BECarrera);
                        CargarDataGridView();
                        Limpiar();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void Limpiar()
        {
            try
            {
                textBoxCarreraCodigo.Text = null;
                textBoxCarreraNombre.Text = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Asignar()
        {

            try
            {
                BECarrera.Codigo = Convert.ToInt32(textBoxCarreraCodigo.Text);
                BECarrera.Nombre = textBoxCarreraNombre.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCarreraAgregarMateria frmAgregarMateria = new FrmCarreraAgregarMateria(BECarrera);
            frmAgregarMateria.ShowDialog();
            CargarDataGridView();
            CargarDataGridViewMaterias();
            CargarDataGridViewAlumnos();
        }

        private void dataGridViewCarrera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BECarrera = (BECarrera)uC_dgvCarreras.dataGridView1.CurrentRow.DataBoundItem;
                textBoxCarreraCodigo.Text = BECarrera.Codigo.ToString();
                textBoxCarreraNombre.Text = BECarrera.Nombre;
                CargarDataGridViewMaterias();
                CargarDataGridViewAlumnos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewMateria_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                BEMateria = (BEMateria)uC_dgvMaterias.dataGridView1.CurrentRow.DataBoundItem;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCarreraBajaMateria_Click(object sender, EventArgs e)
        {

            try
            {
                if (uC_dgvMaterias.dataGridView1.CurrentRow != null)
                {
                    BEMateria = (BEMateria)uC_dgvMaterias.dataGridView1.CurrentRow.DataBoundItem;

                    if (BECarrera.Codigo != 0 && BEMateria.Codigo != 0)
                    {
                        DialogResult respuesta;
                        respuesta = MessageBox.Show("Confirmar la quita de la materia", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta == DialogResult.Yes)
                        {
                            BLLCarrera.BorrarMateria(BECarrera, BEMateria);
                            MessageBox.Show("Se borro la materia exitosamente");
                            CargarDataGridView();
                            CargarDataGridViewMaterias();
                            CargarDataGridViewAlumnos();
                        }
                    }
                    else
                    {
                        throw new Exception("Debe seleccionar una carrera y una materia");
                    }
                }
                else
                {
                    throw new Exception("La tabla está vacía o no hay ninguna fila seleccionada.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Limpiar();
        }

        private void textBoxCarreraNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }



        private void btnCorrelatividad_Click(object sender, EventArgs e)
        {
            FrmCorrelatividad frmCorrelatividad = new FrmCorrelatividad(BEMateria, BECarrera);
            frmCorrelatividad.ShowDialog();
            CargarDataGridView();
            CargarDataGridViewMaterias();
        }

        private void btnCorrelatividadQuitar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Confirmar la quita de la correlatividad?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                BLLMateria.QuitarCorrelatividad(BECarrera, BEMateria);
                CargarDataGridView();
                CargarDataGridViewMaterias();
                CargarDataGridViewAlumnos();
                Limpiar();
            }
        }

        public void CargarDataGridViewAlumnos()
        {
            try
            {

                uC_dgvAlumnos.dataGridView1.DataSource = null;
                uC_dgvAlumnos.dataGridView1.DataSource = BECarrera.ListaAlumnos.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre).ToList();
                uC_dgvAlumnos.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                uC_dgvAlumnos.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                uC_dgvAlumnos.dataGridView1.Columns["Apellido"].DisplayIndex = 0;
                uC_dgvAlumnos.dataGridView1.Columns["Nombre"].DisplayIndex = 1;
                uC_dgvAlumnos.dataGridView1.Columns["Dni"].DisplayIndex = 2;
                uC_dgvAlumnos.dataGridView1.Columns["Becado"].Visible = false;
                uC_dgvAlumnos.dataGridView1.Columns["FechaDeNacimiento"].Visible = false;
                uC_dgvAlumnos.dataGridView1.Columns["Direccion"].Visible = false;
                uC_dgvAlumnos.dataGridView1.Columns["Telefono"].Visible = false;
                uC_dgvAlumnos.dataGridView1.Columns["MatriculaPagada"].Visible = false;
                uC_dgvAlumnos.dataGridView1.Columns["Codigo"].Visible = false;
                uC_dgvAlumnos.dataGridView1.Font = new Font("Segoe UI", 10);
                uC_dgvAlumnos.dataGridView1.Size = new Size(713, 248);

                if (uC_dgvAlumnos.dataGridView1.Rows.Count > 0)
                {
                    uC_dgvAlumnos.dataGridView1.Rows[0].Selected = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonAlumnoAgregar_Click(object sender, EventArgs e)
        {
            FrmCarreraAgregarAlumno frmAgregarAlumno = new FrmCarreraAgregarAlumno(BECarrera);
            frmAgregarAlumno.ShowDialog();
            CargarDataGridView();
            CargarDataGridViewMaterias();
            CargarDataGridViewAlumnos();
        }

        private void buttonAlumnoQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (uC_dgvAlumnos.dataGridView1.CurrentRow != null)
                {
                    beAlumno = (BEAlumno)uC_dgvAlumnos.dataGridView1.CurrentRow.DataBoundItem;

                    if (BECarrera.Codigo != 0 && beAlumno.Codigo != 0)
                    {
                        DialogResult respuesta;
                        respuesta = MessageBox.Show("Confirmar la quita del alumno", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (respuesta == DialogResult.Yes)
                        {
                            BLLCarrera.BorrarAlumno(BECarrera, beAlumno);
                            MessageBox.Show("Se borro al alumno exitosamente");
                            CargarDataGridView();
                            CargarDataGridViewMaterias();
                            CargarDataGridViewAlumnos();
                        }
                    }
                    else
                    {
                        throw new Exception("Debe seleccionar una carrera y una materia");
                    }
                }
                else
                {
                    throw new Exception("La tabla está vacía o no hay ninguna fila seleccionada.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Limpiar();
        }

        private void buttonListadoDeMaterias_Click(object sender, EventArgs e)
        {
            groupBoxMaterias.Visible = true;
            groupBoxAlumnos.Visible = false;
        }

        private void buttonListadoDeAlumnos_Click(object sender, EventArgs e)
        {
            groupBoxMaterias.Visible = false;
            groupBoxAlumnos.Visible = true;
        }

        private void OcultarGroupBox()
        {
            groupBoxMaterias.Visible = false;
            groupBoxAlumnos.Visible = false;
        }

        private void buttonAgregarProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                if (BEMateria != null)
                {
                    if (BEMateria.Profesor != null)
                    {
                        MessageBox.Show("Ya tiene un profesor asignado");
                    }
                    else
                    {
                        FrmMateriaAgregarProfesor frmMateriaAgregarProfesor = new FrmMateriaAgregarProfesor(BEMateria, BECarrera);
                        frmMateriaAgregarProfesor.ShowDialog();

                        CargarDataGridView();
                        CargarDataGridViewMaterias();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void buttonQuitarProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                if (BEMateria != null)
                {
                    DialogResult resultado = MessageBox.Show("¿Desea quitar el profesor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        BLLMateria.QuitarProfesor(BECarrera, BEMateria);
                    }
                    CargarDataGridView();
                    CargarDataGridViewMaterias();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion


    }
}
