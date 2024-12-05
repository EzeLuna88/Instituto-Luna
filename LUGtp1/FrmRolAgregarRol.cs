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
    public partial class FrmRolAgregarRol : Form
    {
        BLLRoles bllRoles;
        BERoles beRoles;
        BEUsuario beUsuario;
        public FrmRolAgregarRol(BERoles rol, BEUsuario usuarioSeleccionado)
        {
            beUsuario = usuarioSeleccionado;
            beRoles = rol;
            bllRoles = new BLLRoles();
            InitializeComponent();
            CargarComboBox();
        }



        private void buttonRolAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var rolSeleccionado = (BERoles)comboBoxRoles.SelectedItem;

                if (beRoles.Nombre == rolSeleccionado.Nombre)
                {
                    MessageBox.Show("No se puede agregar un rol dentro de sí mismo.");
                    return;
                }

                if (beUsuario.listaComponentes.Any(c =>
                    c is BERoles rol &&
                     RolExisteRecursivamente(rol, rolSeleccionado.Nombre)))
                {
                    MessageBox.Show("El rol seleccionado ya está asociado.");
                    return;
                }

                bllRoles.AgregarHijo(beRoles, rolSeleccionado);
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RolExisteRecursivamente(BERoles rol, string nombreRol)
        {
            // Verifica si el rol actual coincide con el rol seleccionado
            if (rol.Nombre == nombreRol)
            {
                return true;
            }

            // Verifica recursivamente los roles hijos
            foreach (var componente in rol.Permisos)
            {
                if (componente is BERoles rolHijo)
                {
                    if (RolExisteRecursivamente(rolHijo, nombreRol))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void CargarComboBox()
        {
            comboBoxRoles.DataSource = null;
            comboBoxRoles.DataSource = bllRoles.CargarRoles();
            comboBoxRoles.ValueMember = "Codigo";
            comboBoxRoles.DisplayMember = "Nombre";
            comboBoxRoles.Refresh();
        }

        private void buttonMateriaAltaCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
