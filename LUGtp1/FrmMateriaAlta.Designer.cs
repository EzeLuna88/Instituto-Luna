namespace LUGtp1
{
    partial class FrmMateriaAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMateriaAlta));
            this.buttonMateriaAltaCancelar = new System.Windows.Forms.Button();
            this.buttonMateriaAltaAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxMateriaNombre = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMateriaAltaCancelar
            // 
            this.buttonMateriaAltaCancelar.BackColor = System.Drawing.Color.White;
            this.buttonMateriaAltaCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMateriaAltaCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMateriaAltaCancelar.Location = new System.Drawing.Point(194, 63);
            this.buttonMateriaAltaCancelar.Name = "buttonMateriaAltaCancelar";
            this.buttonMateriaAltaCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonMateriaAltaCancelar.TabIndex = 3;
            this.buttonMateriaAltaCancelar.Text = "CANCELAR";
            this.buttonMateriaAltaCancelar.UseVisualStyleBackColor = false;
            this.buttonMateriaAltaCancelar.Click += new System.EventHandler(this.buttonMateriaAltaCancelar_Click);
            // 
            // buttonMateriaAltaAceptar
            // 
            this.buttonMateriaAltaAceptar.BackColor = System.Drawing.Color.White;
            this.buttonMateriaAltaAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMateriaAltaAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMateriaAltaAceptar.Location = new System.Drawing.Point(44, 63);
            this.buttonMateriaAltaAceptar.Name = "buttonMateriaAltaAceptar";
            this.buttonMateriaAltaAceptar.Size = new System.Drawing.Size(144, 47);
            this.buttonMateriaAltaAceptar.TabIndex = 2;
            this.buttonMateriaAltaAceptar.Text = "ACEPTAR";
            this.buttonMateriaAltaAceptar.UseVisualStyleBackColor = false;
            this.buttonMateriaAltaAceptar.Click += new System.EventHandler(this.buttonMateriaAltaAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nombre";
            // 
            // labelErrorNombre
            // 
            this.labelErrorNombre.AutoSize = true;
            this.labelErrorNombre.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNombre.Location = new System.Drawing.Point(152, 46);
            this.labelErrorNombre.Name = "labelErrorNombre";
            this.labelErrorNombre.Size = new System.Drawing.Size(0, 13);
            this.labelErrorNombre.TabIndex = 78;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.textBoxMateriaNombre);
            this.groupBox2.Controls.Add(this.labelErrorNombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonMateriaAltaAceptar);
            this.groupBox2.Controls.Add(this.buttonMateriaAltaCancelar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 117);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            // 
            // textBoxMateriaNombre
            // 
            this.textBoxMateriaNombre.BackColor = System.Drawing.Color.White;
            this.textBoxMateriaNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMateriaNombre.Location = new System.Drawing.Point(146, 13);
            this.textBoxMateriaNombre.Name = "textBoxMateriaNombre";
            this.textBoxMateriaNombre.Size = new System.Drawing.Size(232, 29);
            this.textBoxMateriaNombre.TabIndex = 1;
            // 
            // FrmMateriaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(422, 141);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMateriaAlta";
            this.Text = "Alta materia";
            this.Load += new System.EventHandler(this.FrmAltaMateria_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMateriaAltaCancelar;
        private System.Windows.Forms.Button buttonMateriaAltaAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMateriaNombre;
    }
}