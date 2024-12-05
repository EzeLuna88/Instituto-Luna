namespace LUGtp1
{
    partial class FrmNotasAlumnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotasAlumnos));
            this.buttonMostrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCarreraProfesor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMateriaProfesor = new System.Windows.Forms.ComboBox();
            this.dataGridViewAlumnos = new System.Windows.Forms.DataGridView();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMostrar
            // 
            this.buttonMostrar.BackColor = System.Drawing.Color.White;
            this.buttonMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMostrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMostrar.Location = new System.Drawing.Point(10, 79);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(144, 47);
            this.buttonMostrar.TabIndex = 61;
            this.buttonMostrar.Text = "MOSTRAR";
            this.buttonMostrar.UseVisualStyleBackColor = false;
            this.buttonMostrar.Click += new System.EventHandler(this.buttonMostrar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 60;
            this.label1.Text = "Carrera";
            // 
            // comboBoxCarreraProfesor
            // 
            this.comboBoxCarreraProfesor.BackColor = System.Drawing.Color.White;
            this.comboBoxCarreraProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCarreraProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCarreraProfesor.FormattingEnabled = true;
            this.comboBoxCarreraProfesor.Location = new System.Drawing.Point(146, 13);
            this.comboBoxCarreraProfesor.Name = "comboBoxCarreraProfesor";
            this.comboBoxCarreraProfesor.Size = new System.Drawing.Size(232, 29);
            this.comboBoxCarreraProfesor.TabIndex = 59;
            this.comboBoxCarreraProfesor.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarreraProfesor_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 58;
            this.label4.Text = "Materia";
            // 
            // comboBoxMateriaProfesor
            // 
            this.comboBoxMateriaProfesor.BackColor = System.Drawing.Color.White;
            this.comboBoxMateriaProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMateriaProfesor.FormattingEnabled = true;
            this.comboBoxMateriaProfesor.Location = new System.Drawing.Point(146, 46);
            this.comboBoxMateriaProfesor.Name = "comboBoxMateriaProfesor";
            this.comboBoxMateriaProfesor.Size = new System.Drawing.Size(232, 29);
            this.comboBoxMateriaProfesor.TabIndex = 57;
            // 
            // dataGridViewAlumnos
            // 
            this.dataGridViewAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnos.Location = new System.Drawing.Point(6, 132);
            this.dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            this.dataGridViewAlumnos.Size = new System.Drawing.Size(764, 254);
            this.dataGridViewAlumnos.TabIndex = 62;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.White;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(10, 392);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(144, 47);
            this.buttonGuardar.TabIndex = 63;
            this.buttonGuardar.Text = "GUARDAR";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonGuardar);
            this.groupBox1.Controls.Add(this.comboBoxMateriaProfesor);
            this.groupBox1.Controls.Add(this.dataGridViewAlumnos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonMostrar);
            this.groupBox1.Controls.Add(this.comboBoxCarreraProfesor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 451);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // FrmNotasAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(804, 475);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNotasAlumnos";
            this.Text = "Notas Alumnos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMostrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCarreraProfesor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMateriaProfesor;
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}