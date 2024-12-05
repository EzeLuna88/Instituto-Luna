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
    public partial class FrmCarreraAgregarMateria : Form
    {
        BLLMateria bllMateria;
        BEMateria beMateria;
        BECarrera beCarrera;
        BLLCarrera bllCarrera;

        public FrmCarreraAgregarMateria(BECarrera Carrera)
        {
            InitializeComponent();
            bllMateria = new BLLMateria();
            beMateria = new BEMateria();
            beCarrera = Carrera;
            bllCarrera = new BLLCarrera();

            CargarComboBox();
        }



        void CargarComboBox()
        {

            try
            {
                comboBoxMaterias.DataSource = null;
                var materiasOrdenadas = bllMateria.ListarTodo().OrderBy(m => m.Nombre).ToList();

                comboBoxMaterias.DataSource = materiasOrdenadas;
                comboBoxMaterias.ValueMember = "Codigo";
                comboBoxMaterias.DisplayMember = "Nombre";
                comboBoxMaterias.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                beMateria = (BEMateria)this.comboBoxMaterias.SelectedItem;
                if (beCarrera.ListaMaterias != null)
                {
                    if (beCarrera.ListaMaterias.Find(x => x.Nombre == beMateria.Nombre) != null)
                    { throw new Exception("La materia se encuentra cargada en la carrera"); }
                    else
                    {
                        if (checkBoxMateriaInicial.Checked)
                        {
                            bool materiaInicial = true;
                            bllCarrera.AgregarMateria(beCarrera, beMateria, materiaInicial);

                            this.Close();
                        }
                        else
                        {
                            bool materiaInicial = false;
                            bllCarrera.AgregarMateria(beCarrera, beMateria, materiaInicial);

                            this.Close();

                        }


                    }
                }
                else
                {
                    throw new Exception("Debe seleccionar una materia");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
