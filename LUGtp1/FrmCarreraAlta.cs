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
    public partial class FrmCarreraAlta : Form
    {
        BECarrera beCarrera;
        BLLCarrera bllCarrera;
        #region "constructor"
        public FrmCarreraAlta()
        {
            InitializeComponent();
            beCarrera = new BECarrera();
            bllCarrera = new BLLCarrera();
        }
        #endregion



        #region "metodos"
        private void buttonCarreraAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBoxCarreraNombre.Text, @"^[a-zA-ZáéíóúñÑ\s]+$"))
                {
                    labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                    return;
                }

                beCarrera.Nombre = textBoxCarreraNombre.Text;
                bllCarrera.Guardar(beCarrera);
                MessageBox.Show("La carrera se creó exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void FrmAltaCarrera_Load(object sender, EventArgs e)
        {

        }
        

        private void textBoxCarreraNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }
        #endregion
    }
}
