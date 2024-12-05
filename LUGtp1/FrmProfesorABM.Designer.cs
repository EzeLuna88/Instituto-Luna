namespace LUGtp1
{
    partial class FrmProfesorABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfesorABM));
            this.buttonProfesorAlta = new System.Windows.Forms.Button();
            this.buttonProfesorBaja = new System.Windows.Forms.Button();
            this.buttonProfesorModificacion = new System.Windows.Forms.Button();
            this.textBoxProfesorApellido = new System.Windows.Forms.TextBox();
            this.textBoxProfesorNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProfesorDni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProfesorCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelErrorApellido = new System.Windows.Forms.Label();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.labelErrorDni = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_dgv1 = new LUGtp1.UC_dgv();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonProfesorAlta
            // 
            this.buttonProfesorAlta.BackColor = System.Drawing.Color.White;
            this.buttonProfesorAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfesorAlta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProfesorAlta.Location = new System.Drawing.Point(626, 145);
            this.buttonProfesorAlta.Name = "buttonProfesorAlta";
            this.buttonProfesorAlta.Size = new System.Drawing.Size(144, 47);
            this.buttonProfesorAlta.TabIndex = 34;
            this.buttonProfesorAlta.Text = "ALTA";
            this.buttonProfesorAlta.UseVisualStyleBackColor = false;
            this.buttonProfesorAlta.Click += new System.EventHandler(this.buttonProfesorAlta_Click);
            // 
            // buttonProfesorBaja
            // 
            this.buttonProfesorBaja.BackColor = System.Drawing.Color.White;
            this.buttonProfesorBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfesorBaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProfesorBaja.Location = new System.Drawing.Point(66, 145);
            this.buttonProfesorBaja.Name = "buttonProfesorBaja";
            this.buttonProfesorBaja.Size = new System.Drawing.Size(144, 47);
            this.buttonProfesorBaja.TabIndex = 33;
            this.buttonProfesorBaja.Text = "BAJA";
            this.buttonProfesorBaja.UseVisualStyleBackColor = false;
            this.buttonProfesorBaja.Click += new System.EventHandler(this.buttonProfesorBaja_Click);
            // 
            // buttonProfesorModificacion
            // 
            this.buttonProfesorModificacion.BackColor = System.Drawing.Color.White;
            this.buttonProfesorModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfesorModificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProfesorModificacion.Location = new System.Drawing.Point(216, 145);
            this.buttonProfesorModificacion.Name = "buttonProfesorModificacion";
            this.buttonProfesorModificacion.Size = new System.Drawing.Size(144, 47);
            this.buttonProfesorModificacion.TabIndex = 32;
            this.buttonProfesorModificacion.Text = "MODIFICACION";
            this.buttonProfesorModificacion.UseVisualStyleBackColor = false;
            this.buttonProfesorModificacion.Click += new System.EventHandler(this.buttonProfesorModificacion_Click);
            // 
            // textBoxProfesorApellido
            // 
            this.textBoxProfesorApellido.BackColor = System.Drawing.Color.White;
            this.textBoxProfesorApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfesorApellido.Location = new System.Drawing.Point(167, 79);
            this.textBoxProfesorApellido.Name = "textBoxProfesorApellido";
            this.textBoxProfesorApellido.Size = new System.Drawing.Size(232, 29);
            this.textBoxProfesorApellido.TabIndex = 27;
            this.textBoxProfesorApellido.TextChanged += new System.EventHandler(this.textBoxProfesorApellido_TextChanged);
            // 
            // textBoxProfesorNombre
            // 
            this.textBoxProfesorNombre.BackColor = System.Drawing.Color.White;
            this.textBoxProfesorNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfesorNombre.Location = new System.Drawing.Point(167, 46);
            this.textBoxProfesorNombre.Name = "textBoxProfesorNombre";
            this.textBoxProfesorNombre.Size = new System.Drawing.Size(232, 29);
            this.textBoxProfesorNombre.TabIndex = 26;
            this.textBoxProfesorNombre.TextChanged += new System.EventHandler(this.textBoxProfesorNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nombre";
            // 
            // textBoxProfesorDni
            // 
            this.textBoxProfesorDni.BackColor = System.Drawing.Color.White;
            this.textBoxProfesorDni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfesorDni.Location = new System.Drawing.Point(167, 112);
            this.textBoxProfesorDni.Name = "textBoxProfesorDni";
            this.textBoxProfesorDni.Size = new System.Drawing.Size(232, 29);
            this.textBoxProfesorDni.TabIndex = 37;
            this.textBoxProfesorDni.TextChanged += new System.EventHandler(this.textBoxProfesorDni_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "DNI";
            // 
            // textBoxProfesorCodigo
            // 
            this.textBoxProfesorCodigo.BackColor = System.Drawing.Color.White;
            this.textBoxProfesorCodigo.Enabled = false;
            this.textBoxProfesorCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProfesorCodigo.Location = new System.Drawing.Point(167, 13);
            this.textBoxProfesorCodigo.Name = "textBoxProfesorCodigo";
            this.textBoxProfesorCodigo.Size = new System.Drawing.Size(232, 29);
            this.textBoxProfesorCodigo.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 21);
            this.label5.TabIndex = 38;
            this.label5.Text = "Codigo";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.labelErrorApellido);
            this.groupBox1.Controls.Add(this.labelErrorNombre);
            this.groupBox1.Controls.Add(this.labelErrorDni);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxProfesorCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxProfesorDni);
            this.groupBox1.Controls.Add(this.textBoxProfesorNombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxProfesorApellido);
            this.groupBox1.Controls.Add(this.buttonProfesorModificacion);
            this.groupBox1.Controls.Add(this.buttonProfesorAlta);
            this.groupBox1.Controls.Add(this.buttonProfesorBaja);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 204);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // labelErrorApellido
            // 
            this.labelErrorApellido.AutoSize = true;
            this.labelErrorApellido.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorApellido.ForeColor = System.Drawing.Color.Red;
            this.labelErrorApellido.Location = new System.Drawing.Point(405, 87);
            this.labelErrorApellido.Name = "labelErrorApellido";
            this.labelErrorApellido.Size = new System.Drawing.Size(0, 13);
            this.labelErrorApellido.TabIndex = 77;
            // 
            // labelErrorNombre
            // 
            this.labelErrorNombre.AutoSize = true;
            this.labelErrorNombre.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNombre.Location = new System.Drawing.Point(405, 54);
            this.labelErrorNombre.Name = "labelErrorNombre";
            this.labelErrorNombre.Size = new System.Drawing.Size(0, 13);
            this.labelErrorNombre.TabIndex = 76;
            // 
            // labelErrorDni
            // 
            this.labelErrorDni.AutoSize = true;
            this.labelErrorDni.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorDni.ForeColor = System.Drawing.Color.Red;
            this.labelErrorDni.Location = new System.Drawing.Point(405, 120);
            this.labelErrorDni.Name = "labelErrorDni";
            this.labelErrorDni.Size = new System.Drawing.Size(0, 13);
            this.labelErrorDni.TabIndex = 75;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.uC_dgv1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 330);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // uC_dgv1
            // 
            this.uC_dgv1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.uC_dgv1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_dgv1.Location = new System.Drawing.Point(6, 44);
            this.uC_dgv1.Name = "uC_dgv1";
            this.uC_dgv1.Size = new System.Drawing.Size(764, 280);
            this.uC_dgv1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 30);
            this.label1.TabIndex = 36;
            this.label1.Text = "LISTA DE PROFESORES";
            // 
            // FrmProfesorABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProfesorABM";
            this.Text = "Profesor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonProfesorAlta;
        private System.Windows.Forms.Button buttonProfesorBaja;
        private System.Windows.Forms.Button buttonProfesorModificacion;
        private System.Windows.Forms.TextBox textBoxProfesorApellido;
        private System.Windows.Forms.TextBox textBoxProfesorNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProfesorDni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProfesorCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelErrorApellido;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.Label labelErrorDni;
        private UC_dgv uC_dgv1;
    }
}