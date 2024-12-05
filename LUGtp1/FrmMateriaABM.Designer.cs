namespace LUGtp1
{
    partial class FrmMateriaABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMateriaABM));
            this.buttonMateriaAlta = new System.Windows.Forms.Button();
            this.buttonMateriaBaja = new System.Windows.Forms.Button();
            this.buttonMateriaModificacion = new System.Windows.Forms.Button();
            this.textBoxMateriaNombre = new System.Windows.Forms.TextBox();
            this.textBoxMateriaCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_dgv1 = new LUGtp1.UC_dgv();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMateriaAlta
            // 
            this.buttonMateriaAlta.BackColor = System.Drawing.Color.White;
            this.buttonMateriaAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMateriaAlta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMateriaAlta.Location = new System.Drawing.Point(488, 88);
            this.buttonMateriaAlta.Name = "buttonMateriaAlta";
            this.buttonMateriaAlta.Size = new System.Drawing.Size(144, 47);
            this.buttonMateriaAlta.TabIndex = 42;
            this.buttonMateriaAlta.Text = "ALTA";
            this.buttonMateriaAlta.UseVisualStyleBackColor = false;
            this.buttonMateriaAlta.Click += new System.EventHandler(this.buttonMateriaAlta_Click);
            // 
            // buttonMateriaBaja
            // 
            this.buttonMateriaBaja.BackColor = System.Drawing.Color.White;
            this.buttonMateriaBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMateriaBaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMateriaBaja.Location = new System.Drawing.Point(6, 88);
            this.buttonMateriaBaja.Name = "buttonMateriaBaja";
            this.buttonMateriaBaja.Size = new System.Drawing.Size(144, 47);
            this.buttonMateriaBaja.TabIndex = 41;
            this.buttonMateriaBaja.Text = "BAJA";
            this.buttonMateriaBaja.UseVisualStyleBackColor = false;
            this.buttonMateriaBaja.Click += new System.EventHandler(this.buttonMateriaBaja_Click);
            // 
            // buttonMateriaModificacion
            // 
            this.buttonMateriaModificacion.BackColor = System.Drawing.Color.White;
            this.buttonMateriaModificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMateriaModificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMateriaModificacion.Location = new System.Drawing.Point(156, 88);
            this.buttonMateriaModificacion.Name = "buttonMateriaModificacion";
            this.buttonMateriaModificacion.Size = new System.Drawing.Size(144, 47);
            this.buttonMateriaModificacion.TabIndex = 40;
            this.buttonMateriaModificacion.Text = "MODIFICACION";
            this.buttonMateriaModificacion.UseVisualStyleBackColor = false;
            this.buttonMateriaModificacion.Click += new System.EventHandler(this.buttonMateriaModificacion_Click);
            // 
            // textBoxMateriaNombre
            // 
            this.textBoxMateriaNombre.BackColor = System.Drawing.Color.White;
            this.textBoxMateriaNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMateriaNombre.Location = new System.Drawing.Point(161, 50);
            this.textBoxMateriaNombre.Name = "textBoxMateriaNombre";
            this.textBoxMateriaNombre.Size = new System.Drawing.Size(232, 29);
            this.textBoxMateriaNombre.TabIndex = 39;
            this.textBoxMateriaNombre.TextChanged += new System.EventHandler(this.textBoxMateriaNombre_TextChanged);
            // 
            // textBoxMateriaCodigo
            // 
            this.textBoxMateriaCodigo.BackColor = System.Drawing.Color.White;
            this.textBoxMateriaCodigo.Enabled = false;
            this.textBoxMateriaCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMateriaCodigo.Location = new System.Drawing.Point(161, 17);
            this.textBoxMateriaCodigo.Name = "textBoxMateriaCodigo";
            this.textBoxMateriaCodigo.Size = new System.Drawing.Size(232, 29);
            this.textBoxMateriaCodigo.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 36;
            this.label1.Text = "Codigo";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.labelErrorNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonMateriaAlta);
            this.groupBox1.Controls.Add(this.textBoxMateriaCodigo);
            this.groupBox1.Controls.Add(this.buttonMateriaBaja);
            this.groupBox1.Controls.Add(this.textBoxMateriaNombre);
            this.groupBox1.Controls.Add(this.buttonMateriaModificacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 141);
            this.groupBox1.TabIndex = 44;
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
            this.labelErrorNombre.TabIndex = 77;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.uC_dgv1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(643, 436);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            // 
            // uC_dgv1
            // 
            this.uC_dgv1.BackColor = System.Drawing.Color.White;
            this.uC_dgv1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_dgv1.Location = new System.Drawing.Point(6, 44);
            this.uC_dgv1.Name = "uC_dgv1";
            this.uC_dgv1.Size = new System.Drawing.Size(631, 351);
            this.uC_dgv1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 30);
            this.label3.TabIndex = 36;
            this.label3.Text = "LISTA DE MATERIAS";
            // 
            // FrmMateriaABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1195, 604);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMateriaABM";
            this.Text = "Materias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonMateriaAlta;
        private System.Windows.Forms.Button buttonMateriaBaja;
        private System.Windows.Forms.Button buttonMateriaModificacion;
        private System.Windows.Forms.TextBox textBoxMateriaNombre;
        private System.Windows.Forms.TextBox textBoxMateriaCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelErrorNombre;
        private UC_dgv uC_dgv1;
    }
}