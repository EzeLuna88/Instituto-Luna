namespace LUGtp1
{
    partial class FrmRolAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolAgregar));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRolCancelar = new System.Windows.Forms.Button();
            this.textBoxRolNombre = new System.Windows.Forms.TextBox();
            this.buttonRolAceptar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonRolCancelar);
            this.groupBox2.Controls.Add(this.textBoxRolNombre);
            this.groupBox2.Controls.Add(this.buttonRolAceptar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 106);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(143, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(143, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nombre";
            // 
            // buttonRolCancelar
            // 
            this.buttonRolCancelar.BackColor = System.Drawing.Color.White;
            this.buttonRolCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRolCancelar.Location = new System.Drawing.Point(192, 47);
            this.buttonRolCancelar.Name = "buttonRolCancelar";
            this.buttonRolCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonRolCancelar.TabIndex = 45;
            this.buttonRolCancelar.Text = "CANCELAR";
            this.buttonRolCancelar.UseVisualStyleBackColor = false;
            this.buttonRolCancelar.Click += new System.EventHandler(this.buttonRolCancelar_Click);
            // 
            // textBoxRolNombre
            // 
            this.textBoxRolNombre.BackColor = System.Drawing.Color.White;
            this.textBoxRolNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRolNombre.Location = new System.Drawing.Point(146, 12);
            this.textBoxRolNombre.Name = "textBoxRolNombre";
            this.textBoxRolNombre.Size = new System.Drawing.Size(232, 29);
            this.textBoxRolNombre.TabIndex = 40;
            // 
            // buttonRolAceptar
            // 
            this.buttonRolAceptar.BackColor = System.Drawing.Color.White;
            this.buttonRolAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRolAceptar.Location = new System.Drawing.Point(42, 47);
            this.buttonRolAceptar.Name = "buttonRolAceptar";
            this.buttonRolAceptar.Size = new System.Drawing.Size(144, 47);
            this.buttonRolAceptar.TabIndex = 44;
            this.buttonRolAceptar.Text = "ACEPTAR";
            this.buttonRolAceptar.UseVisualStyleBackColor = false;
            this.buttonRolAceptar.Click += new System.EventHandler(this.buttonRolAceptar_Click);
            // 
            // FrmRolAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(420, 129);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRolAgregar";
            this.Text = "Agregar Rol";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRolCancelar;
        private System.Windows.Forms.TextBox textBoxRolNombre;
        private System.Windows.Forms.Button buttonRolAceptar;
    }
}