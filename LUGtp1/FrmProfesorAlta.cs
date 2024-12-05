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
using System.Xml.Linq;
using System.Xml;

namespace LUGtp1
{
    public partial class FrmProfesorAlta : Form
    {
        BEProfesor beProfesor;
        BLLProfesor bllProfesor;
        BEUsuario beUsuario;
        BLLUsuario bllUsuario;

        #region "constructor"
        public FrmProfesorAlta()
        {
            InitializeComponent();
            beProfesor = new BEProfesor();
            bllProfesor = new BLLProfesor();
            beUsuario = new BEUsuario();
            bllUsuario = new BLLUsuario();
        }

        #endregion




        #region "metodos"
        private void FrmAltaProfesor_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonMateriaAltaAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBoxProfesorNombre.Text, "^[a-zA-ZñÑ]+$"))
                {
                    labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxProfesorApellido.Text, "^[a-zA-ZñÑ]+$"))
                {
                    labelErrorApellido.Text = "El apellido tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxProfesorDni.Text, "^[0-9]{1,8}$"))
                {
                    labelErrorDni.Text = "El Dni no tiene formato correcto";
                    return;
                }

                beProfesor.Nombre = textBoxProfesorNombre.Text;
                beProfesor.Apellido = textBoxProfesorApellido.Text;
                beProfesor.Dni = Convert.ToInt32(textBoxProfesorDni.Text);
                bllProfesor.Guardar(beProfesor);

                CrearUsuario(beProfesor);
                bllUsuario.GuardarUsuario(beUsuario);

                this.Close();
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

        private void buttonMateriaAltaCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region eventos
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

        private void textBoxProfesorNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxProfesorApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxProfesorDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }
    }
}
