namespace LUGtp1
{
    partial class FrmCarreraAgregarAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarreraAgregarAlumno));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBuscarAlumno = new System.Windows.Forms.TextBox();
            this.dataGridViewAlumnos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.textBoxBuscarAlumno);
            this.groupBox2.Controls.Add(this.dataGridViewAlumnos);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelErrorNombre);
            this.groupBox2.Controls.Add(this.buttonAceptar);
            this.groupBox2.Controls.Add(this.buttonCancelar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(831, 350);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            // 
            // textBoxBuscarAlumno
            // 
            this.textBoxBuscarAlumno.BackColor = System.Drawing.Color.White;
            this.textBoxBuscarAlumno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscarAlumno.Location = new System.Drawing.Point(6, 308);
            this.textBoxBuscarAlumno.Name = "textBoxBuscarAlumno";
            this.textBoxBuscarAlumno.Size = new System.Drawing.Size(519, 29);
            this.textBoxBuscarAlumno.TabIndex = 84;
            // 
            // dataGridViewAlumnos
            // 
            this.dataGridViewAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnos.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            this.dataGridViewAlumnos.ReadOnly = true;
            this.dataGridViewAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlumnos.Size = new System.Drawing.Size(819, 272);
            this.dataGridViewAlumnos.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(143, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 77;
            // 
            // labelErrorNombre
            // 
            this.labelErrorNombre.AutoSize = true;
            this.labelErrorNombre.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNombre.Location = new System.Drawing.Point(211, 213);
            this.labelErrorNombre.Name = "labelErrorNombre";
            this.labelErrorNombre.Size = new System.Drawing.Size(0, 13);
            this.labelErrorNombre.TabIndex = 78;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.White;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptar.Location = new System.Drawing.Point(531, 297);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(144, 47);
            this.buttonAceptar.TabIndex = 39;
            this.buttonAceptar.Text = "ACEPTAR";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.White;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(681, 297);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonCancelar.TabIndex = 40;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FrmCarreraAgregarAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(855, 374);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCarreraAgregarAlumno";
            this.Text = "Agregar alumno";
            this.Load += new System.EventHandler(this.FrmCarreraAgregarAlumno_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;
        private System.Windows.Forms.TextBox textBoxBuscarAlumno;
    }
}