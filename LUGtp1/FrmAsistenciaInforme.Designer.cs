namespace LUGtp1
{
    partial class FrmAsistenciaInforme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaInforme));
            this.buttonMostrar = new System.Windows.Forms.Button();
            this.dataGridViewAlumnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCarrera = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMateria = new System.Windows.Forms.ComboBox();
            this.labelInforme = new System.Windows.Forms.Label();
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
            this.buttonMostrar.Location = new System.Drawing.Point(520, 19);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(144, 47);
            this.buttonMostrar.TabIndex = 62;
            this.buttonMostrar.Text = "MOSTRAR";
            this.buttonMostrar.UseVisualStyleBackColor = false;
            this.buttonMostrar.Click += new System.EventHandler(this.ButtonMostrar_Click);
            // 
            // dataGridViewAlumnos
            // 
            this.dataGridViewAlumnos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnos.Location = new System.Drawing.Point(10, 81);
            this.dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            this.dataGridViewAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlumnos.Size = new System.Drawing.Size(760, 305);
            this.dataGridViewAlumnos.TabIndex = 61;
            this.dataGridViewAlumnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAlumnos_CellClick);
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
            // comboBoxCarrera
            // 
            this.comboBoxCarrera.BackColor = System.Drawing.Color.White;
            this.comboBoxCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCarrera.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCarrera.FormattingEnabled = true;
            this.comboBoxCarrera.Location = new System.Drawing.Point(146, 13);
            this.comboBoxCarrera.Name = "comboBoxCarrera";
            this.comboBoxCarrera.Size = new System.Drawing.Size(232, 29);
            this.comboBoxCarrera.TabIndex = 59;
            this.comboBoxCarrera.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCarrera_SelectedIndexChanged);
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
            // comboBoxMateria
            // 
            this.comboBoxMateria.BackColor = System.Drawing.Color.White;
            this.comboBoxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMateria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMateria.FormattingEnabled = true;
            this.comboBoxMateria.Location = new System.Drawing.Point(146, 46);
            this.comboBoxMateria.Name = "comboBoxMateria";
            this.comboBoxMateria.Size = new System.Drawing.Size(232, 29);
            this.comboBoxMateria.TabIndex = 57;
            // 
            // labelInforme
            // 
            this.labelInforme.AutoSize = true;
            this.labelInforme.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInforme.ForeColor = System.Drawing.Color.Red;
            this.labelInforme.Location = new System.Drawing.Point(14, 397);
            this.labelInforme.Name = "labelInforme";
            this.labelInforme.Size = new System.Drawing.Size(0, 15);
            this.labelInforme.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelInforme);
            this.groupBox1.Controls.Add(this.comboBoxMateria);
            this.groupBox1.Controls.Add(this.dataGridViewAlumnos);
            this.groupBox1.Controls.Add(this.buttonMostrar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxCarrera);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 430);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // FrmAsistenciaInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(799, 454);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAsistenciaInforme";
            this.Text = "Informe de asistencia y notas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMostrar;
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCarrera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMateria;
        private System.Windows.Forms.Label labelInforme;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}