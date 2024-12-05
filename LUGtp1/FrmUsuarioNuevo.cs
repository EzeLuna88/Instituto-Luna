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
using Security;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using BLL;

namespace LUGtp1
{
    public partial class FrmUsuarioNuevo : Form
    {
        BEUsuario beUsuario;
        BLLUsuario bllUsuario;

        public FrmUsuarioNuevo()
        {
            InitializeComponent();
            beUsuario = new BEUsuario();
            bllUsuario = new BLLUsuario();
            textBoxContrasenia.UseSystemPasswordChar = true;
            textBoxRepetirContrasenia.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            labelErrorContrasenia.Text = String.Empty;
        }




        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDNI())
                    return;

                if (!ValidarNombre())
                    return;

                if (!ValidarApellido())
                    return;

                if (!ValidarNombreDeUsuario())
                    return;

                if (!ValidarContrasenia())
                    return;

                

                if (bllUsuario.GuardarUsuario(beUsuario))
                {
                    MessageBox.Show("Se creó el usuario con éxito");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarDNI()
        {
            if (!Regex.IsMatch(textBoxDni.Text, "^[0-9]{1,8}$"))
            {
                labelError.Text = "El DNI no tiene el formato correcto";
                return false;
            }

            beUsuario.Dni = Convert.ToInt32(textBoxDni.Text);
            return true;
        }

        private bool ValidarNombre()
        {
            if (!Regex.IsMatch(textBoxNombre.Text, "^[a-zA-Z]+$"))
            {
                labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                return false;
            }

            beUsuario.Nombre = textBoxNombre.Text;
            return true;
        }

        private bool ValidarApellido()
        {
            if (!Regex.IsMatch(textBoxApellido.Text, "^[a-zA-Z]+$"))
            {
                labelErrorApellido.Text = "El apellido tiene formato incorrecto";
                return false;
            }

            beUsuario.Apellido = textBoxApellido.Text;
            return true;
        }

        private bool ValidarNombreDeUsuario()
        {
            if (!Regex.IsMatch(textBoxUsuario.Text, "^[a-z0-9]{5,}$"))
            {
                labelErrorNombreDeUsuario.Text = "El nombre de usuario debe tener al menos 5 caracteres";
                return false;
            }

            beUsuario.NombreDeUsuario = textBoxUsuario.Text;
            return true;
        }

        private bool ValidarContrasenia()
        {
            if (textBoxContrasenia.Text != textBoxRepetirContrasenia.Text)
            {
                labelErrorContrasenia.Text = "La contraseña debe ser igual";
                return false;
            }

            if (!Regex.IsMatch(textBoxContrasenia.Text, "^[^ \t\r\n]{5,20}$"))
            {
                labelErrorContrasenia.Text = "La contraseña debe tener entre 5 y 20 caracteres";
                return false;
            }

            beUsuario.Contrasenia = Encriptar.Encriptacion(textBoxContrasenia.Text);
            return true;
        }

        



        private void textBoxDni_TextChanged(object sender, EventArgs e)
        {
            labelError.Text = String.Empty;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            labelErrorApellido.Text = String.Empty;
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombreDeUsuario.Text = String.Empty;
        }

        private void FrmNuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void textBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }
    }
}
