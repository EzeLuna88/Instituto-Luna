namespace LUGtp1
{
    partial class FrmCobranzas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCobranzas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uC_dgv1 = new LUGtp1.UC_dgv();
            this.buttonPagarMatricula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPrecioMatricula = new System.Windows.Forms.Label();
            this.buttonModificarPrecio = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.uC_dgv1);
            this.groupBox1.Controls.Add(this.buttonPagarMatricula);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1186, 393);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // uC_dgv1
            // 
            this.uC_dgv1.BackColor = System.Drawing.Color.Beige;
            this.uC_dgv1.Location = new System.Drawing.Point(7, 26);
            this.uC_dgv1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_dgv1.Name = "uC_dgv1";
            this.uC_dgv1.Size = new System.Drawing.Size(1145, 290);
            this.uC_dgv1.TabIndex = 0;
            // 
            // buttonPagarMatricula
            // 
            this.buttonPagarMatricula.BackColor = System.Drawing.Color.White;
            this.buttonPagarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPagarMatricula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPagarMatricula.Location = new System.Drawing.Point(7, 323);
            this.buttonPagarMatricula.Name = "buttonPagarMatricula";
            this.buttonPagarMatricula.Size = new System.Drawing.Size(144, 55);
            this.buttonPagarMatricula.TabIndex = 36;
            this.buttonPagarMatricula.Text = "PAGAR MATRICULA";
            this.buttonPagarMatricula.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPagarMatricula.UseVisualStyleBackColor = false;
            this.buttonPagarMatricula.Click += new System.EventHandler(this.buttonPagarMatricula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Precio matricula:";
            // 
            // labelPrecioMatricula
            // 
            this.labelPrecioMatricula.AutoSize = true;
            this.labelPrecioMatricula.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioMatricula.Location = new System.Drawing.Point(174, 16);
            this.labelPrecioMatricula.Name = "labelPrecioMatricula";
            this.labelPrecioMatricula.Size = new System.Drawing.Size(0, 21);
            this.labelPrecioMatricula.TabIndex = 38;
            // 
            // buttonModificarPrecio
            // 
            this.buttonModificarPrecio.BackColor = System.Drawing.Color.White;
            this.buttonModificarPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModificarPrecio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificarPrecio.Location = new System.Drawing.Point(7, 43);
            this.buttonModificarPrecio.Name = "buttonModificarPrecio";
            this.buttonModificarPrecio.Size = new System.Drawing.Size(144, 55);
            this.buttonModificarPrecio.TabIndex = 39;
            this.buttonModificarPrecio.Text = "MODIFICAR PRECIO";
            this.buttonModificarPrecio.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonModificarPrecio.UseVisualStyleBackColor = false;
            this.buttonModificarPrecio.Click += new System.EventHandler(this.buttonModificarPrecio_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonModificarPrecio);
            this.groupBox2.Controls.Add(this.labelPrecioMatricula);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1186, 104);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // FrmCobranzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1210, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCobranzas";
            this.Text = "Matricula";
            this.Load += new System.EventHandler(this.FrmCobranzas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPagarMatricula;
        private UC_dgv uC_dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPrecioMatricula;
        private System.Windows.Forms.Button buttonModificarPrecio;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}