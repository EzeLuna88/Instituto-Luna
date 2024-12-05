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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LUGtp1
{
    public partial class FrmCarreraAgregarAlumno : Form
    {
        BLLAlumno bllAlumno;
        BLLCarrera bllCarrera;
        BECarrera beCarrera;
        BEAlumno beAlumno;
        BindingSource bindingSourceAlumnos = new BindingSource();
        public FrmCarreraAgregarAlumno(BECarrera carrera)
        {
            InitializeComponent();
            bllAlumno = new BLLAlumno();
            bllCarrera = new BLLCarrera();
            beCarrera = carrera;
            beAlumno = new BEAlumno();
            CargarDataGridView();
        }




        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                beAlumno = (BEAlumno)this.dataGridViewAlumnos.CurrentRow.DataBoundItem;
                if (beCarrera.ListaAlumnos != null)
                {
                    if (beCarrera.ListaAlumnos.Find(x => x.Codigo == beAlumno.Codigo) != null)
                    { throw new Exception("El alumno se encuentra cargado en la carrera"); }
                    else
                    {
                        bllCarrera.AgregarAlumno(beCarrera, beAlumno);
                        this.Close();
                    }
                }
                else
                {
                    bllCarrera.AgregarAlumno(beCarrera, beAlumno);
                    this.Close();
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

        void CargarDataGridView()
        {

            dataGridViewAlumnos.DataSource = null;
            var listaAlumnos = bllAlumno.ListarTodo().OrderBy(x => x.Apellido).ToList();
            dataGridViewAlumnos.DataSource = listaAlumnos;
            dataGridViewAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DataGridViewColumn nombreColumna = dataGridViewAlumnos.Columns["Nombre"];
            DataGridViewColumn apellidoColumna = dataGridViewAlumnos.Columns["Apellido"];
            DataGridViewColumn codigoColumna = dataGridViewAlumnos.Columns["Codigo"];
            DataGridViewColumn becadoColumna = dataGridViewAlumnos.Columns["Becado"];
            DataGridViewColumn matriculaPagadaColumna = dataGridViewAlumnos.Columns["MatriculaPagada"];
            dataGridViewAlumnos.Columns["Dni"].DisplayIndex = 2;
            dataGridViewAlumnos.Columns["Email"].DisplayIndex = 3;
            dataGridViewAlumnos.Font = new Font("Segoe UI", 10);


            if (dataGridViewAlumnos.Rows.Count > 0)
            {
                dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 0;
                dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 1;

                codigoColumna.Visible = false;
                becadoColumna.Visible = false;
                matriculaPagadaColumna.Visible = false;
                dataGridViewAlumnos.Columns["FechaDeNacimiento"].Visible = false;
                dataGridViewAlumnos.Columns["Direccion"].Visible = false;
                dataGridViewAlumnos.Columns["Telefono"].Visible = false;


            }

        }


        private void textBoxBuscarAlumno_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBoxBuscarAlumno.Text.ToLower();

            if (!string.IsNullOrEmpty(filtro))
            {

                var alumnosFiltrados = bllAlumno.ListarTodo().Where(alumno =>
                    alumno.Nombre.ToLower().Contains(filtro) || alumno.Apellido.ToLower().Contains(filtro)).ToList();


                dataGridViewAlumnos.DataSource = null;
                dataGridViewAlumnos.DataSource = alumnosFiltrados;
                dataGridViewAlumnos.Columns["Apellido"].DisplayIndex = 0;
                dataGridViewAlumnos.Columns["Nombre"].DisplayIndex = 1;
                dataGridViewAlumnos.Columns["Codigo"].Visible = false;
                dataGridViewAlumnos.Columns["Becado"].Visible = false;
                dataGridViewAlumnos.Columns["MatriculaPagada"].Visible = false;
            }
            else
            {
                dataGridViewAlumnos.DataSource = null;
                dataGridViewAlumnos.DataSource = bllAlumno.ListarTodo();
            }

        }

        private void FrmCarreraAgregarAlumno_Load(object sender, EventArgs e)
        {
            textBoxBuscarAlumno.TextChanged += textBoxBuscarAlumno_TextChanged;
        }
    }
}
