using BE;
using BLL;
using System;
using System.Collections;
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

    public partial class FrmNotasAlumnos : Form
    {
        BEProfesor beProfesor;
        BLLProfesor bllProfesor;
        BECarrera beCarrera;
        BEMateria beMateria;
        BLLNota bllNota;
        BENota beNota;
        public FrmNotasAlumnos(BEProfesor profesor)
        {
            beProfesor = profesor;
            beCarrera = new BECarrera();
            bllProfesor = new BLLProfesor();
            bllNota = new BLLNota();
            beMateria = new BEMateria();
            beNota = new BENota();
            InitializeComponent();
            CargarComboBox();
        }

        void CargarComboBox()
        {
            try
            {
                comboBoxCarreraProfesor.DataSource = null;
                comboBoxCarreraProfesor.DataSource = bllProfesor.ListarCarreras(beProfesor);
                comboBoxCarreraProfesor.ValueMember = "Codigo";
                comboBoxCarreraProfesor.DisplayMember = "Nombre";
                comboBoxCarreraProfesor.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        void CargarComboBoxMaterias()
        {
            try
            {
                comboBoxMateriaProfesor.DataSource = null;
                comboBoxMateriaProfesor.DataSource = bllProfesor.ListarMaterias(beProfesor, beCarrera);
                comboBoxMateriaProfesor.ValueMember = "Codigo";
                comboBoxMateriaProfesor.DisplayMember = "Nombre";
                comboBoxMateriaProfesor.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }



        private void comboBoxCarreraProfesor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            beCarrera = (BECarrera)comboBoxCarreraProfesor.SelectedItem;

            CargarComboBoxMaterias();
        }

        private void buttonMostrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                beMateria = comboBoxMateriaProfesor.SelectedItem as BEMateria;


                if (dataGridViewAlumnos.Columns["Parcial 1"] != null)
                {
                    dataGridViewAlumnos.Columns.Remove("Parcial 1");
                }

                dataGridViewAlumnos.DataSource = null;
                DataTable dt = bllNota.Listar(beCarrera, beMateria);
                dataGridViewAlumnos.DataSource = dt;
                dataGridViewAlumnos.ReadOnly = false;
                dataGridViewAlumnos.Columns["Nombre"].ReadOnly = true;
                dataGridViewAlumnos.Columns["Apellido"].ReadOnly = true;
                dataGridViewAlumnos.Columns["Dni"].ReadOnly = true;
                dataGridViewAlumnos.Columns["Parcial 1"].ValueType = typeof(decimal);
                dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 0;
                dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 1;
                dataGridViewAlumnos.Columns["Codigo"].Visible = false;


                dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridViewAlumnos.AllowUserToAddRows = false;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            List<BENota> listaNotas = new List<BENota>();
            foreach (DataGridViewRow fila in dataGridViewAlumnos.Rows)
            {
                BENota nota = new BENota();
                nota.CodigoCarrera = beCarrera.Codigo;
                nota.CodigoMateria = beMateria.Codigo;
                nota.CodigoAlumno = Convert.ToInt32(fila.Cells["Codigo"].Value);
                if (fila.Cells["Parcial 1"].Value != null && !string.IsNullOrWhiteSpace(fila.Cells["Parcial 1"].Value.ToString()))
                {
                    nota.NotaParcial1 = Convert.ToDecimal(fila.Cells["Parcial 1"].Value);
                }
                else
                {
                    nota.NotaParcial1 = 0;
                }
                if (dataGridViewAlumnos.Columns.Contains("Parcial 2"))
                {
                    if (fila.Cells["Parcial 2"].Value != null && !string.IsNullOrWhiteSpace(fila.Cells["Parcial 2"].Value.ToString()))
                    {
                        nota.NotaParcial2 = Convert.ToDecimal(fila.Cells["Parcial 2"].Value);
                    }
                    else
                    {
                        nota.NotaParcial2 = 0;

                        listaNotas.Add(nota);
                    }
                }
                else
                { nota.NotaParcial2 = 0; }



                listaNotas.Add(nota);

            }
            bllNota.GuardarNotas(listaNotas);
            MessageBox.Show("Se guardo la nota correctamente");

            if (listaNotas.Count > 0)
            {
                buttonMostrar_Click_1(sender, e);
            }
        }
    }
}
