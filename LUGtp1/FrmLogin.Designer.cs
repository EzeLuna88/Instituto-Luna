namespace LUGtp1
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoginCancelar = new System.Windows.Forms.Button();
            this.buttonLoginIniciarSesion = new System.Windows.Forms.Button();
            this.textBoxLoginUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLoginContrasenia = new System.Windows.Forms.TextBox();
            this.buttonNuevoUsuario = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBoxOjoPassword = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOjoPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "Contraseña";
            // 
            // buttonLoginCancelar
            // 
            this.buttonLoginCancelar.BackColor = System.Drawing.Color.White;
            this.buttonLoginCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoginCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginCancelar.Location = new System.Drawing.Point(192, 103);
            this.buttonLoginCancelar.Name = "buttonLoginCancelar";
            this.buttonLoginCancelar.Size = new System.Drawing.Size(144, 47);
            this.buttonLoginCancelar.TabIndex = 4;
            this.buttonLoginCancelar.Text = "CANCELAR";
            this.buttonLoginCancelar.UseVisualStyleBackColor = false;
            this.buttonLoginCancelar.Click += new System.EventHandler(this.buttonLoginCancelar_Click);
            // 
            // buttonLoginIniciarSesion
            // 
            this.buttonLoginIniciarSesion.BackColor = System.Drawing.Color.White;
            this.buttonLoginIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoginIniciarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginIniciarSesion.Location = new System.Drawing.Point(42, 103);
            this.buttonLoginIniciarSesion.Name = "buttonLoginIniciarSesion";
            this.buttonLoginIniciarSesion.Size = new System.Drawing.Size(144, 47);
            this.buttonLoginIniciarSesion.TabIndex = 3;
            this.buttonLoginIniciarSesion.Text = "INICIAR SESION";
            this.buttonLoginIniciarSesion.UseVisualStyleBackColor = false;
            this.buttonLoginIniciarSesion.Click += new System.EventHandler(this.buttonLoginIniciarSesion_Click);
            this.buttonLoginIniciarSesion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonLoginIniciarSesion_KeyPress);
            // 
            // textBoxLoginUsuario
            // 
            this.textBoxLoginUsuario.BackColor = System.Drawing.Color.White;
            this.textBoxLoginUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLoginUsuario.Location = new System.Drawing.Point(146, 13);
            this.textBoxLoginUsuario.Name = "textBoxLoginUsuario";
            this.textBoxLoginUsuario.Size = new System.Drawing.Size(232, 29);
            this.textBoxLoginUsuario.TabIndex = 1;
            this.textBoxLoginUsuario.TextChanged += new System.EventHandler(this.textBoxLoginUsuario_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Usuario";
            // 
            // textBoxLoginContrasenia
            // 
            this.textBoxLoginContrasenia.BackColor = System.Drawing.Color.White;
            this.textBoxLoginContrasenia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLoginContrasenia.Location = new System.Drawing.Point(146, 46);
            this.textBoxLoginContrasenia.Name = "textBoxLoginContrasenia";
            this.textBoxLoginContrasenia.Size = new System.Drawing.Size(204, 29);
            this.textBoxLoginContrasenia.TabIndex = 2;
            this.textBoxLoginContrasenia.TextChanged += new System.EventHandler(this.textBoxLoginContrasenia_TextChanged);
            // 
            // buttonNuevoUsuario
            // 
            this.buttonNuevoUsuario.BackColor = System.Drawing.Color.White;
            this.buttonNuevoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNuevoUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNuevoUsuario.Location = new System.Drawing.Point(120, 156);
            this.buttonNuevoUsuario.Name = "buttonNuevoUsuario";
            this.buttonNuevoUsuario.Size = new System.Drawing.Size(144, 47);
            this.buttonNuevoUsuario.TabIndex = 5;
            this.buttonNuevoUsuario.Text = "NUEVO USUARIO";
            this.buttonNuevoUsuario.UseVisualStyleBackColor = false;
            this.buttonNuevoUsuario.Click += new System.EventHandler(this.buttonNuevoUsuario_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Roboto Cn", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(143, 82);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 58;
            this.labelError.Click += new System.EventHandler(this.labelError_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.pictureBoxOjoPassword);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labelError);
            this.groupBox2.Controls.Add(this.textBoxLoginUsuario);
            this.groupBox2.Controls.Add(this.buttonNuevoUsuario);
            this.groupBox2.Controls.Add(this.buttonLoginIniciarSesion);
            this.groupBox2.Controls.Add(this.textBoxLoginContrasenia);
            this.groupBox2.Controls.Add(this.buttonLoginCancelar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 218);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // pictureBoxOjoPassword
            // 
            this.pictureBoxOjoPassword.Image = global::InstitutoLuna.Properties.Resources.eye_icon_1457;
            this.pictureBoxOjoPassword.Location = new System.Drawing.Point(356, 48);
            this.pictureBoxOjoPassword.Name = "pictureBoxOjoPassword";
            this.pictureBoxOjoPassword.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxOjoPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOjoPassword.TabIndex = 59;
            this.pictureBoxOjoPassword.TabStop = false;
            this.pictureBoxOjoPassword.Click += new System.EventHandler(this.pictureBoxOjoPassword_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(416, 241);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOjoPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLoginCancelar;
        private System.Windows.Forms.Button buttonLoginIniciarSesion;
        private System.Windows.Forms.TextBox textBoxLoginUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLoginContrasenia;
        private System.Windows.Forms.Button buttonNuevoUsuario;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBoxOjoPassword;
    }
}