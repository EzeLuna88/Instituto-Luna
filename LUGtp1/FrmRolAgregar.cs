using BE;
using BLL;
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
    public partial class FrmRolAgregar : Form
    {
        BERoles rol;
        BLLRoles bllRoles;
        IList<BEComponente> roles;
        public FrmRolAgregar(IList<BEComponente> listaRoles)
        {
            rol = new BERoles();
            bllRoles = new BLLRoles(); 
            InitializeComponent();
            roles = listaRoles;
        }

        private void buttonRolAceptar_Click(object sender, EventArgs e)
        {
            rol._nombre = textBoxRolNombre.Text;
            if (roles.Any(r => r.Nombre.Equals(rol._nombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("El nombre del rol ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult Result = MessageBox.Show("¿Está seguro que desea crear este rol?",
                                                             "Confirmar",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                bllRoles.AgregarRol(rol);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            

        }

        private void buttonRolCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
