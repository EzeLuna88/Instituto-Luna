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
using static BE.BEMateria;

namespace LUGtp1
{
    public partial class FrmMateriaAlta : Form
    {
        BEMateria beMateria;
        BLLMateria bllMateria;
        BLLProfesor bllProfesor;

        #region "constructor"
        public FrmMateriaAlta()
        {
            InitializeComponent();
            beMateria = new BEMateria();
            bllMateria = new BLLMateria();
            bllProfesor = new BLLProfesor();
        }
        #endregion



        #region "metodos"
        private void buttonMateriaAltaAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBoxMateriaNombre.Text, @"^[a-zA-Z0-9áéíóúñÑ\s]+$"))
                {
                    labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                    return;
                }

                if (bllMateria.ListarTodo() != null)
                {
                    var listaMaterias = bllMateria.ListarTodo().OrderBy(m => m.Nombre).ToList();

                    if (listaMaterias.Any(m => string.Equals(m.Nombre, textBoxMateriaNombre.Text, StringComparison.OrdinalIgnoreCase)))
                    {
                        labelErrorNombre.Text = "El nombre de la materia ya existe";
                        return;
                    }
                    beMateria.Nombre = textBoxMateriaNombre.Text;
                    bllMateria.Guardar(beMateria);
                    MessageBox.Show("Se creo la materia exitosamente");
                    this.Close();

                }
                beMateria.Nombre = textBoxMateriaNombre.Text;
                bllMateria.Guardar(beMateria);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void buttonMateriaAltaCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAltaMateria_Load(object sender, EventArgs e)
        {

        }


        #endregion

        private void textBoxMateriaNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }


    }
}
