using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BE;
using BLL;
using Security;

namespace LUGtp1
{
    public partial class FrmLogin : Form
    {
        public BEProfesor Profesor { get; set; }

        BEUsuario beUsuario;
        BLLUsuario bllUsuario;

        public BEUsuario UsuarioLogueado;
        public FrmLogin()
        {
            InitializeComponent();
            beUsuario = new BEUsuario();
            Profesor = new BEProfesor();
            bllUsuario = new BLLUsuario();
            textBoxLoginContrasenia.UseSystemPasswordChar = true;

            this.FormClosing += FrmLogin_FormClosing;

        }

        private void buttonLoginIniciarSesion_Click(object sender, EventArgs e)
        {
            beUsuario.NombreDeUsuario = textBoxLoginUsuario.Text;
            beUsuario.Contrasenia = Encriptar.Encriptacion(textBoxLoginContrasenia.Text);

            BEUsuario usuarioEncontrado = bllUsuario.BuscarUsuario(beUsuario);
            if (usuarioEncontrado != null)
            {
                UsuarioLogueado = usuarioEncontrado;
                MessageBox.Show("Inicio de sesión exitoso");
                DialogResult = DialogResult.OK;

            }
            else
            { labelError.Text = "usuario o contraseña incorrectos"; }

        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void buttonLoginCancelar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuarioNuevo frmNuevoUsuario = new FrmUsuarioNuevo();
            frmNuevoUsuario.ShowDialog();
        }

        private void textBoxLoginUsuario_TextChanged(object sender, EventArgs e)
        {
            labelError.Text = string.Empty;
        }

        private void textBoxLoginContrasenia_TextChanged(object sender, EventArgs e)
        {
            labelError.Text = string.Empty;
        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonLoginIniciarSesion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { buttonLoginIniciarSesion_Click(sender, e); }
        }

        private void buttonMostrarPassword_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxOjoPassword_Click(object sender, EventArgs e)
        {
            if (textBoxLoginContrasenia.UseSystemPasswordChar == false)
            {
                textBoxLoginContrasenia.UseSystemPasswordChar = true;
            }
            else
            { textBoxLoginContrasenia.UseSystemPasswordChar=false; }
        }
    }
}
