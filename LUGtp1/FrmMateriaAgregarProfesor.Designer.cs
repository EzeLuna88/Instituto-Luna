namespace LUGtp1
{
    partial class FrmMateriaAgregarProfesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMateriaAgregarProfesor));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewProfesor = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfesor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.dataGridViewProfesor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelErrorNombre);
            this.groupBox2.Controls.Add(this.buttonAceptar);
            this.groupBox2.Controls.Add(this.buttonCancelar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 302);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewProfesor
            // 
            this.dataGridViewProfesor.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProfesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProfesor.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewProfesor.Name = "dataGridViewProfesor";
            this.dataGridViewProfesor.ReadOnly = true;
            this.dataGridViewProfesor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProfesor.Size = new System.Drawing.Size(539, 224);
            this.dataGridViewProfesor.TabIndex = 79;
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
            // buttonAceptar
            // 
            this.buttonAceptar.BackColor = System.Drawing.Color.White;
            this.buttonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptar.Location = new System.Drawing.Point(112, 249);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(144, 47);
            this.buttonAceptar.TabIndex = 39;
            this.buttonAceptar.Text = "ACEPTAR";
            this.buttonAceptar.UseVisualStyleBackColor = false;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.White;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(262, 249);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonCancelar.TabIndex = 40;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FrmMateriaAgregarProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(575, 326);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMateriaAgregarProfesor";
            this.Text = "Agregar profesor";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfesor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridViewProfesor;
    }
}