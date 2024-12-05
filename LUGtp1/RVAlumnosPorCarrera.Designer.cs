namespace LUGtp1
{
    partial class RVAlumnosPorCarrera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RVAlumnosPorCarrera));
            this.buttonGenerarInformeCarrerasAlumnos = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonGenerarInformeCarrerasAlumnos
            // 
            this.buttonGenerarInformeCarrerasAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.buttonGenerarInformeCarrerasAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarInformeCarrerasAlumnos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarInformeCarrerasAlumnos.Location = new System.Drawing.Point(79, 39);
            this.buttonGenerarInformeCarrerasAlumnos.Name = "buttonGenerarInformeCarrerasAlumnos";
            this.buttonGenerarInformeCarrerasAlumnos.Size = new System.Drawing.Size(144, 53);
            this.buttonGenerarInformeCarrerasAlumnos.TabIndex = 64;
            this.buttonGenerarInformeCarrerasAlumnos.Text = "GENERAR INFORME";
            this.buttonGenerarInformeCarrerasAlumnos.UseVisualStyleBackColor = false;
            this.buttonGenerarInformeCarrerasAlumnos.Click += new System.EventHandler(this.buttonGenerarInformeCarrerasAlumnos_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InstitutoLuna.Reportes.Report6.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 98);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 443);
            this.reportViewer1.TabIndex = 65;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 21);
            this.comboBox1.TabIndex = 66;
            // 
            // RVAlumnosPorCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 553);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonGenerarInformeCarrerasAlumnos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RVAlumnosPorCarrera";
            this.Text = "Reporte - Alumnos por carrera";
            this.Load += new System.EventHandler(this.RVAlumnosPorCarrera_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonGenerarInformeCarrerasAlumnos;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}