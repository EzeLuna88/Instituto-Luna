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
    public partial class FrmBitacoraBackup : Form
    {
        private string LogTxtPath = ConfigurationManager.AppSettings["LogTxtPath"];

        public FrmBitacoraBackup()
        {
            InitializeComponent();
            CargarLog();
        }

        

        public void CargarLog()
        {
            if (File.Exists(LogTxtPath))
            {
                richTextBoxLog.Text = File.ReadAllText(LogTxtPath);
            }
            else
            {
                richTextBoxLog.Text = "No se encontraron registros de bitácora.";
            }
        }


    }
}
