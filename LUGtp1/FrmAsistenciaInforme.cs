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
    public partial class FrmAsistenciaInforme : Form
    {
        readonly BLLProfesor bllProfesor;
        readonly BEProfesor beProfesor;
        BECarrera beCarrera;
        BEMateria beMateria;

        readonly BLLCarrera bllCarrera;
        readonly BLLMateria BLLMateria;
        DataTable dataTable;
        public FrmAsistenciaInforme()
        {
            InitializeComponent();
            beProfesor = new BEProfesor();
            beCarrera = new BECarrera();
            beMateria = new BEMateria();
            bllProfesor = new BLLProfesor();
            bllCarrera = new BLLCarrera();
            BLLMateria = new BLLMateria();

            CargarComboBox();

        }

        void CargarComboBox()
        {
            try
            {
                comboBoxCarrera.DataSource = null;
                var carrerasOrdenadas = bllCarrera.ListarTodo()
            .OrderBy(c => c.Nombre)
            .ToList();

                comboBoxCarrera.DataSource = carrerasOrdenadas;
                comboBoxCarrera.ValueMember = "Codigo";
                comboBoxCarrera.DisplayMember = "Nombre";
                comboBoxCarrera.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ComboBoxCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            beCarrera = (BECarrera)comboBoxCarrera.SelectedItem;

            CargarComboBoxMaterias();
        }

        void CargarComboBoxMaterias()
        {
            try
            {
                comboBoxMateria.DataSource = null;
                var materiasOrdenadas = bllCarrera.ListarMaterias(beCarrera)
            .OrderBy(m => m.Nombre)
            .ToList();
                comboBoxMateria.DataSource = materiasOrdenadas;
                comboBoxMateria.ValueMember = "Codigo";
                comboBoxMateria.DisplayMember = "Nombre";
                comboBoxMateria.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void ButtonMostrar_Click(object sender, EventArgs e)
        {
            beMateria = comboBoxMateria.SelectedItem as BEMateria;
            if (beMateria != null)
            {
                dataTable = BLLMateria.ListarAlumnosAsistenciaNotas(beCarrera, beMateria);


                if (!dataTable.Columns.Contains("Promedio Parciales"))
                {
                    dataTable.Columns.Add("Promedio Parciales", typeof(double));
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    double parcial1 = row.Field<double>("Parcial 1");
                    double parcial2 = row.Field<double>("Parcial 2");
                    if (parcial2 != 0)
                    {
                        double promedio = (parcial1 + parcial2) / 2;
                        row["Promedio Parciales"] = promedio;
                    }
                    else
                    {
                        row["Promedio Parciales"] = parcial1;
                    }
                }


                dataGridViewAlumnos.DataSource = dataTable;
                dataGridViewAlumnos.Columns["Parcial 1"].Visible = false;
                dataGridViewAlumnos.Columns["Parcial 2"].Visible = false;
                dataGridViewAlumnos.Columns["Codigo"].Visible = false;
                dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 0;
                dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 1;
                ConfigurarDataGridViewVisualizacion();
            }
        }

        private void ConfigurarDataGridViewVisualizacion()
        {
            if (dataGridViewAlumnos.DataSource != null)
            {
                dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewAlumnos.ClearSelection();
                dataGridViewAlumnos.ReadOnly = true;


            }
        }

        private void dataGridViewAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridViewAlumnos.Rows[e.RowIndex];

                double porcentajeAsistencia = Convert.ToDouble(selectedRow.Cells["Porcentaje Asistencia"].Value);
                double parcial1 = Convert.ToDouble(selectedRow.Cells["Parcial 1"].Value);
                double parcial2 = Convert.ToDouble(selectedRow.Cells["Parcial 2"].Value);
                double promedioParciales = Convert.ToDouble(selectedRow.Cells["Promedio Parciales"].Value);

                if (parcial1 == 0 || parcial2 == 0)
                {
                    if (porcentajeAsistencia < 70)
                    {
                        labelInforme.Text = "No está habilitado para Final. Debe rendir parcial y no cumple con la asistencia mínima";
                        labelInforme.ForeColor = Color.Red;
                    }
                    else
                    {
                        labelInforme.Text = "No está habilitado para Final. Debe rendir parcial";
                        labelInforme.ForeColor = Color.Red;
                    }
                }
                else if (promedioParciales < 7)
                {
                    if (porcentajeAsistencia < 70)
                    {
                        labelInforme.Text = "No está habilitado para Final. No cumple con el promedio minimo de nota (7) ni con la asistencia minima";
                        labelInforme.ForeColor = Color.Red;
                    }
                    else
                    {
                        labelInforme.Text = "No está habilitado para Final. No cumple con el promedio minimo de nota (7)";
                        labelInforme.ForeColor = Color.Red;
                    }
                }
                else if (porcentajeAsistencia < 70)
                {
                    labelInforme.Text = "No está habilitado para Final. No cumple con la asistencia mínima";
                    labelInforme.ForeColor = Color.Red;
                }
                else
                {
                    labelInforme.Text = "Habilitado para final";
                    labelInforme.ForeColor = Color.Blue;
                }
            }
        }
    }
}
