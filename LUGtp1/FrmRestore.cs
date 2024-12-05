using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUGtp1
{
    public partial class FrmRestore : Form
    {
        string dir;
        BLLBackup bllBackup;
        BEBackup beBackup;
        BEUsuario beUsuario;
        private string LogTxtPath = ConfigurationManager.AppSettings["LogTxtPath"];


        public FrmRestore(BEUsuario usuario)
        {
            InitializeComponent();
            CargarListView();
            bllBackup = new BLLBackup();
            beBackup = new BEBackup();
            beUsuario = usuario;
        }

        private void listViewBackups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBackups.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewBackups.SelectedItems[0];
                dir = selectedItem.Tag as string;
            }
        }

        public void CargarListView()
        {
            listViewBackups.View = View.Details;
            listViewBackups.Columns.Add("Fecha", 250, HorizontalAlignment.Left);

            string backupDir = ConfigurationManager.AppSettings["BackupPath"];
            if (Directory.Exists(backupDir))
            {
                string[] archivos = Directory.GetFiles(backupDir);
                Array.Reverse(archivos);
                foreach (string archivo in archivos)
                {
                    FileInfo fileInfo = new FileInfo(archivo);
                    ListViewItem item = new ListViewItem(fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    item.Tag = archivo;
                    listViewBackups.Items.Add(item);

                }
            }

        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if (listViewBackups.SelectedItems.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Confirma la realizacion del restore?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    GuardarEnBitacora();
                    RestaurarDesdeBackup(dir);
                    MessageBox.Show("Se ha restaurado el backup");

                }
            }
            else { MessageBox.Show("No hay backups para seleccionar"); }
        }

        public void RestaurarDesdeBackup(string direccion)
        {

            try
            {
                string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];
                string destino = Path.GetDirectoryName(xmlFilePath);
                if (!Directory.Exists(destino))
                {
                    Directory.CreateDirectory(destino);
                }
                File.Copy(direccion, xmlFilePath, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar el backup: {ex.Message}");

            }


        }

        public void GuardarEnBitacora()
        {
            /*beBackup.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
            beBackup.Hora = DateTime.Now.ToString("HH:mm:ss");
            beBackup.Usuario = beUsuario;
            beBackup.NombreArchivo = dir;
            beBackup.Tipo = "Restore";
            bllBackup.GuardarRegistroBackup(beBackup);*/
            if (!File.Exists(LogTxtPath))
            {
                using (File.Create(LogTxtPath)) { }
            }
            using (StreamWriter writer = new StreamWriter(LogTxtPath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {beUsuario.NombreDeUsuario} - {dir} - Restore");
            }
        }

    }
}