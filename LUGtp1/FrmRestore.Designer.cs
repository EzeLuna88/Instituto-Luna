namespace LUGtp1
{
    partial class FrmRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRestore));
            this.buttonRestore = new System.Windows.Forms.Button();
            this.listViewBackups = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRestore
            // 
            this.buttonRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestore.Location = new System.Drawing.Point(6, 214);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(144, 47);
            this.buttonRestore.TabIndex = 0;
            this.buttonRestore.Text = "RESTORE";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // listViewBackups
            // 
            this.listViewBackups.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBackups.HideSelection = false;
            this.listViewBackups.Location = new System.Drawing.Point(6, 19);
            this.listViewBackups.Name = "listViewBackups";
            this.listViewBackups.Size = new System.Drawing.Size(676, 189);
            this.listViewBackups.TabIndex = 1;
            this.listViewBackups.UseCompatibleStateImageBehavior = false;
            this.listViewBackups.SelectedIndexChanged += new System.EventHandler(this.listViewBackups_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.listViewBackups);
            this.groupBox1.Controls.Add(this.buttonRestore);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // FrmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(713, 293);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRestore";
            this.Text = "Restore";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.ListView listViewBackups;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}