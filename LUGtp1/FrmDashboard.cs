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
using System.Windows.Forms.DataVisualization.Charting;
using BE;

namespace LUGtp1
{
    public partial class FrmDashboard : Form
    {
        List<BEComprobante> listaComprobantes;
        BLLCarrera bllCarrera;
        BLLAlumno bllAlumno;
        BLLProfesor bllProfesor;
        BLLMateria bllMateria;
        BLLAsistencia bllAsistencia;
        BLLComprobante bllComprobante;
        BLLNota bllNota;
        BECarrera beCarrera;
        BEAlumno alumnoSeleccionadoAsistencia;
        BECarrera carreraSeleccionadaAsistencia;
        BEMateria materiaSeleccioandaAsistencia;
        List<BENota> notas;

        public FrmDashboard()
        {

            bllCarrera = new BLLCarrera();
            bllAlumno = new BLLAlumno();
            bllProfesor = new BLLProfesor();
            bllMateria = new BLLMateria();
            bllAsistencia = new BLLAsistencia();
            bllNota = new BLLNota();
            bllComprobante = new BLLComprobante();
            beCarrera = new BECarrera();
            alumnoSeleccionadoAsistencia = new BEAlumno();
            carreraSeleccionadaAsistencia = new BECarrera();
            materiaSeleccioandaAsistencia = new BEMateria();
            listaComprobantes = new List<BEComprobante>();
            notas = new List<BENota>();
            InitializeComponent();
            CargarTotalCarreras();
            CargarTotalAlumnos();
            CargarChartTotalesCarrera();
            CargarTotalProfesores();

            CargarComboBox();
            textBoxDesde.KeyPress += new KeyPressEventHandler(textBoxDesde_KeyPress);
            textBoxHasta.KeyPress += new KeyPressEventHandler(textBoxHasta_KeyPress);
            chartAsistencia.Visible = false;
            chartComprobantes.Visible = false;
            chart2.Visible = false;

        }

        void CargarTotalCarreras()
        {
            labelCarrerasTotal.Text = bllCarrera.TotalCarreras().ToString();
        }
        void CargarTotalProfesores()
        {
            labelProfesoresTotal.Text = bllProfesor.TotalProfesores().ToString();
        }
        void CargarTotalAlumnos()
        {
            labelAlumnosTotal.Text = bllAlumno.TotalAlumnos().ToString();
        }
        void CargarChartTotalesCarrera()
        {
            DataView dv = new DataView(bllCarrera.TotalesAlumnosPorCarrera());

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                ChartType = SeriesChartType.Bar,
                IsVisibleInLegend = false
            };

            chart1.Series.Add(series);
            chart1.Series[0].Points.DataBindXY(dv, "Nombre", dv, "Cantidad");

            chart1.ForeColor = Color.Black;
            chart1.Font = new Font("Segoe UI", 8);

            string[] coloresPersonalizados = new string[] { "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F" };
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                if (i < coloresPersonalizados.Length)
                {
                    chart1.Series[0].Points[i].Color = ColorTranslator.FromHtml(coloresPersonalizados[i]);
                }
                else
                {
                    chart1.Series[0].Points[i].Color = Color.FromArgb(255, 0, 0);
                }
            }

            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            chart1.ChartAreas[0].AxisX.Interval = 1;

            series["PixelPointWidth"] = "20";

            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            foreach (DataPoint point in series.Points)
            {
                int index = series.Points.IndexOf(point);
                point.Label = dv.Table.Rows[index]["Nombre"].ToString();
                point.LabelForeColor = Color.Black;
                point.LabelBackColor = Color.Transparent;
                point.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            }

        }
        private void ChartMatriculas()
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chart2.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Matricula pagadas/no pagadas",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Pie
            };

            chart2.Series.Add(series);


            DataTable dt = bllAlumno.TotalesMatricula();
            int valorPagada = 0;
            int valorNoPagada = 0;

            foreach (DataRow dr in dt.Rows)
            {
                valorPagada = Convert.ToInt32(dr["Pagada"]);
                valorNoPagada = Convert.ToInt32(dr["No Pagada"]);

            }

            string[] xNombres = { "Pagadas", "No Pagadas" };
            int[] yValores = { valorPagada, valorNoPagada };

            series.Points.DataBindXY(xNombres, yValores);

            series.Label = "#VALX: #PERCENT{P0} (#VALY)";

            foreach (DataPoint point in series.Points)
            {
                point.LabelForeColor = System.Drawing.Color.Black;
                point.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold);
            }

            Legend legend = new Legend();
            legend.Enabled = false;
            chart2.Legends.Add(legend);

            chart2.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
            chart2.BackColor = System.Drawing.Color.Transparent;

            chart2.ChartAreas[0].RecalculateAxesScale();

            string[] coloresPersonalizados = new string[] { "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F" };
            for (int i = 0; i < chart2.Series[0].Points.Count; i++)
            {
                if (i < coloresPersonalizados.Length)
                {
                    chart2.Series[0].Points[i].Color = ColorTranslator.FromHtml(coloresPersonalizados[i]);
                }
                else
                {
                    chart2.Series[0].Points[i].Color = Color.FromArgb(255, 0, 0);
                }
            }
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);

        }
        private void ChartBecados()
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chart2.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Alumnos Becados/Regulares",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Pie
            };

            chart2.Series.Add(series);


            DataTable dt = bllAlumno.TotalesBecados();
            int becados = 0;
            int regulares = 0;

            foreach (DataRow dr in dt.Rows)
            {
                becados = Convert.ToInt32(dr["Becado"]);
                regulares = Convert.ToInt32(dr["Regular"]);

            }

            string[] xNombres = { "Becados", "Regulares" };
            int[] yValores = { becados, regulares };

            series.Points.DataBindXY(xNombres, yValores);

            series.Label = "#VALX: #PERCENT{P0} (#VALY)";

            foreach (DataPoint point in series.Points)
            {
                point.LabelForeColor = System.Drawing.Color.White;
                point.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            }

            Legend legend = new Legend();
            legend.Enabled = false;
            chart2.Legends.Add(legend);

            chart2.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
            chart2.BackColor = System.Drawing.Color.Transparent;

            chart2.ChartAreas[0].RecalculateAxesScale();

            string[] coloresPersonalizados = new string[] { "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F" };
            for (int i = 0; i < chart2.Series[0].Points.Count; i++)
            {
                if (i < coloresPersonalizados.Length)
                {
                    chart2.Series[0].Points[i].Color = ColorTranslator.FromHtml(coloresPersonalizados[i]);
                }
                else
                {
                    chart2.Series[0].Points[i].Color = Color.FromArgb(255, 0, 0);
                }
            }
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        private void CargarInfomes()
        {
            if (radioButtonBecados.Checked == true)
            {
                ChartBecados();
            }
            else if (radioButtonMatriculas.Checked == true)
            { ChartMatriculas(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CargarInfomes();
            chart2.Visible = true;
        }
        private void ChartRangoEdades(BECarrera carrera)
        {
            DataTable dt = bllAlumno.RangoEdades(carrera);
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;

            foreach (DataRow dr in dt.Rows)
            {
                a = Convert.ToInt32(dr["18-30"]);
                b = Convert.ToInt32(dr["31-40"]);
                c = Convert.ToInt32(dr["41-50"]);
                d = Convert.ToInt32(dr["51-60"]);
                e = Convert.ToInt32(dr["60+"]);

            }

            string[] xNombres = { "18-30", "31-40", "41-50", "51-60", "61-70" };
            int[] yValores = { a, b, c, d, e };

            chart4.Series[0].Points.DataBindXY(xNombres, yValores);
            chart4.Series[0].ChartType = SeriesChartType.Bar;

            chart4.ForeColor = Color.Black;
            chart4.Font = new Font("Segoe UI", 10);
            chart4.Legends[0].Enabled = false;
            string[] coloresPersonalizados = new string[] { "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F" };
            for (int i = 0; i < chart4.Series[0].Points.Count; i++)
            {
                if (i < coloresPersonalizados.Length)
                {
                    chart4.Series[0].Points[i].Color = ColorTranslator.FromHtml(coloresPersonalizados[i]);
                }
                else
                {
                    chart4.Series[0].Points[i].Color = Color.FromArgb(255, 0, 0);
                }
            }
            chart4.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }
        public void CargarComboBox()
        {
            comboBoxAlumno.DataSource = null;
            var alumnos = bllAlumno.ListarTodo();
            if (alumnos != null)
            {
                alumnos.Insert(0, new BEAlumno { Codigo = 0, Apellido = "Todos" });
            }
            comboBoxAlumno.DataSource = alumnos;
            comboBoxAlumno.ValueMember = "Codigo";
            comboBoxAlumno.DisplayMember = "";


            comboBoxCarrera.DataSource = null;
            var carreras = bllCarrera.ListarTodo();
            carreras.Insert(0, new BECarrera { Codigo = 0, Nombre = "Todas" });
            comboBoxCarrera.DataSource = carreras;
            comboBoxCarrera.ValueMember = "Codigo";
            comboBoxCarrera.DisplayMember = "Nombre";
        }
        private void buttonHoy_Click(object sender, EventArgs e)
        {
            List<BEAsistencia> asistenciasDeHoy;
            int codigoCarrera = (comboBoxCarrera.SelectedItem as BECarrera).Codigo;
            if (comboBoxAlumno.SelectedItem != null)
            {
                int codigoAlumno = (comboBoxAlumno.SelectedItem as BEAlumno).Codigo;
                int codigoMateria = 0;
                if (comboBoxMateria.SelectedItem != null)
                {
                    codigoMateria = (comboBoxMateria.SelectedItem as BEMateria).Codigo;
                }
                asistenciasDeHoy = bllAsistencia.AsistenciaHoy();

                if (codigoCarrera != 0)
                {
                    asistenciasDeHoy = asistenciasDeHoy.Where(a => a.IdCarrera == codigoCarrera).ToList();
                }

                if (codigoAlumno != 0)
                {
                    asistenciasDeHoy = asistenciasDeHoy.Where(a => a.IdAlumno == codigoAlumno).ToList();
                }

                if (codigoMateria != 0)
                {
                    asistenciasDeHoy = asistenciasDeHoy.Where(a => a.IdMateria == codigoMateria).ToList();
                }

                ActualizarGraficoAsistencia(asistenciasDeHoy);
                chartAsistencia.Visible = true;

                listaComprobantes.Clear();
                listaComprobantes = bllComprobante.listaComprobantes(DateTime.Now, DateTime.Now);
                ActualizarGraficoFacturacion(listaComprobantes);
            }
        }
        private void comboBoxAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            alumnoSeleccionadoAsistencia = (BEAlumno)comboBoxAlumno.SelectedItem;
            labelParcialesCarrera.Text = carreraSeleccionadaAsistencia.ToString() + " / " + materiaSeleccioandaAsistencia.ToString() + " / " + alumnoSeleccionadoAsistencia.ToString(); ;
            ActualizarGraficoParciales(notas);


        }
        private void comboBoxCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            carreraSeleccionadaAsistencia = (BECarrera)comboBoxCarrera.SelectedItem;
            notas = bllNota.ListarNotas();


            if (carreraSeleccionadaAsistencia.Codigo != 0)
            {
                var materias = bllCarrera.ListarMaterias(carreraSeleccionadaAsistencia);
                if (materias != null)
                {

                    if (!materias.Any(m => m.Codigo == 0))
                    {
                        materias.Insert(0, new BEMateria { Codigo = 0, Nombre = "Todos" });
                    }
                    comboBoxMateria.DataSource = materias;
                }
                var alumnos = carreraSeleccionadaAsistencia.ListaAlumnos;
                if (alumnos != null)
                {

                    if (!alumnos.Any(a => a.Codigo == 0))
                    {
                        alumnos.Insert(0, new BEAlumno { Codigo = 0, Apellido = "Todos" });
                    }
                    comboBoxAlumno.DataSource = alumnos;
                }

            }
            else
            {
                var alumnos = bllAlumno.ListarTodo();
                if (alumnos != null)
                {
                    alumnos.Insert(0, new BEAlumno { Codigo = 0, Apellido = "Todos" });
                }
                comboBoxAlumno.DataSource = alumnos;
                comboBoxAlumno.ValueMember = "Codigo";
                comboBoxAlumno.DisplayMember = "";

                comboBoxMateria.DataSource = null;
               materiaSeleccioandaAsistencia.Codigo = 0;
            }


            labelRangoEdades.Text = carreraSeleccionadaAsistencia.ToString();
            ChartRangoEdades(carreraSeleccionadaAsistencia);
            labelParcialesCarrera.Text = carreraSeleccionadaAsistencia.ToString() + " / " + materiaSeleccioandaAsistencia.ToString() + " / " + alumnoSeleccionadoAsistencia.ToString(); ;
            ActualizarGraficoParciales(notas);

        }
        private void comboBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMateria.DataSource != null)
            {
                materiaSeleccioandaAsistencia = (BEMateria)comboBoxMateria.SelectedItem;
                labelParcialesCarrera.Text = carreraSeleccionadaAsistencia.ToString() + " / " + materiaSeleccioandaAsistencia.ToString() + " / " + alumnoSeleccionadoAsistencia.ToString(); ;
                ActualizarGraficoParciales(notas);
            }
        }
        private void ActualizarGraficoAsistencia(List<BEAsistencia> asistencias)
        {
            chartAsistencia.Series.Clear();
            chartAsistencia.ChartAreas.Clear();
            chartAsistencia.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chartAsistencia.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Asistencias de Hoy",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Pie
            };

            chartAsistencia.Series.Add(series);

            var presentes = asistencias.Count(a => a.Asistencia);
            var ausentes = asistencias.Count(a => !a.Asistencia);

            series.Points.AddXY("Presentes", presentes);
            series.Points.AddXY("Ausentes", ausentes);

            series.Label = "#VALX: #PERCENT{P0} (#VALY)";

            foreach (DataPoint point in series.Points)
            {
                point.LabelForeColor = System.Drawing.Color.White;
                point.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            }

            Legend legend = new Legend();
            legend.Enabled = false;
            chartAsistencia.Legends.Add(legend);

            chartAsistencia.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
            chartAsistencia.BackColor = System.Drawing.Color.Transparent;

            chartAsistencia.ChartAreas[0].RecalculateAxesScale();

            string[] coloresPersonalizados = new string[] { "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F" };
            for (int i = 0; i < chartAsistencia.Series[0].Points.Count; i++)
            {
                if (i < coloresPersonalizados.Length)
                {
                    chartAsistencia.Series[0].Points[i].Color = ColorTranslator.FromHtml(coloresPersonalizados[i]);
                }
                else
                {
                    chartAsistencia.Series[0].Points[i].Color = Color.FromArgb(255, 0, 0);
                }
            }
            chartAsistencia.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }

        private void ActualizarGraficoFacturacion(List<BEComprobante> comprobantes)
        {
            chartComprobantes.Series.Clear();
            chartComprobantes.ChartAreas.Clear();
            chartComprobantes.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chartComprobantes.ChartAreas.Add(chartArea);

            // Series para la cantidad de comprobantes
            var seriesCantidad = new Series
            {
                Name = "CantidadComprobantes",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.StackedColumn
            };

            // Series para el total facturado
            var seriesTotal = new Series
            {
                Name = "TotalFacturado",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.StackedColumn
            };

            chartComprobantes.Series.Add(seriesCantidad);
            chartComprobantes.Series.Add(seriesTotal);

            // Calcular cantidad de comprobantes y total facturado
            int cantidadComprobantes = comprobantes.Count;
            decimal totalFacturado = comprobantes.Sum(c => c.Total);

            // Añadir puntos a las series
            seriesCantidad.Points.AddXY("Cantidad", cantidadComprobantes);
            seriesTotal.Points.AddXY("Total", (double)totalFacturado);

            seriesCantidad.Label = "#VALY";
            seriesTotal.Label = "#VALY";

            foreach (DataPoint point in seriesCantidad.Points)
            {
                point.LabelForeColor = System.Drawing.Color.White;
                point.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            }

            foreach (DataPoint point in seriesTotal.Points)
            {
                point.LabelForeColor = System.Drawing.Color.White;
                point.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            }

            Legend legend = new Legend
            {
                Enabled = false
            };
            chartComprobantes.Legends.Add(legend);

            chartComprobantes.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
            chartComprobantes.BackColor = System.Drawing.Color.Transparent;

            chartComprobantes.ChartAreas[0].RecalculateAxesScale();

            string[] coloresPersonalizados = new string[]
            {
        "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F",
        "#FF6F61", "#D4AC0D", "#58D68D", "#EC7063", "#AF7AC5",
        "#5DADE2", "#F7DC6F", "#E59866", "#73C6B6", "#EB984E"
            };

            for (int i = 0; i < chartComprobantes.Series.Count; i++)
            {
                for (int j = 0; j < chartComprobantes.Series[i].Points.Count; j++)
                {
                    if (j < coloresPersonalizados.Length)
                    {
                        chartComprobantes.Series[i].Points[j].Color = ColorTranslator.FromHtml(coloresPersonalizados[j]);
                    }
                    else
                    {
                        chartComprobantes.Series[i].Points[j].Color = Color.FromArgb(255, 0, 0);
                    }
                }
            }

            chartComprobantes.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            chartComprobantes.Visible = true;
        }

        private void ActualizarGraficoParciales(List<BENota> notas)
        {
            chartParciales.Series.Clear();
            chartParciales.ChartAreas.Clear();
            chartParciales.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chartParciales.ChartAreas.Add(chartArea);

            var notasFiltradas = notas.Where(n =>
                (carreraSeleccionadaAsistencia.Codigo == 0 || n.CodigoCarrera == carreraSeleccionadaAsistencia.Codigo) &&
                (materiaSeleccioandaAsistencia.Codigo == 0 || n.CodigoMateria == materiaSeleccioandaAsistencia.Codigo) &&
                (alumnoSeleccionadoAsistencia.Codigo == 0 || n.CodigoAlumno == alumnoSeleccionadoAsistencia.Codigo))
                .ToList();

            IEnumerable<dynamic> agrupacionNotas;


            if (radioButtonParcial1.Checked)
            {
                agrupacionNotas = notasFiltradas
                    .GroupBy(n => n.NotaParcial1)
                    .Select(g => new { Nota = g.Key, Cantidad = g.Count() })
                    .OrderBy(g => g.Nota)
                    .ToList();
            }
            else if (radioButtonParcial2.Checked)
            {
                agrupacionNotas = notasFiltradas
            .Where(n => n.NotaParcial2 != 0)
            .GroupBy(n => n.NotaParcial2)
            .Select(g => new { Nota = g.Key, Cantidad = g.Count() })
            .OrderBy(g => g.Nota)
            .ToList();
            }
            else
            {
                var agrupacionNotas1 = notasFiltradas
                    .GroupBy(n => n.NotaParcial1)
                    .Select(g => new { Nota = g.Key, Cantidad = g.Count() })
                    .OrderBy(g => g.Nota)
                    .ToList();

                var agrupacionNotas2 = notasFiltradas
            .Where(n => n.NotaParcial2 != 0)
            .GroupBy(n => n.NotaParcial2)
            .Select(g => new { Nota = g.Key, Cantidad = g.Count() })
            .OrderBy(g => g.Nota)
            .ToList();

                agrupacionNotas = agrupacionNotas1.Concat(agrupacionNotas2)
                    .GroupBy(n => n.Nota)
                    .Select(g => new { Nota = g.Key, Cantidad = g.Sum(x => x.Cantidad) })
                    .OrderBy(g => g.Nota)
                    .ToList();
            }



            var series = new Series
            {
                Name = "Parciales",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column
            };

            chartParciales.Series.Add(series);

            foreach (var agrupacion in agrupacionNotas)
            {
                series.Points.AddXY(agrupacion.Nota, agrupacion.Cantidad);
            }

            series.Label = "#VALX: #VALY";
            foreach (DataPoint point in series.Points)
            {
                point.LabelForeColor = System.Drawing.Color.Black;
                point.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold);
            }

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 11;

            Legend legend = new Legend
            {
                Enabled = false
            };
            chartParciales.Legends.Add(legend);

            chartParciales.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
            chartParciales.BackColor = System.Drawing.Color.Transparent;

            chartParciales.ChartAreas[0].RecalculateAxesScale();

            string[] coloresPersonalizados = new string[] { "#FF5733", "#FFC300", "#DAF7A6", "#C70039", "#900C3F", "#FF8C00",
                    "#FF1493", "#FFD700", "#FF6347", "#8B0000", "#FF4500", "#FF7F50", "#FFDAB9", "#FF69B4", "#CD5C5C" };
            for (int i = 0; i < chartParciales.Series[0].Points.Count; i++)
            {
                if (i < coloresPersonalizados.Length)
                {
                    chartParciales.Series[0].Points[i].Color = ColorTranslator.FromHtml(coloresPersonalizados[i]);
                }
                else
                {
                    chartParciales.Series[0].Points[i].Color = Color.FromArgb(255, 0, 0);
                }
            }

            chartParciales.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void buttonUltimaSemana_Click(object sender, EventArgs e)
        {
            List<BEAsistencia> asistenciasUltimaSemana;
            int codigoCarrera = (comboBoxCarrera.SelectedItem as BECarrera).Codigo;
            if (comboBoxAlumno.SelectedItem != null)
            {
                int codigoAlumno = (comboBoxAlumno.SelectedItem as BEAlumno).Codigo;
                int codigoMateria = 0;
                if (comboBoxMateria.SelectedItem != null)
                {
                    codigoMateria = (comboBoxMateria.SelectedItem as BEMateria).Codigo;
                }
                asistenciasUltimaSemana = (bllAsistencia.AsistenciaUltimaSemana());

                if (codigoCarrera != 0)
                {
                    asistenciasUltimaSemana = asistenciasUltimaSemana.Where(a => a.IdCarrera == codigoCarrera).ToList();
                }

                if (codigoAlumno != 0)
                {
                    asistenciasUltimaSemana = asistenciasUltimaSemana.Where(a => a.IdAlumno == codigoAlumno).ToList();
                }

                if (codigoMateria != 0)
                {
                    asistenciasUltimaSemana = asistenciasUltimaSemana.Where(a => a.IdMateria == codigoMateria).ToList();
                }

                ActualizarGraficoAsistencia(asistenciasUltimaSemana);
                chartAsistencia.Visible = true;


                listaComprobantes.Clear();
                listaComprobantes = bllComprobante.listaComprobantes(DateTime.Now.AddDays(-7), DateTime.Now);
                ActualizarGraficoFacturacion(listaComprobantes);
            }
        }

        private void buttonUltimoMes_Click(object sender, EventArgs e)
        {
            List<BEAsistencia> asistenciasUltimoMes;
            int codigoCarrera = (comboBoxCarrera.SelectedItem as BECarrera).Codigo;
            if (comboBoxAlumno.SelectedItem != null)
            {
                int codigoAlumno = (comboBoxAlumno.SelectedItem as BEAlumno).Codigo;
                int codigoMateria = 0;
                if (comboBoxMateria.SelectedItem != null)
                {
                    codigoMateria = (comboBoxMateria.SelectedItem as BEMateria).Codigo;
                }
                asistenciasUltimoMes = (bllAsistencia.AsistenciaUltimoMes());

                if (codigoCarrera != 0)
                {
                    asistenciasUltimoMes = asistenciasUltimoMes.Where(a => a.IdCarrera == codigoCarrera).ToList();
                }

                if (codigoAlumno != 0)
                {
                    asistenciasUltimoMes = asistenciasUltimoMes.Where(a => a.IdAlumno == codigoAlumno).ToList();
                }

                if (codigoMateria != 0)
                {
                    asistenciasUltimoMes = asistenciasUltimoMes.Where(a => a.IdMateria == codigoMateria).ToList();
                }


                ActualizarGraficoAsistencia(asistenciasUltimoMes);
                chartAsistencia.Visible = true;

                listaComprobantes.Clear();
                listaComprobantes = bllComprobante.listaComprobantes(DateTime.Now.AddDays(-30), DateTime.Now);
                ActualizarGraficoFacturacion(listaComprobantes);
            }
        }

        private void buttonIntervaloSeleccionado_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxDesde.Text) || string.IsNullOrWhiteSpace(textBoxHasta.Text))
            {
                MessageBox.Show("Por favor, ingrese ambas fechas 'Desde' y 'Hasta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaDesde, fechaHasta;
            try
            {
                fechaDesde = DateTime.ParseExact(textBoxDesde.Text, "dd/MM/yyyy", null);
                fechaHasta = DateTime.ParseExact(textBoxHasta.Text, "dd/MM/yyyy", null);
            }
            catch (FormatException)
            {
                MessageBox.Show("Las fechas deben estar en el formato 'dd/MM/yyyy'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaHoy = DateTime.Today;

            if (fechaDesde > fechaHoy || fechaHasta > fechaHoy)
            {
                MessageBox.Show("Las fechas 'Desde' y 'Hasta' no pueden ser mayores al día de hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fechaDesde > fechaHasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (alumnoSeleccionadoAsistencia.Codigo != 0)
            {

            }

            List<BEAsistencia> asistenciasIntervalo;
            int codigoCarrera = (comboBoxCarrera.SelectedItem as BECarrera).Codigo;
            if (comboBoxAlumno.SelectedItem != null)
            {
                int codigoAlumno = (comboBoxAlumno.SelectedItem as BEAlumno).Codigo;
                int codigoMateria = 0;
                if (comboBoxMateria.SelectedItem != null)
                {
                    codigoMateria = (comboBoxMateria.SelectedItem as BEMateria).Codigo;
                }
                asistenciasIntervalo = (bllAsistencia.AsistenciaIntervalo(fechaDesde, fechaHasta));
                if (codigoCarrera != 0)
                {
                    asistenciasIntervalo = asistenciasIntervalo.Where(a => a.IdCarrera == codigoCarrera).ToList();
                }

                if (codigoAlumno != 0)
                {
                    asistenciasIntervalo = asistenciasIntervalo.Where(a => a.IdAlumno == codigoAlumno).ToList();
                }

                if (codigoMateria != 0)
                {
                    asistenciasIntervalo = asistenciasIntervalo.Where(a => a.IdMateria == codigoMateria).ToList();
                }

                ActualizarGraficoAsistencia(asistenciasIntervalo);
                chartAsistencia.Visible = true;

                listaComprobantes.Clear();
                listaComprobantes = bllComprobante.listaComprobantes(fechaDesde, fechaHasta);
                ActualizarGraficoFacturacion(listaComprobantes);
            }
        }

        private void textBoxDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radioButtonParcial1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGraficoParciales(notas);
        }

        private void radioButtonParcial2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGraficoParciales(notas);

        }

        private void radioButtonParcialAmbos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGraficoParciales(notas);

        }
    }
}
