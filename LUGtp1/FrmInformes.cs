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
    public partial class FrmInformes : Form
    {
        public FrmInformes()
        {
            InitializeComponent();
        }

        private void buttonGenerarInforme_Click(object sender, EventArgs e)
        {
            if (radioButtonRegulares.Checked == true)
            {
                RVRegulares rVRegulares = new RVRegulares();
                rVRegulares.WindowState = FormWindowState.Maximized;
                rVRegulares.Show();
            }
            else if (radioButtonAlumnosBecados.Checked == true)
            {
                RVBecados rVBecados = new RVBecados();
                rVBecados.WindowState = FormWindowState.Maximized;
                rVBecados.Show();
            }
            else if (radioButtonMatriculasPagadas.Checked == true)
            {
                RVMatriculasPagadas rVMatriculasPagadas = new RVMatriculasPagadas();
                rVMatriculasPagadas.WindowState = FormWindowState.Maximized;
                rVMatriculasPagadas.Show();
            }
            else if (radioButtonMatriculasNoPagadas.Checked == true)
            {
                RVMatriculasNoPagadas rVMatriculasNoPagadas = new RVMatriculasNoPagadas();
                rVMatriculasNoPagadas.WindowState = FormWindowState.Maximized;
                rVMatriculasNoPagadas.Show();
            }
        }

        private void buttonGenerarInformeCarrerasAlumnos_Click(object sender, EventArgs e)
        {
            RVAlumnosPorCarrera rVAlumnosPorCarrera = new RVAlumnosPorCarrera();
            rVAlumnosPorCarrera.WindowState = FormWindowState.Maximized;
            rVAlumnosPorCarrera.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RVRegulares rVRegulares = new RVRegulares();
            rVRegulares.WindowState = FormWindowState.Maximized;
            rVRegulares.Show();
        }
    }

   
}
