namespace LUGtp1
{
    partial class FrmAsistenciaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaControl));
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMateriaProfesor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCarreraProfesor = new System.Windows.Forms.ComboBox();
            this.dataGridViewAlumnos = new System.Windows.Forms.DataGridView();
            this.buttonMostrar = new System.Windows.Forms.Button();
            this.labelFecha = new System.Windows.Forms.Label();
            this.buttonGuardarAsistencia = new System.Windows.Forms.Button();
            this.buttonModificarAsistencia = new System.Windows.Forms.Button();
            this.buttonFechasAnteriores = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAsistenciaFecha = new System.Windows.Forms.TextBox();
            this.buttonAsistenciaFechaElegida = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 51;
            this.label4.Text = "Materia";
            // 
            // comboBoxMateriaProfesor
            // 
            this.comboBoxMateriaProfesor.BackColor = System.Drawing.Color.White;
            this.comboBoxMateriaProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateriaProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMateriaProfesor.FormattingEnabled = true;
            this.comboBoxMateriaProfesor.Location = new System.Drawing.Point(155, 46);
            this.comboBoxMateriaProfesor.Name = "comboBoxMateriaProfesor";
            this.comboBoxMateriaProfesor.Size = new System.Drawing.Size(232, 29);
            this.comboBoxMateriaProfesor.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "Carrera";
            // 
            // comboBoxCarreraProfesor
            // 
            this.comboBoxCarreraProfesor.BackColor = System.Drawing.Color.White;
            this.comboBoxCarreraProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCarreraProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCarreraProfesor.FormattingEnabled = true;
            this.comboBoxCarreraProfesor.Location = new System.Drawing.Point(155, 13);
            this.comboBoxCarreraProfesor.Name = "comboBoxCarreraProfesor";
            this.comboBoxCarreraProfesor.Size = new System.Drawing.Size(232, 29);
            this.comboBoxCarreraProfesor.TabIndex = 52;
            this.comboBoxCarreraProfesor.SelectedIndexChanged += new System.EventHandler(this.comboBoxCarreraProfesor_SelectedIndexChanged);
            // 
            // dataGridViewAlumnos
            // 
            this.dataGridViewAlumnos.AllowUserToAddRows = false;
            this.dataGridViewAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnos.Location = new System.Drawing.Point(19, 142);
            this.dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            this.dataGridViewAlumnos.Size = new System.Drawing.Size(764, 244);
            this.dataGridViewAlumnos.TabIndex = 55;
            // 
            // buttonMostrar
            // 
            this.buttonMostrar.BackColor = System.Drawing.Color.White;
            this.buttonMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMostrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMostrar.Location = new System.Drawing.Point(19, 79);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(190, 57);
            this.buttonMostrar.TabIndex = 56;
            this.buttonMostrar.Text = "MOSTRAR ASISTENCIA DEL DIA";
            this.buttonMostrar.UseVisualStyleBackColor = false;
            this.buttonMostrar.Click += new System.EventHandler(this.buttonMostrar_Click);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(215, 97);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(50, 21);
            this.labelFecha.TabIndex = 57;
            this.labelFecha.Text = "Fecha";
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
            // buttonFechasAnteriores
            // 
            this.buttonFechasAnteriores.BackColor = System.Drawing.Color.White;
            this.buttonFechasAnteriores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFechasAnteriores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFechasAnteriores.Location = new System.Drawing.Point(639, 13);
            this.buttonFechasAnteriores.Name = "buttonFechasAnteriores";
            this.buttonFechasAnteriores.Size = new System.Drawing.Size(144, 57);
            this.buttonFechasAnteriores.TabIndex = 60;
            this.buttonFechasAnteriores.Text = "FECHAS ANTERIORES";
            this.buttonFechasAnteriores.UseVisualStyleBackColor = false;
            this.buttonFechasAnteriores.Click += new System.EventHandler(this.buttonFechasAnteriores_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.textBoxAsistenciaFecha);
            this.groupBox1.Controls.Add(this.buttonAsistenciaFechaElegida);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonModificarAsistencia);
            this.groupBox1.Controls.Add(this.buttonFechasAnteriores);
            this.groupBox1.Controls.Add(this.buttonGuardarAsistencia);
            this.groupBox1.Controls.Add(this.comboBoxMateriaProfesor);
            this.groupBox1.Controls.Add(this.dataGridViewAlumnos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxCarreraProfesor);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Controls.Add(this.buttonMostrar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 451);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // textBoxAsistenciaFecha
            // 
            this.textBoxAsistenciaFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAsistenciaFecha.Location = new System.Drawing.Point(523, 94);
            this.textBoxAsistenciaFecha.Name = "textBoxAsistenciaFecha";
            this.textBoxAsistenciaFecha.Size = new System.Drawing.Size(110, 29);
            this.textBoxAsistenciaFecha.TabIndex = 62;
            // 
            // buttonAsistenciaFechaElegida
            // 
            this.buttonAsistenciaFechaElegida.BackColor = System.Drawing.Color.White;
            this.buttonAsistenciaFechaElegida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAsistenciaFechaElegida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAsistenciaFechaElegida.Location = new System.Drawing.Point(639, 79);
            this.buttonAsistenciaFechaElegida.Name = "buttonAsistenciaFechaElegida";
            this.buttonAsistenciaFechaElegida.Size = new System.Drawing.Size(144, 57);
            this.buttonAsistenciaFechaElegida.TabIndex = 61;
            this.buttonAsistenciaFechaElegida.Text = "MOSTRAR FECHA ELEGIDA";
            this.buttonAsistenciaFechaElegida.UseVisualStyleBackColor = false;
            this.buttonAsistenciaFechaElegida.Click += new System.EventHandler(this.buttonAsistenciaFechaElegida_Click);
            // 
            // FrmAsistenciaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(829, 474);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAsistenciaControl";
            this.Text = "Control De Asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMateriaProfesor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCarreraProfesor;
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;
        private System.Windows.Forms.Button buttonMostrar;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Button buttonGuardarAsistencia;
        private System.Windows.Forms.Button buttonModificarAsistencia;
        private System.Windows.Forms.Button buttonFechasAnteriores;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAsistenciaFecha;
        private System.Windows.Forms.Button buttonAsistenciaFechaElegida;
    }
}