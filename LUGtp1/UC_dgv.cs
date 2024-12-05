using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LUGtp1
{
    public partial class UC_dgv : UserControl
    {
        public UC_dgv()
        {
            InitializeComponent();
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Object ob = new Object();
            ob = (Object)dataGridView1.CurrentRow.DataBoundItem;
            
        }
    }
}
