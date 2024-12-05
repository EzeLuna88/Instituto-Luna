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

namespace LUGtp1
{
    public partial class RVRegulares : Form
    {
        BLLAlumno bLLAlumno;

        public RVRegulares()
        {
            bLLAlumno = new BLLAlumno();
            InitializeComponent();

        }

        private void RVBecados_Load(object sender, EventArgs e)
        {
            
            this.reportViewer1.RefreshReport();
            CargarReporte();
        }

        private void CargarReporte()
        {
            this.reportViewer1.LocalReport.DataSources[0].Value = bLLAlumno.CargarReporteRegulares();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void bEAlumnoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
