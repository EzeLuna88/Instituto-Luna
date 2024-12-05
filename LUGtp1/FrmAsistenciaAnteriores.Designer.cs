namespace LUGtp1
{
    partial class FrmAsistenciaAnteriores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaAnteriores));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonModificarAsistencia = new System.Windows.Forms.Button();
            this.buttonGuardarAsistencia = new System.Windows.Forms.Button();
            this.dataGridViewAlumnos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.buttonModificarAsistencia);
            this.groupBox1.Controls.Add(this.buttonGuardarAsistencia);
            this.groupBox1.Controls.Add(this.dataGridViewAlumnos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 451);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // buttonModificarAsistencia
            // 
            this.buttonModificarAsistencia.BackColor = System.Drawing.Color.White;
            this.buttonModificarAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificarAsistencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificarAsistencia.Location = new System.Drawing.Point(639, 392);
            this.buttonModificarAsistencia.Name = "buttonModificarAsistencia";
            this.buttonModificarAsistencia.Size = new System.Drawing.Size(144, 53);
            this.buttonModificarAsistencia.TabIndex = 59;
            this.buttonModificarAsistencia.Text = "MODIFICAR ASISTENCIA";
            this.buttonModificarAsistencia.UseVisualStyleBackColor = false;
            this.buttonModificarAsistencia.Click += new System.EventHandler(this.buttonModificarAsistencia_Click);
            // 
            // buttonGuardarAsistencia
            // 
            this.buttonGuardarAsistencia.BackColor = System.Drawing.Color.White;
            this.buttonGuardarAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardarAsistencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardarAsistencia.Location = new System.Drawing.Point(19, 392);
            this.buttonGuardarAsistencia.Name = "buttonGuardarAsistencia";
            this.buttonGuardarAsistencia.Size = new System.Drawing.Size(144, 53);
            this.buttonGuardarAsistencia.TabIndex = 58;
            this.buttonGuardarAsistencia.Text = "GUARDAR ASISTENCIA";
            this.buttonGuardarAsistencia.UseVisualStyleBackColor = false;
            this.buttonGuardarAsistencia.Click += new System.EventHandler(this.buttonGuardarAsistencia_Click);
            // 
            // dataGridViewAlumnos
            // 
            this.dataGridViewAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnos.Location = new System.Drawing.Point(19, 19);
            this.dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            this.dataGridViewAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlumnos.Size = new System.Drawing.Size(764, 367);
            this.dataGridViewAlumnos.TabIndex = 55;
            // 
            // FrmAsistenciaAnteriores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(833, 475);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAsistenciaAnteriores";
            this.Text = "Asistencias anteriores";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonModificarAsistencia;
        private System.Windows.Forms.Button buttonGuardarAsistencia;
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;
    }
}