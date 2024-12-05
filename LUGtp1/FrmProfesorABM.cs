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
using Security;

namespace LUGtp1
{
    public partial class FrmProfesorABM : Form
    {
        BEProfesor beProfesor;
        BLLProfesor bllProfesor;
        BLLUsuario bllUsuario;
        BEUsuario beUsuario;
        BEUsuario usuarioDatosViejos;
        BEProfesor profesorDatosViejos;
        #region "constructor"
        public FrmProfesorABM()
        {
            InitializeComponent();
            beProfesor = new BEProfesor();
            bllProfesor = new BLLProfesor();
            bllUsuario = new BLLUsuario();
            beUsuario = new BEUsuario();
            usuarioDatosViejos = new BEUsuario();
            profesorDatosViejos = new BEProfesor();
            CargarDataGrid();

        }
        #endregion



        #region "metodos"

        public void CargarDataGrid()
        {

            try
            {
                var listaProfesores = bllProfesor.ListarTodo();
                if(listaProfesores!=null)
                { 
                    var listaOrdenada = listaProfesores.OrderBy(profesor => profesor.Apellido).ToList();
                    uC_dgv1.dataGridView1.DataSource = null;
                    uC_dgv1.dataGridView1.DataSource = listaOrdenada;
                    uC_dgv1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    uC_dgv1.dataGridView1.CellClick += dataGridViewProfesor_CellClick;
                    uC_dgv1.dataGridView1.Font = new Font("Segoe UI", 10);
                    uC_dgv1.dataGridView1.Size = new Size(764, 280);
                }
                
                if (uC_dgv1.dataGridView1.Rows.Count > 0)
                {
                    DataGridViewColumn nombreColumna = uC_dgv1.dataGridView1.Columns["Nombre"];
                    DataGridViewColumn apellidoColumna = uC_dgv1.dataGridView1.Columns["Apellido"];
                    uC_dgv1.dataGridView1.Columns["Apellido"].DisplayIndex = 0;
                    uC_dgv1.dataGridView1.Columns["Nombre"].DisplayIndex = 1;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewProfesor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                profesorDatosViejos = (BEProfesor)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;
                textBoxProfesorCodigo.Text = profesorDatosViejos.Codigo.ToString();
                textBoxProfesorNombre.Text = profesorDatosViejos.Nombre;
                textBoxProfesorApellido.Text = profesorDatosViejos.Apellido;
                textBoxProfesorDni.Text = profesorDatosViejos.Dni.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void traerObjeto(Object o)
        {
            beProfesor = (BEProfesor)o;
            textBoxProfesorApellido.Text = beProfesor.Apellido;
        }

        private void dataGridViewProfesor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                beProfesor = (BEProfesor)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;
                textBoxProfesorCodigo.Text = beProfesor.Codigo.ToString();
                textBoxProfesorNombre.Text = beProfesor.Nombre;
                textBoxProfesorApellido.Text = beProfesor.Apellido;
                textBoxProfesorDni.Text = beProfesor.Dni.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonProfesorModificacion_Click(object sender, EventArgs e)
        {
            try
            {

                if (!Regex.IsMatch(textBoxProfesorNombre.Text, @"^[a-zA-ZáéíóúñÑ\s]+$"))
                {
                    labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxProfesorApellido.Text, @"^[a-zA-ZáéíóúñÑ\s]+$"))
                {
                    labelErrorApellido.Text = "El apellido tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxProfesorDni.Text, "^[0-9]{1,8}$"))
                {
                    labelErrorDni.Text = "El Dni no tiene formato correcto";
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Confirmar la modificación del profesor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Asignar();
                    bllProfesor.Guardar(beProfesor);
                    
                    CrearUsuario(beProfesor);
                    CrearUsuarioViejo(profesorDatosViejos);
                    bllUsuario.ModificarUsuario(beUsuario, usuarioDatosViejos);
                    MessageBox.Show("Se ha modificado exitosamente");
                    CargarDataGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CrearUsuario(BEProfesor beProfesor)
        {
            beUsuario.NombreDeUsuario = beProfesor.Nombre.ToLower() + beProfesor.Apellido.ToLower();
            beUsuario.Contrasenia = Encriptar.Encriptacion(beProfesor.Dni.ToString());
            beUsuario.Nombre = beProfesor.Nombre;
            beUsuario.Apellido = beProfesor.Apellido;
            beUsuario.Dni = beProfesor.Dni;
        }

        private void CrearUsuarioViejo(BEProfesor beProfesor)
        {
            usuarioDatosViejos.NombreDeUsuario = beProfesor.Nombre.ToLower() + beProfesor.Apellido.ToLower();
            usuarioDatosViejos.Contrasenia = Encriptar.Encriptacion(beProfesor.Dni.ToString());
            usuarioDatosViejos.Nombre = beProfesor.Nombre;
            usuarioDatosViejos.Apellido = beProfesor.Apellido;
            usuarioDatosViejos.Dni = beProfesor.Dni;
        }

        public void Asignar()
        {
            try
            {
                beProfesor.Codigo = Convert.ToInt32(textBoxProfesorCodigo.Text);
                beProfesor.Nombre = textBoxProfesorNombre.Text;
                beProfesor.Apellido = textBoxProfesorApellido.Text;
                beProfesor.Dni = Convert.ToInt32(textBoxProfesorDni.Text);
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
                textBoxProfesorCodigo.Text = null;
                textBoxProfesorNombre.Text = null;
                textBoxProfesorApellido.Text = null;
                textBoxProfesorDni.Text = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonProfesorBaja_Click(object sender, EventArgs e)
        {

            try
            {
                Asignar();
                DialogResult respuesta;
                respuesta = MessageBox.Show("Confirmar la baja del profesor", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    bool resultado = bllProfesor.Baja(beProfesor);
                    if (resultado)
                    {
                        CargarDataGrid();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el profesor porque está asociado a una materia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonProfesorAlta_Click(object sender, EventArgs e)
        {

            try
            {
                FrmProfesorAlta frmAltaProfesor = new FrmProfesorAlta();
                frmAltaProfesor.ShowDialog();
                CargarDataGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void textBoxProfesorNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }

        private void textBoxProfesorApellido_TextChanged(object sender, EventArgs e)
        {
            labelErrorApellido.Text = String.Empty;
        }

        private void textBoxProfesorDni_TextChanged(object sender, EventArgs e)
        {
            labelErrorDni.Text = String.Empty;
        }




        #endregion

        
    }
}
