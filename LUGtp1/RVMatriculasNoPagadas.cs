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
    public partial class RVMatriculasNoPagadas : Form
    {
        BLLAlumno bLLAlumno;
        public RVMatriculasNoPagadas()
        {
            bLLAlumno = new BLLAlumno();
            InitializeComponent();
        }

        private void RVMatriculasNoPagadas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            CargarReporte();
        }

        private void CargarReporte()
        {
            this.reportViewer1.LocalReport.DataSources[0].Value = bLLAlumno.CargarMatriculasNoPagadas();
            this.reportViewer1.RefreshReport();
        }
    }
}
