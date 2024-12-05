namespace LUGtp1
{
    partial class FrmMatriculaModificarPrecio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatriculaModificarPrecio));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxMatriculaPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMatriculaAceptar = new System.Windows.Forms.Button();
            this.buttonMatriculaCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.textBoxMatriculaPrecio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelErrorNombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonMatriculaAceptar);
            this.groupBox2.Controls.Add(this.buttonMatriculaCancelar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 102);
            this.groupBox2.TabIndex = 90;
            this.groupBox2.TabStop = false;
            // 
            // textBoxMatriculaPrecio
            // 
            this.textBoxMatriculaPrecio.BackColor = System.Drawing.Color.White;
            this.textBoxMatriculaPrecio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatriculaPrecio.Location = new System.Drawing.Point(75, 13);
            this.textBoxMatriculaPrecio.Name = "textBoxMatriculaPrecio";
            this.textBoxMatriculaPrecio.Size = new System.Drawing.Size(303, 29);
            this.textBoxMatriculaPrecio.TabIndex = 1;
            this.textBoxMatriculaPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMatriculaPrecio_KeyPress);
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
            this.labelErrorNombre.Location = new System.Drawing.Point(143, 76);
            this.labelErrorNombre.Name = "labelErrorNombre";
            this.labelErrorNombre.Size = new System.Drawing.Size(0, 13);
            this.labelErrorNombre.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Precio";
            // 
            // buttonMatriculaAceptar
            // 
            this.buttonMatriculaAceptar.BackColor = System.Drawing.Color.White;
            this.buttonMatriculaAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMatriculaAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMatriculaAceptar.Location = new System.Drawing.Point(45, 45);
            this.buttonMatriculaAceptar.Name = "buttonMatriculaAceptar";
            this.buttonMatriculaAceptar.Size = new System.Drawing.Size(144, 47);
            this.buttonMatriculaAceptar.TabIndex = 2;
            this.buttonMatriculaAceptar.Text = "ACEPTAR";
            this.buttonMatriculaAceptar.UseVisualStyleBackColor = false;
            this.buttonMatriculaAceptar.Click += new System.EventHandler(this.buttonMatriculaAceptar_Click);
            // 
            // buttonMatriculaCancelar
            // 
            this.buttonMatriculaCancelar.BackColor = System.Drawing.Color.White;
            this.buttonMatriculaCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMatriculaCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMatriculaCancelar.Location = new System.Drawing.Point(195, 45);
            this.buttonMatriculaCancelar.Name = "buttonMatriculaCancelar";
            this.buttonMatriculaCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonMatriculaCancelar.TabIndex = 3;
            this.buttonMatriculaCancelar.Text = "CANCELAR";
            this.buttonMatriculaCancelar.UseVisualStyleBackColor = false;
            this.buttonMatriculaCancelar.Click += new System.EventHandler(this.buttonMatriculaCancelar_Click);
            // 
            // FrmMatriculaModificarPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(420, 127);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMatriculaModificarPrecio";
            this.Text = "Matricula - Modificar precio";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMatriculaPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonMatriculaAceptar;
        private System.Windows.Forms.Button buttonMatriculaCancelar;
    }
}