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
    public partial class FrmUsuarioAgregarPermisoIndependiente : Form
    {
        BLLPermisos bllPermisos;
        BLLUsuario bllUsuario;
        BEUsuario _usuario;

        public FrmUsuarioAgregarPermisoIndependiente(BEUsuario usuario)
        {
            _usuario = usuario;
            bllPermisos = new BLLPermisos();
            bllUsuario = new BLLUsuario();
            InitializeComponent();
            CargarComboBox();


        }

        public void CargarComboBox()
        {

            comboBoxPermisos.DataSource = null;
            comboBoxPermisos.DataSource = bllPermisos.CargarPermisos();
            comboBoxPermisos.ValueMember = "Codigo";
            comboBoxPermisos.DisplayMember = "Nombre";
            comboBoxPermisos.Refresh();

        }

        private void buttonMateriaAltaCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonMateriaAltaAceptar_Click(object sender, EventArgs e)
        {
            var permisoSeleccionado = (BEPermiso)comboBoxPermisos.SelectedItem;

            bool permisoAsignado = _usuario.listaComponentes
                .Any(componente => PermisoAsignadoRecursivo(componente, permisoSeleccionado.Codigo));

            if (permisoAsignado)
            {
                MessageBox.Show("El permiso ya está asignado al usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    bllUsuario.AgregarPermisoUsuario(_usuario, permisoSeleccionado);
                    MessageBox.Show($"Se ha asignado el permiso '{permisoSeleccionado.Nombre}' al usuario '{_usuario.ToString()}' exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Hubo un error al asignar el permiso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool PermisoAsignadoRecursivo(BEComponente componente, int codigoPermiso)
        {
            if (componente is BEPermiso permiso)
            {
                return permiso.Codigo == codigoPermiso;
            }
            else if (componente is BERoles rol)
            {
                foreach (var hijo in rol.Permisos)
                {
                    if (PermisoAsignadoRecursivo(hijo, codigoPermiso))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
