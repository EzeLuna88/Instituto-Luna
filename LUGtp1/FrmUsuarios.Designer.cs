namespace LUGtp1
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonActualizarSistema = new System.Windows.Forms.Button();
            this.buttonBorrarUsuario = new System.Windows.Forms.Button();
            this.uC_dgvUsuarios = new LUGtp1.UC_dgv();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRolCrear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxRolesDisponibles = new System.Windows.Forms.ListBox();
            this.buttonRolQuitar = new System.Windows.Forms.Button();
            this.buttonRolAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxPermisosDisponibles = new System.Windows.Forms.ListBox();
            this.buttonPermisoQuitarARol = new System.Windows.Forms.Button();
            this.buttonPermisoAgregarARol = new System.Windows.Forms.Button();
            this.treeViewUsuariosPermisos = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.buttonActualizarSistema);
            this.groupBox1.Controls.Add(this.buttonBorrarUsuario);
            this.groupBox1.Controls.Add(this.uC_dgvUsuarios);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(916, 326);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Usuarios Registrados";
            // 
            // buttonActualizarSistema
            // 
            this.buttonActualizarSistema.BackColor = System.Drawing.Color.White;
            this.buttonActualizarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActualizarSistema.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonActualizarSistema.Location = new System.Drawing.Point(764, 291);
            this.buttonActualizarSistema.Name = "buttonActualizarSistema";
            this.buttonActualizarSistema.Size = new System.Drawing.Size(142, 29);
            this.buttonActualizarSistema.TabIndex = 68;
            this.buttonActualizarSistema.Text = "Actualizar Sistema";
            this.buttonActualizarSistema.UseVisualStyleBackColor = false;
            this.buttonActualizarSistema.Click += new System.EventHandler(this.buttonActualizarSistema_Click);
            // 
            // buttonBorrarUsuario
            // 
            this.buttonBorrarUsuario.BackColor = System.Drawing.Color.White;
            this.buttonBorrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonBorrarUsuario.Location = new System.Drawing.Point(11, 291);
            this.buttonBorrarUsuario.Name = "buttonBorrarUsuario";
            this.buttonBorrarUsuario.Size = new System.Drawing.Size(142, 29);
            this.buttonBorrarUsuario.TabIndex = 24;
            this.buttonBorrarUsuario.Text = "Borrar Usuario";
            this.buttonBorrarUsuario.UseVisualStyleBackColor = false;
            this.buttonBorrarUsuario.Click += new System.EventHandler(this.buttonBorrarUsuario_Click);
            // 
            // uC_dgvUsuarios
            // 
            this.uC_dgvUsuarios.BackColor = System.Drawing.Color.Beige;
            this.uC_dgvUsuarios.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_dgvUsuarios.Location = new System.Drawing.Point(11, 28);
            this.uC_dgvUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.uC_dgvUsuarios.Name = "uC_dgvUsuarios";
            this.uC_dgvUsuarios.Size = new System.Drawing.Size(898, 256);
            this.uC_dgvUsuarios.TabIndex = 67;
            this.uC_dgvUsuarios.Load += new System.EventHandler(this.uC_dgvUsuarios_Load);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.buttonRolCrear);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.listBoxRolesDisponibles);
            this.groupBox2.Controls.Add(this.buttonRolQuitar);
            this.groupBox2.Controls.Add(this.buttonRolAgregar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 235);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            // 
            // buttonRolCrear
            // 
            this.buttonRolCrear.BackColor = System.Drawing.Color.White;
            this.buttonRolCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolCrear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonRolCrear.Location = new System.Drawing.Point(6, 88);
            this.buttonRolCrear.Name = "buttonRolCrear";
            this.buttonRolCrear.Size = new System.Drawing.Size(98, 30);
            this.buttonRolCrear.TabIndex = 24;
            this.buttonRolCrear.Text = "Crear Rol";
            this.buttonRolCrear.UseVisualStyleBackColor = false;
            this.buttonRolCrear.Click += new System.EventHandler(this.buttonRolCrear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(438, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Roles disponibles";
            // 
            // listBoxRolesDisponibles
            // 
            this.listBoxRolesDisponibles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxRolesDisponibles.FormattingEnabled = true;
            this.listBoxRolesDisponibles.ItemHeight = 15;
            this.listBoxRolesDisponibles.Location = new System.Drawing.Point(237, 15);
            this.listBoxRolesDisponibles.Name = "listBoxRolesDisponibles";
            this.listBoxRolesDisponibles.Size = new System.Drawing.Size(184, 214);
            this.listBoxRolesDisponibles.TabIndex = 14;
            this.listBoxRolesDisponibles.SelectedIndexChanged += new System.EventHandler(this.listBoxRolesDisponibles_SelectedIndexChanged);
            // 
            // buttonRolQuitar
            // 
            this.buttonRolQuitar.BackColor = System.Drawing.Color.White;
            this.buttonRolQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolQuitar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonRolQuitar.Location = new System.Drawing.Point(427, 199);
            this.buttonRolQuitar.Name = "buttonRolQuitar";
            this.buttonRolQuitar.Size = new System.Drawing.Size(137, 30);
            this.buttonRolQuitar.TabIndex = 11;
            this.buttonRolQuitar.Text = "Quitar Rol";
            this.buttonRolQuitar.UseVisualStyleBackColor = false;
            this.buttonRolQuitar.Click += new System.EventHandler(this.buttonRolQuitar_Click);
            // 
            // buttonRolAgregar
            // 
            this.buttonRolAgregar.BackColor = System.Drawing.Color.White;
            this.buttonRolAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolAgregar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonRolAgregar.Location = new System.Drawing.Point(427, 163);
            this.buttonRolAgregar.Name = "buttonRolAgregar";
            this.buttonRolAgregar.Size = new System.Drawing.Size(137, 30);
            this.buttonRolAgregar.TabIndex = 9;
            this.buttonRolAgregar.Text = "Agregar Rol";
            this.buttonRolAgregar.UseVisualStyleBackColor = false;
            this.buttonRolAgregar.Click += new System.EventHandler(this.buttonRolAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(196, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Permisos disponibles";
            // 
            // listBoxPermisosDisponibles
            // 
            this.listBoxPermisosDisponibles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxPermisosDisponibles.FormattingEnabled = true;
            this.listBoxPermisosDisponibles.ItemHeight = 15;
            this.listBoxPermisosDisponibles.Location = new System.Drawing.Point(6, 15);
            this.listBoxPermisosDisponibles.Name = "listBoxPermisosDisponibles";
            this.listBoxPermisosDisponibles.Size = new System.Drawing.Size(184, 214);
            this.listBoxPermisosDisponibles.TabIndex = 12;
            this.listBoxPermisosDisponibles.SelectedIndexChanged += new System.EventHandler(this.listBoxPermisosDisponibles_SelectedIndexChanged);
            // 
            // buttonPermisoQuitarARol
            // 
            this.buttonPermisoQuitarARol.BackColor = System.Drawing.Color.White;
            this.buttonPermisoQuitarARol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPermisoQuitarARol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonPermisoQuitarARol.Location = new System.Drawing.Point(194, 199);
            this.buttonPermisoQuitarARol.Name = "buttonPermisoQuitarARol";
            this.buttonPermisoQuitarARol.Size = new System.Drawing.Size(137, 30);
            this.buttonPermisoQuitarARol.TabIndex = 6;
            this.buttonPermisoQuitarARol.Text = "Quitar Permiso ";
            this.buttonPermisoQuitarARol.UseVisualStyleBackColor = false;
            this.buttonPermisoQuitarARol.Click += new System.EventHandler(this.buttonQuitar_Click);
            // 
            // buttonPermisoAgregarARol
            // 
            this.buttonPermisoAgregarARol.BackColor = System.Drawing.Color.White;
            this.buttonPermisoAgregarARol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPermisoAgregarARol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonPermisoAgregarARol.Location = new System.Drawing.Point(194, 163);
            this.buttonPermisoAgregarARol.Name = "buttonPermisoAgregarARol";
            this.buttonPermisoAgregarARol.Size = new System.Drawing.Size(137, 30);
            this.buttonPermisoAgregarARol.TabIndex = 5;
            this.buttonPermisoAgregarARol.Text = "Agregar Permiso";
            this.buttonPermisoAgregarARol.UseVisualStyleBackColor = false;
            this.buttonPermisoAgregarARol.Click += new System.EventHandler(this.buttonAgregarPermiso_Click);
            // 
            // treeViewUsuariosPermisos
            // 
            this.treeViewUsuariosPermisos.BackColor = System.Drawing.Color.White;
            this.treeViewUsuariosPermisos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewUsuariosPermisos.HideSelection = false;
            this.treeViewUsuariosPermisos.Location = new System.Drawing.Point(6, 19);
            this.treeViewUsuariosPermisos.Name = "treeViewUsuariosPermisos";
            this.treeViewUsuariosPermisos.Size = new System.Drawing.Size(249, 542);
            this.treeViewUsuariosPermisos.TabIndex = 70;
            this.treeViewUsuariosPermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewUsuariosPermisos_AfterSelect);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox3.Controls.Add(this.treeViewUsuariosPermisos);
            this.groupBox3.Location = new System.Drawing.Point(934, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 567);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.listBoxPermisosDisponibles);
            this.groupBox5.Controls.Add(this.buttonPermisoQuitarARol);
            this.groupBox5.Controls.Add(this.buttonPermisoAgregarARol);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(587, 344);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(341, 235);
            this.groupBox5.TabIndex = 70;
            this.groupBox5.TabStop = false;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(25)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1208, 591);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios Registrados";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private UC_dgv uC_dgvUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonPermisoAgregarARol;
        private System.Windows.Forms.Button buttonPermisoQuitarARol;
        private System.Windows.Forms.TreeView treeViewUsuariosPermisos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonRolAgregar;
        private System.Windows.Forms.Button buttonRolQuitar;
        private System.Windows.Forms.ListBox listBoxPermisosDisponibles;
        private System.Windows.Forms.ListBox listBoxRolesDisponibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBorrarUsuario;
        private System.Windows.Forms.Button buttonRolCrear;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonActualizarSistema;
    }
}