namespace LUGtp1
{
    partial class FrmCarreraAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarreraAlta));
            this.textBoxCarreraNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCarreraAlta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCarreraNombre
            // 
            this.textBoxCarreraNombre.BackColor = System.Drawing.Color.White;
            this.textBoxCarreraNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCarreraNombre.Location = new System.Drawing.Point(146, 13);
            this.textBoxCarreraNombre.Name = "textBoxCarreraNombre";
            this.textBoxCarreraNombre.Size = new System.Drawing.Size(232, 29);
            this.textBoxCarreraNombre.TabIndex = 30;
            this.textBoxCarreraNombre.TextChanged += new System.EventHandler(this.textBoxCarreraNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nombre";
            // 
            // buttonCarreraAlta
            // 
            this.buttonCarreraAlta.BackColor = System.Drawing.Color.White;
            this.buttonCarreraAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCarreraAlta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarreraAlta.Location = new System.Drawing.Point(50, 59);
            this.buttonCarreraAlta.Name = "buttonCarreraAlta";
            this.buttonCarreraAlta.Size = new System.Drawing.Size(144, 47);
            this.buttonCarreraAlta.TabIndex = 35;
            this.buttonCarreraAlta.Text = "ACEPTAR";
            this.buttonCarreraAlta.UseVisualStyleBackColor = false;
            this.buttonCarreraAlta.Click += new System.EventHandler(this.buttonCarreraAlta_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(200, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 47);
            this.button1.TabIndex = 36;
            this.button1.Text = "CANCELAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelErrorNombre
            // 
            this.labelErrorNombre.AutoSize = true;
            this.labelErrorNombre.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.labelErrorNombre.Location = new System.Drawing.Point(143, 43);
            this.labelErrorNombre.Name = "labelErrorNombre";
            this.labelErrorNombre.Size = new System.Drawing.Size(0, 13);
            this.labelErrorNombre.TabIndex = 77;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labelErrorNombre);
            this.groupBox2.Controls.Add(this.textBoxCarreraNombre);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.buttonCarreraAlta);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 118);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            // 
            // FrmAltaCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(428, 144);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAltaCarrera";
            this.Text = "Alta carrera";
            this.Load += new System.EventHandler(this.FrmAltaCarrera_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCarreraNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCarreraAlta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}