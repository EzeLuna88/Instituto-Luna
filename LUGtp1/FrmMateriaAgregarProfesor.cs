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
    public partial class FrmMateriaAgregarProfesor : Form
    {
        BEMateria beMateria;
        BEProfesor beProfesor;
        BLLMateria bllMateria;
        BECarrera beCarrera;
        BLLProfesor bllProfesor;

        public FrmMateriaAgregarProfesor(BEMateria materia, BECarrera carrera)
        {
            beMateria = materia;
            beProfesor = new BEProfesor();
            beCarrera = carrera;
            bllMateria = new BLLMateria();
            bllProfesor = new BLLProfesor();
            InitializeComponent();
            CargarDataGrid();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                beProfesor = (BEProfesor)this.dataGridViewProfesor.CurrentRow.DataBoundItem;
                bllMateria.GuardarProfesor(beMateria, beCarrera, beProfesor);
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void CargarDataGrid()
        {
            try
            {
                if (bllProfesor.ListarTodo() != null)
                {
                    dataGridViewProfesor.DataSource = null;

                    var profesores = bllProfesor.ListarTodo().OrderBy(m => m.Apellido).ToList();
                    dataGridViewProfesor.DataSource = profesores;
                    dataGridViewProfesor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridViewProfesor.Columns["Apellido"].DisplayIndex = 0;
                    dataGridViewProfesor.Columns["Nombre"].DisplayIndex = 1;
                    dataGridViewProfesor.Font = new Font("Segoe UI", 10);
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
