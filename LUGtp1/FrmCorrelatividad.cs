using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LUGtp1
{
    public partial class FrmCorrelatividad : Form
    {
        BLLMateria bllMateria;
        BEMateria beMateriaPrincipal;
        BEMateria beMateriaCorrelativa;
        BECarrera beCarrera;
        public FrmCorrelatividad(BEMateria materia, BECarrera carrera)
        {

            InitializeComponent();
            beMateriaCorrelativa = materia;
            bllMateria = new BLLMateria();
            labelNombreMateria.Text = materia.Nombre;
            beCarrera = carrera;
        }



        private void FrmCorrelatividad_Load(object sender, EventArgs e)
        {
            CargarComboBox();
        }

        void CargarComboBox()
        {

            try
            {
                comboBoxMaterias.DataSource = null;
                comboBoxMaterias.DataSource = beCarrera.ListaMaterias;
                comboBoxMaterias.ValueMember = "Codigo";
                comboBoxMaterias.DisplayMember = "Nombre";
                comboBoxMaterias.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void buttonCorrelativaAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                beMateriaPrincipal = (BEMateria)this.comboBoxMaterias.SelectedItem;
                if (beMateriaPrincipal == beMateriaCorrelativa)
                {
                    MessageBox.Show("Las materias son las mismas");
                }
                else
                {
                    bllMateria.GuardarCorrelatividad(beMateriaPrincipal, beMateriaCorrelativa, beCarrera);
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCorrelativaCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
