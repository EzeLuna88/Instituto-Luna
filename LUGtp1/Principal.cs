using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
using BLL;
using iText.Layout.Element;
using Security;

namespace LUGtp1
{
    public partial class Principal : Form
    {

        BEProfesor profesor;
        IList<BEComponente> listaRoles;
        BLLRoles bllRoles;
        BLLProfesor bllProfesor;
        BLLPermisos bllPermisos;
        BLLUsuario bllUsuario;
        BLLBackup bllBackup;
        BEUsuario usuario;
        BEBackup beBackup;
        string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];
        string LogTxtPath = ConfigurationManager.AppSettings["LogTxtPath"];

        public Principal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            profesor = new BEProfesor();
            bllRoles = new BLLRoles();
            bllProfesor = new BLLProfesor();
            beBackup = new BEBackup();
            bllBackup = new BLLBackup();
            bllUsuario = new BLLUsuario();
            bllPermisos = new BLLPermisos();
            DeshabilitarVentanas();
        }

        public void DeshabilitarVentanas()
        {
            DashboardToolStripMenuItem.Enabled = false;
            carreraToolStripMenuItem.Enabled = false;
            alumnoToolStripMenuItem.Enabled = false;
            profesorToolStripMenuItem.Enabled = false;
            materiaToolStripMenuItem.Enabled = false;
            cobranzasToolStripMenuItem1.Enabled = false;
            controlDeAsistenciaToolStripMenuItem.Enabled = false;
            informeDeAsistenciaToolStripMenuItem.Enabled = false;
            notasToolStripMenuItem.Enabled = false;
            realizarBackupToolStripMenuItem.Enabled = false;
            realizarRestoreToolStripMenuItem.Enabled = false;
            bitacoraToolStripMenuItem.Enabled = false;
            InformesToolStripMenuItem1.Enabled = false;
        }

        private void carreraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmCarreraABM frmAbmCarrera = new FrmCarreraABM();
            frmAbmCarrera.MdiParent = this;
            frmAbmCarrera.WindowState = FormWindowState.Maximized;
            frmAbmCarrera.Show();
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmAlumnoABM frmAbmAlumno = new FrmAlumnoABM();
            frmAbmAlumno.MdiParent = this;
            frmAbmAlumno.WindowState = FormWindowState.Maximized;
            frmAbmAlumno.Show();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmMateriaABM frmAbmMateria = new FrmMateriaABM();
            frmAbmMateria.MdiParent = this;
            frmAbmMateria.WindowState = FormWindowState.Maximized;
            frmAbmMateria.Show();
        }

        private void profesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmProfesorABM frmAbmProfesor = new FrmProfesorABM();
            frmAbmProfesor.MdiParent = this;
            frmAbmProfesor.WindowState = FormWindowState.Maximized;
            frmAbmProfesor.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;

            using (FrmLogin Login = new FrmLogin())
            {
                if (Login.ShowDialog() == DialogResult.OK)
                {
                    usuario = Login.UsuarioLogueado;
                    CargarToolStripSegunPermisos(usuario);
                    menuStrip1.Enabled = true;

                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.MdiParent = this;
            dashboard.WindowState = FormWindowState.Maximized;
            dashboard.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmUsuarios frmUsuarios = new FrmUsuarios(this);
            frmUsuarios.MdiParent = this;
            frmUsuarios.WindowState = FormWindowState.Maximized;
            frmUsuarios.Show();
        }

        private void controlDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmAsistenciaControl controlDeAsistencia = new FrmAsistenciaControl(bllProfesor.DevolverProfesor(usuario));
            controlDeAsistencia.MdiParent = this;
            controlDeAsistencia.WindowState = FormWindowState.Maximized;
            controlDeAsistencia.Show();
        }

        private void cobranzasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmCobranzas frmCobranzas = new FrmCobranzas();
            frmCobranzas.MdiParent = this;
            frmCobranzas.WindowState = FormWindowState.Maximized;
            frmCobranzas.Show();
        }

        private void informeDeAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmAsistenciaInforme informeDeAsistencia = new FrmAsistenciaInforme();
            informeDeAsistencia.MdiParent = this;
            informeDeAsistencia.WindowState = FormWindowState.Maximized;
            informeDeAsistencia.Show();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmNotasAlumnos notasAlumnos = new FrmNotasAlumnos(bllProfesor.DevolverProfesor(usuario));
            notasAlumnos.MdiParent = this;
            notasAlumnos.WindowState = FormWindowState.Maximized;
            notasAlumnos.Show();
        }

        private void realizarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string backupDir = ConfigurationManager.AppSettings["BackupPath"];


            if (!Directory.Exists(backupDir))
            { Directory.CreateDirectory(backupDir); }

            string backupFileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
            string backupFilePath = Path.Combine(backupDir, backupFileName);

            DialogResult resultado = MessageBox.Show("¿Confirma la realizacion del backup?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                File.Copy(xmlFilePath, backupFilePath, true);

                MessageBox.Show("backup realizado correctamente!");
                GuardarEnBitacora(backupFilePath);
            }
        }

        private void realizarRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmRestore frmRestore = new FrmRestore(usuario);
            frmRestore.MdiParent = this;
            frmRestore.WindowState = FormWindowState.Maximized;
            frmRestore.Show();
        }

        public void GuardarEnBitacora(string direccion)
        {
            if (!File.Exists(LogTxtPath))
            {
                using (File.Create(LogTxtPath)) { }
            }
            using (StreamWriter writer = new StreamWriter(LogTxtPath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {usuario.NombreDeUsuario} - {direccion} - Backup");
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            FrmBitacoraBackup frmBitacoraBackup = new FrmBitacoraBackup();
            frmBitacoraBackup.MdiParent = this;
            frmBitacoraBackup.WindowState = FormWindowState.Maximized;
            frmBitacoraBackup.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Seguro que desea cerrar sesion?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.Yes)
            {
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form != this)
                    {
                        form.Close();
                    }
                }
                menuStrip1.Enabled = false;

                using (FrmLogin Login = new FrmLogin())
                {
                    if (Login.ShowDialog() == DialogResult.OK)
                    {
                        DeshabilitarVentanas();
                        usuario = Login.UsuarioLogueado;
                        CargarToolStripSegunPermisos(usuario);
                        menuStrip1.Enabled = true;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }

        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void CargarToolStripSegunPermisos(BEUsuario usuario)
        {
            int idPerfilDelUsuario = usuario.Codigo;
            List<string> permisosDelUsuario = bllPermisos.TraerPermisosPorUsuario(idPerfilDelUsuario);
            List<string> listaToolStrip = GetAllMenuStripItems(menuStrip1);
            foreach (ToolStripMenuItem c in menuStrip1.Items)
            {
                foreach (ToolStripMenuItem j in c.DropDownItems)
                {
                    if (j is ToolStripMenuItem)
                    {
                        if (permisosDelUsuario.Any(p => String.Equals(p.Trim(), j.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                        {
                            j.Enabled = true;
                        }
                    }
                }
            }
        }

        private List<string> GetAllMenuStripItems(MenuStrip menuStrip)
        {
            List<string> items = new List<string>();
            foreach (ToolStripMenuItem c in menuStrip.Items)
            {
                if (c.DropDownItems.Count == 0)
                    items.Add(c.Name);
                else
                {
                    foreach (ToolStripMenuItem j in c.DropDownItems)
                    {
                        if (j is ToolStripMenuItem)
                            items.Add(j.Name);
                    }
                }
            }
            return items;
        }

        private void informesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            FrmInformes frmInformes = new FrmInformes();
            frmInformes.MdiParent = this;
            frmInformes.WindowState = FormWindowState.Maximized;
            frmInformes.Show();
        }
    }
}
