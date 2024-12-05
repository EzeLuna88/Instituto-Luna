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
    public partial class FrmMatriculaModificarPrecio : Form
    {
        BEMatricula beMatricula;
        BLLMatricula bllMatricula;
        public FrmMatriculaModificarPrecio()
        {
            InitializeComponent();
            beMatricula = new BEMatricula();
            bllMatricula = new BLLMatricula();
        }

        private void buttonMatriculaCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMatriculaAceptar_Click(object sender, EventArgs e)
        {
            beMatricula.Precio = Convert.ToDecimal(textBoxMatriculaPrecio.Text);
            DialogResult resultado = MessageBox.Show("Desea modificar el precio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                bllMatricula.GuardarPrecio(beMatricula);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void textBoxMatriculaPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
