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
    public partial class FrmAlumnoABM : Form
    {

        BEAlumno beAlumno;
        BLLAlumno bllAlumno;
        public FrmAlumnoABM()
        {
            InitializeComponent();
            beAlumno = new BEAlumno();
            bllAlumno = new BLLAlumno();
            CargarDataGridView();
        }




        private void buttonAlumnoAlta_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAlumnoAlta frmAltaAlumno = new FrmAlumnoAlta();
                frmAltaAlumno.ShowDialog();
                CargarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void CargarDataGridView()
        {
            uC_dgv1.dataGridView1.DataSource = null;

            var listaAlumnos = bllAlumno.ListarTodo();
            if (listaAlumnos != null)
            {
                var listaAlumnosOrdenada = listaAlumnos.OrderBy(alumno => alumno.Apellido).ToList();
                uC_dgv1.dataGridView1.DataSource = listaAlumnosOrdenada;
                uC_dgv1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                uC_dgv1.dataGridView1.Font = new Font("Segoe UI", 10);
                uC_dgv1.dataGridView1.Size = new Size(1117, 260);
                if (uC_dgv1.dataGridView1.Rows.Count > 0)
                {
                    DataGridViewColumn nombreColumna = uC_dgv1.dataGridView1.Columns["Nombre"];
                    DataGridViewColumn apellidoColumna = uC_dgv1.dataGridView1.Columns["Apellido"];
                    DataGridViewColumn codigoColumna = uC_dgv1.dataGridView1.Columns["Codigo"];



                    uC_dgv1.dataGridView1.Columns["Apellido"].DisplayIndex = 0;
                    uC_dgv1.dataGridView1.Columns["Nombre"].DisplayIndex = 1;

                    uC_dgv1.dataGridView1.Columns["FechaDeNacimiento"].HeaderText = "Fecha de nacimiento";
                    uC_dgv1.dataGridView1.Columns["MatriculaPagada"].HeaderText = "Matricula pagada";

                    codigoColumna.Visible = false;

                }
                uC_dgv1.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            }

        }

        public void Asignar()
        {
            beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;

            beAlumno.Codigo = Convert.ToInt32(textBoxAlumnoCodigo.Text);
            beAlumno.Dni = Convert.ToInt32(textBoxAlumnoDni.Text);
            beAlumno.Nombre = textBoxAlumnoNombre.Text;
            beAlumno.Apellido = textBoxAlumnoApellido.Text;
            beAlumno.FechaDeNacimiento = Convert.ToDateTime(textBoxAlumnoFechaDeNacimiento.Text);
            beAlumno.Email = textBoxAlumnoEmail.Text;
            beAlumno.Telefono = textBoxAlumnoTelefono.Text;
            beAlumno.Direccion = textBoxAlumnoDireccion.Text;
            if (radioButtonAlumnoBecado.Checked)
            {
                beAlumno.Becado = true;
            }
            else if (radioButtonAlumnoRegular.Checked)
            {
                beAlumno.Becado = false;
            }
            bllAlumno.Guardar(beAlumno);
        }



        private void buttonAlumnoBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                DialogResult respuesta;
                respuesta = MessageBox.Show("Confirmar la baja del alumno", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;

                    bool bajaAlumno = bllAlumno.Baja(beAlumno);
                    if (bajaAlumno)
                    {
                        CargarDataGridView();
                        Limpiar();

                    }

                    else
                    {
                        MessageBox.Show("Error. El alumno esta asociado a alguna carrera");
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
                textBoxAlumnoCodigo.Text = string.Empty;
                textBoxAlumnoDni.Text = string.Empty;
                textBoxAlumnoNombre.Text = string.Empty;
                textBoxAlumnoApellido.Text = string.Empty;
                textBoxAlumnoFechaDeNacimiento.Text = string.Empty;
                textBoxAlumnoEmail.Text = string.Empty;
                textBoxAlumnoTelefono.Text = string.Empty;
                textBoxAlumnoDireccion.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonAlumnoModificacion_Click(object sender, EventArgs e)
        {
            try
            {

                bool resultadoDni = Regex.IsMatch(textBoxAlumnoDni.Text, "^[0-9]{0,8}$");
                if (!resultadoDni)
                { labelErrorDni.Text = "El Dni no tiene formato correcto"; }
                else
                {
                    bool resultadoNombre = Regex.IsMatch(textBoxAlumnoNombre.Text, @"^[a-zA-Záéíóú\s]+$");
                    if (!resultadoNombre)
                    { labelErrorNombre.Text = "El nombre tiene formato incorrecto"; }
                    else
                    {
                        bool resultadoApellido = Regex.IsMatch(textBoxAlumnoApellido.Text, @"^[a-zA-Záéíóú\s]+$");
                        if (!resultadoApellido)
                        { labelErrorApellido.Text = "El apellido tiene formato incorrecto"; }
                        else
                        {

                            {
                                bool resultadoEmail = Regex.IsMatch(textBoxAlumnoEmail.Text, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
                                if (!resultadoEmail)
                                { labelErrorEmail.Text = "El email tiene formato incorrecto"; }
                                else
                                {
                                    bool resultadoTelefono = Regex.IsMatch(textBoxAlumnoTelefono.Text, "^[0-9]+$");
                                    if (!resultadoTelefono)
                                    { labelErrorTelefono.Text = "El telefono tiene formato incorrecto"; }
                                    else
                                    {

                                        DialogResult resultado = MessageBox.Show("¿Confirmar la modificación del alumno?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (resultado == DialogResult.Yes)
                                        {

                                            Asignar();
                                            beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;

                                            bllAlumno.Guardar(beAlumno);
                                            MessageBox.Show("Se modifico exitosamente");

                                            CargarDataGridView();
                                            Limpiar();
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void textBoxAlumnoDni_TextChanged(object sender, EventArgs e)
        {
            labelErrorDni.Text = String.Empty;
        }

        private void textBoxAlumnoNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }

        private void textBoxAlumnoApellido_TextChanged(object sender, EventArgs e)
        {
            labelErrorApellido.Text = String.Empty;
        }

        private void textBoxAlumnoFechaDeNacimiento_TextChanged(object sender, EventArgs e)
        {
            labelErrorFechaNacimiento.Text = String.Empty;
        }

        private void textBoxAlumnoEmail_TextChanged(object sender, EventArgs e)
        {
            labelErrorDni.Text = String.Empty;

        }

        private void textBoxAlumnoTelefono_TextChanged(object sender, EventArgs e)
        {
            labelErrorTelefono.Text = String.Empty;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            BEAlumno beAlumno;

            beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;

            beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;
            textBoxAlumnoCodigo.Text = beAlumno.Codigo.ToString();
            textBoxAlumnoDni.Text = beAlumno.Dni.ToString();
            textBoxAlumnoNombre.Text = beAlumno.Nombre.ToString();
            textBoxAlumnoApellido.Text = beAlumno.Apellido.ToString();
            textBoxAlumnoFechaDeNacimiento.Text = beAlumno.FechaDeNacimiento.ToString("dd/MM/yyyy");
            textBoxAlumnoEmail.Text = beAlumno.Email.ToString();
            textBoxAlumnoTelefono.Text = beAlumno.Telefono.ToString();
            textBoxAlumnoDireccion.Text = beAlumno.Direccion.ToString();
            if (beAlumno.Becado)
            {

                radioButtonAlumnoBecado.Checked = true;
                radioButtonAlumnoRegular.Checked = false;

            }
            else
            {
                radioButtonAlumnoBecado.Checked = false;
                radioButtonAlumnoRegular.Checked = true;
            }







        }


        private void textBoxAlumnoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxAlumnoDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxAlumnoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxAlumnoTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxBuscarAlumno_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBoxBuscarAlumno.Text.ToLower();

            if (!string.IsNullOrEmpty(filtro))
            {

                var alumnosFiltrados = bllAlumno.ListarTodo().Where(alumno =>
                    alumno.Nombre.ToLower().Contains(filtro) || alumno.Apellido.ToLower().Contains(filtro)).ToList();


                uC_dgv1.dataGridView1.DataSource = null;
                uC_dgv1.dataGridView1.DataSource = alumnosFiltrados;
                uC_dgv1.dataGridView1.Columns["Apellido"].DisplayIndex = 0;
                uC_dgv1.dataGridView1.Columns["Nombre"].DisplayIndex = 1;
                uC_dgv1.dataGridView1.Columns["Codigo"].Visible = false;
                uC_dgv1.dataGridView1.Columns["Becado"].Visible = false;
                uC_dgv1.dataGridView1.Columns["MatriculaPagada"].Visible = false;
            }
            else
            {
                CargarDataGridView();
            }

        }

        private void FrmAbmAlumno_Load(object sender, EventArgs e)
        {
            textBoxBuscarAlumno.TextChanged += textBoxBuscarAlumno_TextChanged;
        }
    }
}
