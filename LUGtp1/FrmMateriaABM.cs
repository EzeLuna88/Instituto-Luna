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
    public partial class FrmMateriaABM : Form
    {
        #region "campos"
        BEMateria beMateria;
        BLLMateria bllMateria;
        BLLProfesor bllProfesor;
        BEProfesor beProfesor;
        BLLCarrera bllCarrera;
        BECarrera beCarrera;
        #endregion

        #region "constructor"
        public FrmMateriaABM()
        {
            InitializeComponent();
            beMateria = new BEMateria();
            bllMateria = new BLLMateria();
            bllProfesor = new BLLProfesor();
            beProfesor = new BEProfesor();
            bllCarrera = new BLLCarrera();
            beCarrera = new BECarrera();
            CargarDataGridView();
        }
        #endregion



        #region "metodos"
        void CargarDataGridView()
        {

            try
            {
                int selectedRowIndex = -1;

                if (uC_dgv1.dataGridView1.CurrentRow != null)
                {
                    selectedRowIndex = uC_dgv1.dataGridView1.CurrentRow.Index;
                }
                uC_dgv1.dataGridView1.DataSource = null;
                var listaMaterias = bllMateria.ListarTodo();
                if (listaMaterias != null)
                {
                    listaMaterias = listaMaterias.OrderBy(m => m.Nombre).ToList();
                    uC_dgv1.dataGridView1.DataSource = listaMaterias;
                    uC_dgv1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    if (uC_dgv1.dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewColumn profesorColumna = uC_dgv1.dataGridView1.Columns["Profesor"];
                        profesorColumna.Visible = false;


                        uC_dgv1.dataGridView1.SelectionChanged += dataGridViewMateria_SelectionChanged;

                        if (selectedRowIndex >= 0 && selectedRowIndex < uC_dgv1.dataGridView1.Rows.Count)
                        {
                            uC_dgv1.dataGridView1.Rows[selectedRowIndex].Selected = true;
                            beMateria = (BEMateria)uC_dgv1.dataGridView1.Rows[selectedRowIndex].DataBoundItem;
                            textBoxMateriaCodigo.Text = beMateria.Codigo.ToString();
                            textBoxMateriaNombre.Text = beMateria.Nombre;
                            uC_dgv1.dataGridView1.CurrentCell = uC_dgv1.dataGridView1.Rows[selectedRowIndex].Cells[0];

                        }
                    }
                    uC_dgv1.dataGridView1.Font = new Font("Segoe UI", 10);
                    
                    
                }
                uC_dgv1.dataGridView1.Size = new Size(631, 351);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }



        private void dataGridViewMateria_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (uC_dgv1.dataGridView1.CurrentRow != null)
                {
                    beMateria = (BEMateria)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;
                    textBoxMateriaCodigo.Text = beMateria.Codigo.ToString();
                    textBoxMateriaNombre.Text = beMateria.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMateriaAlta_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMateriaAlta frmAltaMateria = new FrmMateriaAlta();
                frmAltaMateria.ShowDialog();
                CargarDataGridView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMateriaModificacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBoxMateriaNombre.Text, @"^[a-zA-Záéíóú\s]+$"))
                {
                    labelErrorNombre.Text = "El nombre tiene formato incorrecto";
                    return;
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("¿Confirmar la modificación de la materia?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        Asignar();
                        bllMateria.Guardar(beMateria);
                        MessageBox.Show("se modifico exitosamente");
                        CargarDataGridView();
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void Asignar()
        {

            try
            {
                beMateria.Codigo = Convert.ToInt32(textBoxMateriaCodigo.Text);
                beMateria.Nombre = textBoxMateriaNombre.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void Limpiar()
        {

            try
            {
                textBoxMateriaCodigo.Text = null;
                textBoxMateriaNombre.Text = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void buttonMateriaBaja_Click(object sender, EventArgs e)
        {

            try
            {
                Asignar();
                DialogResult respuesta;
                respuesta = MessageBox.Show("Confirmar la baja de la materia", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Asignar();
                    var resultado = bllMateria.BajaMateria(beMateria);
                    if (resultado.exito)
                    {
                        MessageBox.Show("Materia eliminada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show(resultado.mensaje);
                    }
                    CargarDataGridView();
                    Limpiar();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void textBoxMateriaNombre_TextChanged(object sender, EventArgs e)
        {
            labelErrorNombre.Text = String.Empty;
        }









        #endregion


    }
}
