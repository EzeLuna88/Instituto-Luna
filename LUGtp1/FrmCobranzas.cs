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
using iText;
using iText.Layout;
using iText.StyledXmlParser.Jsoup.Nodes;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.Layout.Element;
using System.Diagnostics;



namespace LUGtp1
{
    public partial class FrmCobranzas : Form
    {
        BLLAlumno bLLAlumno;
        BEAlumno beAlumno;
        BLLMatricula bllMatricula;
        BEMatricula beMatricula;
        BEComprobante beComprobante;
        BLLComprobante bllComprobante;


        public FrmCobranzas()
        {
            InitializeComponent();
            bLLAlumno = new BLLAlumno();
            beAlumno = new BEAlumno();
            bllMatricula = new BLLMatricula();
            beComprobante = new BEComprobante();
            labelPrecioMatricula.Text = ("$ " + bllMatricula.DevolverPrecio().ToString());
            CargarDataGridView();
            beMatricula = new BEMatricula();
            beMatricula.Precio = bllMatricula.DevolverPrecio();
            bllComprobante = new BLLComprobante();
        }

        private void FrmCobranzas_Load(object sender, EventArgs e)
        {

        }


        void CargarDataGridView()
        {
            uC_dgv1.dataGridView1.DataSource = null;
            uC_dgv1.dataGridView1.DataSource = bLLAlumno.ListarTodo();
            uC_dgv1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            uC_dgv1.dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            uC_dgv1.dataGridView1.Size = new Size(1145, 290);
            uC_dgv1.dataGridView1.ScrollBars = ScrollBars.Both;
            if (uC_dgv1.dataGridView1.Rows.Count > 0)
            {
                uC_dgv1.dataGridView1.Columns["Apellido"].DisplayIndex = 0;
                uC_dgv1.dataGridView1.Columns["Nombre"].DisplayIndex = 1;

                uC_dgv1.dataGridView1.Columns["FechaDeNacimiento"].DefaultCellStyle.Format = "yyyy/MM/dd";
                uC_dgv1.dataGridView1.Columns["FechaDeNacimiento"].HeaderText = "Fecha de Nacimiento";
                uC_dgv1.dataGridView1.Columns["Codigo"].Visible = false;
                uC_dgv1.dataGridView1.Columns["MatriculaPagada"].HeaderText = "Matricula pagada";
            }

        }

        private void dataGridViewAlumnosCobranzas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BEAlumno beAlumno;

            beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;


        }

        private void buttonPagarMatricula_Click(object sender, EventArgs e)
        {
            BEAlumno beAlumno;
            decimal matriculaAlumno = 0;

            beAlumno = (BEAlumno)uC_dgv1.dataGridView1.CurrentRow.DataBoundItem;
            if (beAlumno.MatriculaPagada == true)
            {
                MessageBox.Show("Ya tiene la matricula pagada");
            }
            else
            {
                if (beAlumno.Becado == true)
                {
                    matriculaAlumno = beMatricula.Precio / 2;
                    DialogResult respuesta;
                    respuesta = MessageBox.Show("Confirmar pago de matricula. El total es: $" + matriculaAlumno, "PAGAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        beAlumno.MatriculaPagada = true;
                        bLLAlumno.Guardar(beAlumno);

                        beComprobante.Numero = bllComprobante.SiguienteNumero();
                        beComprobante.Fecha = DateTime.Now;
                        beComprobante.Total = matriculaAlumno;
                        beComprobante.Descripcion = "Matricula anual";
                        beComprobante.CodigoAlumno = beAlumno.Codigo;
                        bllComprobante.GuardarComprobante(beComprobante);
                        GenerarPDF(beComprobante, beAlumno);
                        CargarDataGridView();
                    }
                }
                else
                {
                    matriculaAlumno = beMatricula.Precio;
                    DialogResult respuesta;
                    respuesta = MessageBox.Show("Confirmar pago de matricula. El total es: $" + matriculaAlumno, "PAGAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        beAlumno.MatriculaPagada = true;
                        bLLAlumno.Guardar(beAlumno);
                        beComprobante.Numero = bllComprobante.SiguienteNumero();
                        beComprobante.Fecha = DateTime.Now;
                        beComprobante.Total = matriculaAlumno;
                        beComprobante.Descripcion = "Matricula anual";
                        beComprobante.CodigoAlumno = beAlumno.Codigo;
                        bllComprobante.GuardarComprobante(beComprobante);
                        GenerarPDF(beComprobante, beAlumno);
                        CargarDataGridView();
                    }
                }
                CargarDataGridView();
            }

        }

        private void buttonModificarPrecio_Click(object sender, EventArgs e)
        {
            FrmMatriculaModificarPrecio frmMatriculaModificarPrecio = new FrmMatriculaModificarPrecio();
            if (frmMatriculaModificarPrecio.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("El precio se modifico correctamente");
                labelPrecioMatricula.Text = ("$ " + bllMatricula.DevolverPrecio().ToString());
                beMatricula.Precio = bllMatricula.DevolverPrecio();

            }

        }

        public void GenerarPDF(BEComprobante comprobante, BEAlumno alumno)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar PDF";
            saveFileDialog.FileName = comprobante.Numero + ".pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog.FileName;

                using (PdfWriter pdfWriter = new PdfWriter(ruta))
                {
                    using (PdfDocument pdf = new PdfDocument(pdfWriter))
                    {
                        using (iText.Layout.Document doc = new iText.Layout.Document(pdf))
                        {
                            GenerarContenidoPDF(doc, comprobante, alumno);

                        }
                    }
                }
                try
                {
                    Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el archivo PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerarContenidoPDF(iText.Layout.Document doc, BEComprobante comprobante, BEAlumno alumno)
        {
            PdfFont font = PdfFontFactory.CreateFont("Helvetica-Bold");
            doc.SetFont(font).SetFontSize(16);


            Paragraph titulo = new Paragraph("INSTITUTO LUNA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            doc.Add(titulo);

            doc.Add(new Paragraph());
            doc.SetFontSize(8);
            doc.SetMargins(10, 10, 10, 10);

            doc.Add(new Paragraph("Nro: " + comprobante.Numero));
            doc.Add(new Paragraph("Fecha: " + comprobante.Fecha.ToString("dd/MM/yyyy")));
            doc.Add(new Paragraph("Alumno: " + alumno.Apellido + ", " + alumno.Nombre));

            doc.Add(new Paragraph());


            Table tablaComprobante = new Table(2).UseAllAvailableWidth();
            tablaComprobante.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell[] encabezados = {
                new Cell().Add(new Paragraph("DESCRIPCION")),
                new Cell().Add(new Paragraph("PRECIO")).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
            };

            foreach (Cell celda in encabezados)
            {
                tablaComprobante.AddHeaderCell(celda);
            }


            tablaComprobante.AddCell(comprobante.Descripcion).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            tablaComprobante.AddCell("$ " + comprobante.Total.ToString()).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);


            doc.Add(tablaComprobante);
            doc.SetFontSize(10);
            doc.Add(new Paragraph());
            Paragraph total = new Paragraph("TOTAL: $ " + comprobante.Total).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
            doc.Add(total);
            doc.Add(new Paragraph());
            doc.Add(new Paragraph());
        }
    }
}
