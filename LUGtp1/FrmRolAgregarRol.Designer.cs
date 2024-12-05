namespace LUGtp1
{
    partial class FrmRolAgregarRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolAgregarRol));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelErrorNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRolAceptar = new System.Windows.Forms.Button();
            this.buttonMateriaAltaCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.comboBoxRoles);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelErrorNombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonRolAceptar);
            this.groupBox2.Controls.Add(this.buttonMateriaAltaCancelar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 117);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(78, 19);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(260, 21);
            this.comboBoxRoles.TabIndex = 79;
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
            this.label2.Location = new System.Drawing.Point(39, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Rol";
            // 
            // buttonRolAceptar
            // 
            this.buttonRolAceptar.BackColor = System.Drawing.Color.White;
            this.buttonRolAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRolAceptar.Location = new System.Drawing.Point(44, 57);
            this.buttonRolAceptar.Name = "buttonRolAceptar";
            this.buttonRolAceptar.Size = new System.Drawing.Size(144, 47);
            this.buttonRolAceptar.TabIndex = 2;
            this.buttonRolAceptar.Text = "ACEPTAR";
            this.buttonRolAceptar.UseVisualStyleBackColor = false;
            this.buttonRolAceptar.Click += new System.EventHandler(this.buttonRolAceptar_Click);
            // 
            // buttonMateriaAltaCancelar
            // 
            this.buttonMateriaAltaCancelar.BackColor = System.Drawing.Color.White;
            this.buttonMateriaAltaCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMateriaAltaCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMateriaAltaCancelar.Location = new System.Drawing.Point(194, 57);
            this.buttonMateriaAltaCancelar.Name = "buttonMateriaAltaCancelar";
            this.buttonMateriaAltaCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonMateriaAltaCancelar.TabIndex = 3;
            this.buttonMateriaAltaCancelar.Text = "CANCELAR";
            this.buttonMateriaAltaCancelar.UseVisualStyleBackColor = false;
            this.buttonMateriaAltaCancelar.Click += new System.EventHandler(this.buttonMateriaAltaCancelar_Click);
            // 
            // FrmRolAgregarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(418, 137);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRolAgregarRol";
            this.Text = "Agregar Rol";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelErrorNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRolAceptar;
        private System.Windows.Forms.Button buttonMateriaAltaCancelar;
    }
}