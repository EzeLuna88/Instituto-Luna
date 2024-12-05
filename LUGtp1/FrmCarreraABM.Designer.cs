namespace LUGtp1
{
    partial class FrmCarreraABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarreraABM));
            this.buttonCarreraAlta = new System.Windows.Forms.Button();
            this.buttonCarreraBaja = new System.Windows.Forms.Button();
            this.buttonCarreraModificacion = new System.Windows.Forms.Button();
            this.textBoxCarreraNombre = new System.Windows.Forms.TextBox();
            this.textBoxCarreraCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCarreraBajaMateria = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonListadoDeAlumnos = new System.Windows.Forms.Button();
            this.uC_dgvCarreras = new LUGtp1.UC_dgv();
            this.buttonListadoDeMaterias = new System.Windows.Forms.Button();
            this.btnCorrelatividadQuitar = new System.Windows.Forms.Button();
            this.btnCorrelatividadAgregar = new System.Windows.Forms.Button();
            this.btnAgregarMateria = new System.Windows.Forms.Button();
            this.groupBoxMaterias = new System.Windows.Forms.GroupBox();
            this.buttonQuitarProfesor = new System.Windows.Forms.Button();
            this.buttonAgregarProfesor = new System.Windows.Forms.Button();
            this.uC_dgvMaterias = new LUGtp1.UC_dgv();
            this.groupBoxAlumnos = new System.Windows.Forms.GroupBox();
            this.buttonAlumnoQuitar = new System.Windows.Forms.Button();
            this.buttonAlumnoAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.uC_dgvAlumnos = new LUGtp1.UC_dgv();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxMaterias.SuspendLayout();
            this.groupBoxAlumnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCarreraAlta
            // 
            this.buttonCarreraAlta.BackColor = System.Drawing.Color.White;
            this.buttonCarreraAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarreraAlta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarreraAlta.Location = new System.Drawing.Point(6, 83);
            this.buttonCarreraAlta.Name = "buttonCarreraAlta";
            this.buttonCarreraAlta.Size = new System.Drawing.Size(144, 27);
            this.buttonCarreraAlta.TabIndex = 34;
            this.buttonCarreraAlta.Text = "ALTA";
            this.buttonCarreraAlta.UseVisualStyleBackColor = false;
            this.buttonCarreraAlta.Click += new System.EventHandler(this.buttonCarreraAlta_Click);
            // 
            // buttonCarreraBaja
            // 
            this.buttonCarreraBaja.BackColor = System.Drawing.Color.White;
            this.buttonCarreraBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarreraBaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarreraBaja.Location = new System.Drawing.Point(156, 83);
            this.buttonCarreraBaja.Name = "buttonCarreraBaja";
            this.buttonCarreraBaja.Size = new System.Drawing.Size(144, 27);
            this.buttonCarreraBaja.TabIndex = 33;
            this.buttonCarreraBaja.Text = "BAJA";
            this.buttonCarreraBaja.UseVisualStyleBackColor = false;
            this.buttonCarreraBaja.Click += new System.EventHandler(this.buttonCarreraBaja_Click);
            // 
            // buttonCarreraModificacion
            // 
            this.buttonCarreraModificacion.BackColor = System.Drawing.Color.White;
            this.buttonCarreraModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarreraModificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarreraModificacion.Location = new System.Drawing.Point(306, 83);
            this.buttonCarreraModificacion.Name = "buttonCarreraModificacion";
            this.buttonCarreraModificacion.Size = new System.Drawing.Size(144, 27);
            this.buttonCarreraModificacion.TabIndex = 32;
            this.buttonCarreraModificacion.Text = "MODIFICACION";
            this.buttonCarreraModificacion.UseVisualStyleBackColor = false;
            this.buttonCarreraModificacion.Click += new System.EventHandler(this.buttonCarreraModificacion_Click);
            // 
            // textBoxCarreraNombre
            // 
            this.textBoxCarreraNombre.BackColor = System.Drawing.Color.White;
            this.textBoxCarreraNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCarreraNombre.Location = new System.Drawing.Point(161, 50);
            this.textBoxCarreraNombre.Name = "textBoxCarreraNombre";
            this.textBoxCarreraNombre.Size = new System.Drawing.Size(232, 29);
            this.textBoxCarreraNombre.TabIndex = 26;
            this.textBoxCarreraNombre.TextChanged += new System.EventHandler(this.textBoxCarreraNombre_TextChanged);
            // 
            // textBoxCarreraCodigo
            // 
            this.textBoxCarreraCodigo.BackColor = System.Drawing.Color.White;
            this.textBoxCarreraCodigo.Enabled = false;
            this.textBoxCarreraCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCarreraCodigo.Location = new System.Drawing.Point(161, 17);
            this.textBoxCarreraCodigo.Name = "textBoxCarreraCodigo";
            this.textBoxCarreraCodigo.Size = new System.Drawing.Size(232, 29);
            this.textBoxCarreraCodigo.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "Codigo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 30);
            this.label3.TabIndex = 36;
            this.label3.Text = "LISTA DE CARRERAS";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.labelErrorNombre);
            this.groupBox1.Controls.Add(this.buttonCarreraAlta);
            this.groupBox1.Controls.Add(this.buttonCarreraBaja);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonCarreraModificacion);
            this.groupBox1.Controls.Add(this.textBoxCarreraCodigo);
            this.groupBox1.Controls.Add(this.textBoxCarreraNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 118);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // labelErrorNombre
            // 
            this.labelErrorNombre.AutoSize = true;
            this.labelErrorNombre.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNombre.Location = new System.Drawing.Point(399, 58);
            this.labelErrorNombre.Name = "labelErrorNombre";
            this.labelErrorNombre.Size = new System.Drawing.Size(0, 13);
            this.labelErrorNombre.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(301, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 30);
            this.label4.TabIndex = 39;
            this.label4.Text = "MATERIAS";
            // 
            // buttonCarreraBajaMateria
            // 
            this.buttonCarreraBajaMateria.BackColor = System.Drawing.Color.White;
            this.buttonCarreraBajaMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarreraBajaMateria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarreraBajaMateria.Location = new System.Drawing.Point(133, 251);
            this.buttonCarreraBajaMateria.Name = "buttonCarreraBajaMateria";
            this.buttonCarreraBajaMateria.Size = new System.Drawing.Size(121, 55);
            this.buttonCarreraBajaMateria.TabIndex = 35;
            this.buttonCarreraBajaMateria.Text = "BORRAR MATERIA";
            this.buttonCarreraBajaMateria.UseVisualStyleBackColor = false;
            this.buttonCarreraBajaMateria.Click += new System.EventHandler(this.buttonCarreraBajaMateria_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.buttonListadoDeAlumnos);
            this.groupBox2.Controls.Add(this.uC_dgvCarreras);
            this.groupBox2.Controls.Add(this.buttonListadoDeMaterias);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 419);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // buttonListadoDeAlumnos
            // 
            this.buttonListadoDeAlumnos.BackColor = System.Drawing.Color.White;
            this.buttonListadoDeAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListadoDeAlumnos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListadoDeAlumnos.Location = new System.Drawing.Point(227, 358);
            this.buttonListadoDeAlumnos.Name = "buttonListadoDeAlumnos";
            this.buttonListadoDeAlumnos.Size = new System.Drawing.Size(121, 54);
            this.buttonListadoDeAlumnos.TabIndex = 57;
            this.buttonListadoDeAlumnos.Text = "LISTADO DE ALUMNOS";
            this.buttonListadoDeAlumnos.UseVisualStyleBackColor = false;
            this.buttonListadoDeAlumnos.Click += new System.EventHandler(this.buttonListadoDeAlumnos_Click);
            // 
            // uC_dgvCarreras
            // 
            this.uC_dgvCarreras.BackColor = System.Drawing.Color.LightSteelBlue;
            this.uC_dgvCarreras.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.uC_dgvCarreras.Location = new System.Drawing.Point(6, 44);
            this.uC_dgvCarreras.Name = "uC_dgvCarreras";
            this.uC_dgvCarreras.Size = new System.Drawing.Size(444, 308);
            this.uC_dgvCarreras.TabIndex = 37;
            // 
            // buttonListadoDeMaterias
            // 
            this.buttonListadoDeMaterias.BackColor = System.Drawing.Color.White;
            this.buttonListadoDeMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListadoDeMaterias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListadoDeMaterias.Location = new System.Drawing.Point(100, 358);
            this.buttonListadoDeMaterias.Name = "buttonListadoDeMaterias";
            this.buttonListadoDeMaterias.Size = new System.Drawing.Size(121, 54);
            this.buttonListadoDeMaterias.TabIndex = 58;
            this.buttonListadoDeMaterias.Text = "LISTADO DE MATERIAS";
            this.buttonListadoDeMaterias.UseVisualStyleBackColor = false;
            this.buttonListadoDeMaterias.Click += new System.EventHandler(this.buttonListadoDeMaterias_Click);
            // 
            // btnCorrelatividadQuitar
            // 
            this.btnCorrelatividadQuitar.BackColor = System.Drawing.Color.White;
            this.btnCorrelatividadQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorrelatividadQuitar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrelatividadQuitar.Location = new System.Drawing.Point(450, 251);
            this.btnCorrelatividadQuitar.Name = "btnCorrelatividadQuitar";
            this.btnCorrelatividadQuitar.Size = new System.Drawing.Size(155, 55);
            this.btnCorrelatividadQuitar.TabIndex = 56;
            this.btnCorrelatividadQuitar.Text = "QUITAR CORRELATIVIDAD";
            this.btnCorrelatividadQuitar.UseVisualStyleBackColor = false;
            this.btnCorrelatividadQuitar.Click += new System.EventHandler(this.btnCorrelatividadQuitar_Click);
            // 
            // btnCorrelatividadAgregar
            // 
            this.btnCorrelatividadAgregar.BackColor = System.Drawing.Color.White;
            this.btnCorrelatividadAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorrelatividadAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrelatividadAgregar.Location = new System.Drawing.Point(289, 251);
            this.btnCorrelatividadAgregar.Name = "btnCorrelatividadAgregar";
            this.btnCorrelatividadAgregar.Size = new System.Drawing.Size(155, 55);
            this.btnCorrelatividadAgregar.TabIndex = 55;
            this.btnCorrelatividadAgregar.Text = "AGREGAR CORRELATIVIDAD";
            this.btnCorrelatividadAgregar.UseVisualStyleBackColor = false;
            this.btnCorrelatividadAgregar.Click += new System.EventHandler(this.btnCorrelatividad_Click);
            // 
            // btnAgregarMateria
            // 
            this.btnAgregarMateria.BackColor = System.Drawing.Color.White;
            this.btnAgregarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMateria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMateria.Location = new System.Drawing.Point(6, 251);
            this.btnAgregarMateria.Name = "btnAgregarMateria";
            this.btnAgregarMateria.Size = new System.Drawing.Size(121, 55);
            this.btnAgregarMateria.TabIndex = 42;
            this.btnAgregarMateria.Text = "AGREGAR MATERIA";
            this.btnAgregarMateria.UseVisualStyleBackColor = false;
            this.btnAgregarMateria.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxMaterias
            // 
            this.groupBoxMaterias.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxMaterias.Controls.Add(this.buttonQuitarProfesor);
            this.groupBoxMaterias.Controls.Add(this.buttonAgregarProfesor);
            this.groupBoxMaterias.Controls.Add(this.btnCorrelatividadAgregar);
            this.groupBoxMaterias.Controls.Add(this.btnCorrelatividadQuitar);
            this.groupBoxMaterias.Controls.Add(this.label4);
            this.groupBoxMaterias.Controls.Add(this.uC_dgvMaterias);
            this.groupBoxMaterias.Controls.Add(this.buttonCarreraBajaMateria);
            this.groupBoxMaterias.Controls.Add(this.btnAgregarMateria);
            this.groupBoxMaterias.Location = new System.Drawing.Point(479, 12);
            this.groupBoxMaterias.Name = "groupBoxMaterias";
            this.groupBoxMaterias.Size = new System.Drawing.Size(725, 376);
            this.groupBoxMaterias.TabIndex = 43;
            this.groupBoxMaterias.TabStop = false;
            // 
            // buttonQuitarProfesor
            // 
            this.buttonQuitarProfesor.BackColor = System.Drawing.Color.White;
            this.buttonQuitarProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuitarProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitarProfesor.Location = new System.Drawing.Point(133, 312);
            this.buttonQuitarProfesor.Name = "buttonQuitarProfesor";
            this.buttonQuitarProfesor.Size = new System.Drawing.Size(121, 55);
            this.buttonQuitarProfesor.TabIndex = 81;
            this.buttonQuitarProfesor.Text = "QUITAR PROFESOR";
            this.buttonQuitarProfesor.UseVisualStyleBackColor = false;
            this.buttonQuitarProfesor.Click += new System.EventHandler(this.buttonQuitarProfesor_Click);
            // 
            // buttonAgregarProfesor
            // 
            this.buttonAgregarProfesor.BackColor = System.Drawing.Color.White;
            this.buttonAgregarProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarProfesor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarProfesor.Location = new System.Drawing.Point(6, 312);
            this.buttonAgregarProfesor.Name = "buttonAgregarProfesor";
            this.buttonAgregarProfesor.Size = new System.Drawing.Size(121, 55);
            this.buttonAgregarProfesor.TabIndex = 80;
            this.buttonAgregarProfesor.Text = "AGREGAR PROFESOR";
            this.buttonAgregarProfesor.UseVisualStyleBackColor = false;
            this.buttonAgregarProfesor.Click += new System.EventHandler(this.buttonAgregarProfesor_Click);
            // 
            // uC_dgvMaterias
            // 
            this.uC_dgvMaterias.BackColor = System.Drawing.Color.LightSteelBlue;
            this.uC_dgvMaterias.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_dgvMaterias.Location = new System.Drawing.Point(6, 44);
            this.uC_dgvMaterias.Name = "uC_dgvMaterias";
            this.uC_dgvMaterias.Size = new System.Drawing.Size(713, 201);
            this.uC_dgvMaterias.TabIndex = 38;
            // 
            // groupBoxAlumnos
            // 
            this.groupBoxAlumnos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxAlumnos.Controls.Add(this.buttonAlumnoQuitar);
            this.groupBoxAlumnos.Controls.Add(this.buttonAlumnoAgregar);
            this.groupBoxAlumnos.Controls.Add(this.label5);
            this.groupBoxAlumnos.Controls.Add(this.uC_dgvAlumnos);
            this.groupBoxAlumnos.Location = new System.Drawing.Point(479, 12);
            this.groupBoxAlumnos.Name = "groupBoxAlumnos";
            this.groupBoxAlumnos.Size = new System.Drawing.Size(725, 375);
            this.groupBoxAlumnos.TabIndex = 57;
            this.groupBoxAlumnos.TabStop = false;
            // 
            // buttonAlumnoQuitar
            // 
            this.buttonAlumnoQuitar.BackColor = System.Drawing.Color.White;
            this.buttonAlumnoQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlumnoQuitar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlumnoQuitar.Location = new System.Drawing.Point(133, 298);
            this.buttonAlumnoQuitar.Name = "buttonAlumnoQuitar";
            this.buttonAlumnoQuitar.Size = new System.Drawing.Size(121, 62);
            this.buttonAlumnoQuitar.TabIndex = 43;
            this.buttonAlumnoQuitar.Text = "BORRAR ALUMNO";
            this.buttonAlumnoQuitar.UseVisualStyleBackColor = false;
            this.buttonAlumnoQuitar.Click += new System.EventHandler(this.buttonAlumnoQuitar_Click);
            // 
            // buttonAlumnoAgregar
            // 
            this.buttonAlumnoAgregar.BackColor = System.Drawing.Color.White;
            this.buttonAlumnoAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlumnoAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlumnoAgregar.Location = new System.Drawing.Point(6, 298);
            this.buttonAlumnoAgregar.Name = "buttonAlumnoAgregar";
            this.buttonAlumnoAgregar.Size = new System.Drawing.Size(121, 62);
            this.buttonAlumnoAgregar.TabIndex = 44;
            this.buttonAlumnoAgregar.Text = "AGREGAR ALUMNO";
            this.buttonAlumnoAgregar.UseVisualStyleBackColor = false;
            this.buttonAlumnoAgregar.Click += new System.EventHandler(this.buttonAlumnoAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(300, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 30);
            this.label5.TabIndex = 39;
            this.label5.Text = "ALUMNOS";
            // 
            // uC_dgvAlumnos
            // 
            this.uC_dgvAlumnos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.uC_dgvAlumnos.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_dgvAlumnos.Location = new System.Drawing.Point(6, 44);
            this.uC_dgvAlumnos.Name = "uC_dgvAlumnos";
            this.uC_dgvAlumnos.Size = new System.Drawing.Size(713, 248);
            this.uC_dgvAlumnos.TabIndex = 38;
            // 
            // FrmCarreraABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1216, 712);
            this.Controls.Add(this.groupBoxAlumnos);
            this.Controls.Add(this.groupBoxMaterias);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCarreraABM";
            this.Text = "Carreras";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxMaterias.ResumeLayout(false);
            this.groupBoxMaterias.PerformLayout();
            this.groupBoxAlumnos.ResumeLayout(false);
            this.groupBoxAlumnos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCarreraAlta;
        private System.Windows.Forms.Button buttonCarreraBaja;
        private System.Windows.Forms.Button buttonCarreraModificacion;
        private System.Windows.Forms.TextBox textBoxCarreraNombre;
        private System.Windows.Forms.TextBox textBoxCarreraCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCarreraBajaMateria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregarMateria;
        private System.Windows.Forms.Label labelErrorNombre;
        private UC_dgv uC_dgvCarreras;
        private UC_dgv uC_dgvMaterias;
        private System.Windows.Forms.Button btnCorrelatividadAgregar;
        private System.Windows.Forms.Button btnCorrelatividadQuitar;
        private System.Windows.Forms.GroupBox groupBoxMaterias;
        private System.Windows.Forms.GroupBox groupBoxAlumnos;
        private System.Windows.Forms.Label label5;
        private UC_dgv uC_dgvAlumnos;
        private System.Windows.Forms.Button buttonAlumnoQuitar;
        private System.Windows.Forms.Button buttonAlumnoAgregar;
        private System.Windows.Forms.Button buttonListadoDeAlumnos;
        private System.Windows.Forms.Button buttonListadoDeMaterias;
        private System.Windows.Forms.Button buttonQuitarProfesor;
        private System.Windows.Forms.Button buttonAgregarProfesor;
    }
}