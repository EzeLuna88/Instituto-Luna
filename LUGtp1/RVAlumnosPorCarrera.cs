using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using Microsoft.Reporting.WinForms;

namespace LUGtp1
{
    public partial class RVAlumnosPorCarrera : Form
    {
        BLLCarrera bllCarrera;
        BECarrera beCarrera;
        BLLAlumno bllAlumno;

        public RVAlumnosPorCarrera()
        {
            bllCarrera = new BLLCarrera();
            beCarrera = new BECarrera();
            bllAlumno = new BLLAlumno();
            InitializeComponent();
            CargarComboBox();
        }

        private void RVAlumnosPorCarrera_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void CargarComboBox()
        {
            try
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = bllCarrera.ListarTodo();
                comboBox1.ValueMember = "Codigo";
                comboBox1.DisplayMember = "Nombre";
                comboBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGenerarInformeCarrerasAlumnos_Click(object sender, EventArgs e)
        {
            beCarrera = (BECarrera)comboBox1.SelectedItem;
            if (beCarrera != null)
            {
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("ReportParameter1", beCarrera.Nombre.ToString()));
                this.reportViewer1.LocalReport.SetParameters(reportParameters);

                var dataSource = new ReportDataSource("DataSet1", bllAlumno.CargarAlumnosPorCarrera(beCarrera));

                // Limpiar y agregar la fuente de datos
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);

                this.reportViewer1.RefreshReport();

               
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una carrera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bEAlumnoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
