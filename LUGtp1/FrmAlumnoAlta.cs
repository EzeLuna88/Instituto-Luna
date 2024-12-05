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
    public partial class FrmAlumnoAlta : Form
    {
        BEAlumno beAlumno;
        BLLAlumno bllAlumno;
        BLLCarrera bllCarrera;
        bool becado=false;
        public FrmAlumnoAlta()
        {
            InitializeComponent();
            bllAlumno = new BLLAlumno();
            bllCarrera = new BLLCarrera();
        }



        private void buttonAlumnoAltaAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBoxAlumnoAltaDni.Text, "^[0-9]{1,8}$"))
                {
                    labelErrorDni.Text = "El Dni no tiene formato correcto";
                    return;
                }

                if (!Regex.IsMatch(textBoxAlumnoAltaNombre.Text, @"^[a-zA-Záéíóú\s]+$"))
                {
                    labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxAlumnoAltaApellido.Text, @"^[a-zA-Záéíóú\s]+$"))
                {
                    labelErrorApellido.Text = "El apellido tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxAlumnoAltaEmail.Text, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$"))
                {
                    labelErrorEmail.Text = "El email tiene formato incorrecto";
                    return;
                }

                if (!Regex.IsMatch(textBoxAlumnoAltaTelefono.Text, "^[0-9]+$"))
                {
                    labelErrorTelefono.Text = "El telefono tiene formato incorrecto";
                    return;
                }
                
                if(radioButtonAlumnoAltaBecado.Checked) {becado= true;}
                else if(radioButtonAlumnoAltaRegular.Checked) {becado= false;}
                else { MessageBox.Show("Debe seleccionar si el alumno es regular o becado");
                    return;
                }

                DateTime fechaDeNacimiento = DateTime.ParseExact(textBoxFechaDeNacimiento.Text, "dd/MM/yyyy", null);

                beAlumno = new BEAlumno
                {
                    Dni = Convert.ToInt32(textBoxAlumnoAltaDni.Text),
                    Nombre = textBoxAlumnoAltaNombre.Text,
                    Apellido = textBoxAlumnoAltaApellido.Text,
                    FechaDeNacimiento = fechaDeNacimiento,
                    Email = textBoxAlumnoAltaEmail.Text,
                    Telefono = textBoxAlumnoAltaTelefono.Text,
                    Direccion = textBoxAlumnoAltaDireccion.Text,
                    Becado = becado
                };

                bllAlumno.Guardar(beAlumno);
                this.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlumnoAltaCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void FrmAltaAlumno_Load(object sender, EventArgs e)
        {

        }

        private void textBoxAlumnoAltaDni_TextChanged(object sender, EventArgs e)
        {
            labelErrorDni.Text = String.Empty;
        }

        private void textBoxAlumnoAltaNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }

        private void textBoxAlumnoAltaApellido_TextChanged(object sender, EventArgs e)
        {
            labelErrorApellido.Text = String.Empty;
        }

        private void textBoxAlumnoAltaFechaDeNacimiento_TextChanged(object sender, EventArgs e)
        {
            labelErrorFechaNacimiento.Text = String.Empty;
        }

        private void textBoxAlumnoAltaEmail_TextChanged(object sender, EventArgs e)
        {
            labelErrorEmail.Text = String.Empty;
        }

        private void textBoxAlumnoAltaTelefono_TextChanged(object sender, EventArgs e)
        {
            labelErrorTelefono.Text = String.Empty;
        }

        private void textBoxAlumnoAltaDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxAlumnoAltaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxAlumnoAltaApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBoxAlumnoAltaTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }
    }

}
