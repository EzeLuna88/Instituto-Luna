using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BE;
using BLL;
using iText.Layout.Element;
using Security;

namespace LUGtp1
{
    public partial class FrmUsuarios : Form
    {
        BLLRoles bllRoles;
        BLLPermisos bllPermisos;
        BLLUsuario bllUsuario;
        IList<BEComponente> listaRoles;
        BERoles beRoles;
        BEPermiso bePermiso;
        IList<BEComponente> listaPermisos;
        BEUsuario usuarioSeleccionado;
        public event EventHandler RolesModificados;
        BEPermiso permisoDisponibleSeleccionado;
        BERoles rolAsociadoSeleccionado;
        BERoles rolDisponibleSeleccionado;
        BEPermiso permisoAsociadoSeleccionado;
        private Principal parentForm;


        public FrmUsuarios(Principal formPrincipal)
        {
            bllRoles = new BLLRoles();
            bllPermisos = new BLLPermisos();
            bllUsuario = new BLLUsuario();
            usuarioSeleccionado = new BEUsuario();
            InitializeComponent();
            uC_dgvUsuarios.dataGridView1.CellClick += new DataGridViewCellEventHandler(uc_dgvUsuarios_datagridview1_CellClick);
            CargarDataGrid();
            this.parentForm = formPrincipal;
        }

        private void uc_dgvUsuarios_datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                usuarioSeleccionado = (BEUsuario)uC_dgvUsuarios.dataGridView1.CurrentRow.DataBoundItem;
                RefrescarTreeView();
                CargarListaRolesDisponibles();
                CargarListaPermisosDisponibles();
            }
        }

        private void RefrescarTreeView()
        {
            treeViewUsuariosPermisos.Nodes.Clear();
            TreeNode nodoUsuario = new TreeNode($"{usuarioSeleccionado.Nombre} {usuarioSeleccionado.Apellido}")
            {
                Tag = usuarioSeleccionado
            };


            foreach (BEComponente componente in usuarioSeleccionado.listaComponentes)
            {
                ArmarTreeView(componente, nodoUsuario);
            }
            treeViewUsuariosPermisos.Nodes.Add(nodoUsuario);
            treeViewUsuariosPermisos.ExpandAll();

        }

        private void ArmarTreeView(BEComponente componente, TreeNode nodoPadre)
        {
            TreeNode nodoComponente = new TreeNode(componente.Nombre);
            nodoComponente.Tag = componente;

            if (componente is BERoles rol)
            {
                foreach (BEComponente hijo in rol.Permisos)
                {
                    ArmarTreeView(hijo, nodoComponente);
                }
            }

            nodoPadre.Nodes.Add(nodoComponente);
        }

        public void CargarListaRolesDisponibles()
        {
            listBoxRolesDisponibles.Items.Clear();
            listaRoles = bllRoles.CargarRoles().ToArray();

            var codigosRolesAsociados = ListaCodigosRolesAsociados(usuarioSeleccionado.listaComponentes);

            foreach (BERoles rol in listaRoles)
            {
                if (!codigosRolesAsociados.Contains(rol.Codigo))
                {
                    listBoxRolesDisponibles.Items.Add(new ListItem { Nombre = rol.Nombre, Codigo = rol.Codigo });
                }
            }
        }


        private List<int> ListaCodigosRolesAsociados(List<BEComponente> listaComponentes)
        {
            var codigosRolesAsociados = new List<int>();
            ObtenerCodigosRolesAsociados(listaComponentes, codigosRolesAsociados);
            return codigosRolesAsociados;
        }

        private void ObtenerCodigosRolesAsociados(List<BEComponente> listaComponentes, List<int> codigosRolesAsociados)
        {

            foreach (BEComponente componente in listaComponentes)
            {
                if (componente is BERoles rol)
                {
                    codigosRolesAsociados.Add(rol.Codigo);
                    ObtenerCodigosRolesAsociados((List<BEComponente>)rol.Hijos, codigosRolesAsociados);
                }
            }

        }


        public void CargarDataGrid()
        {
            try
            {
                int selectedIndex = -1;
                if (uC_dgvUsuarios.dataGridView1.CurrentRow != null)
                {
                    selectedIndex = uC_dgvUsuarios.dataGridView1.CurrentRow.Index;
                }
                List<BEUsuario> listaDeUsuarios = bllUsuario.ListaUsuarios();

                foreach (BEUsuario usuario in listaDeUsuarios)
                {
                    usuario.Contrasenia = Encriptar.Desencriptacion(usuario.Contrasenia);
                }
                uC_dgvUsuarios.dataGridView1.DataSource = null;
                uC_dgvUsuarios.dataGridView1.DataSource = listaDeUsuarios;
                uC_dgvUsuarios.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                uC_dgvUsuarios.dataGridView1.Columns["NombreDeUsuario"].HeaderText = "Nombre de usuario";
                uC_dgvUsuarios.dataGridView1.Columns["Contrasenia"].HeaderText = "Contraseña";
                uC_dgvUsuarios.dataGridView1.Font = new Font("Segoe UI", 10);
                uC_dgvUsuarios.dataGridView1.Size = new Size(898, 256);

                if (selectedIndex >= 0 && selectedIndex < uC_dgvUsuarios.dataGridView1.Rows.Count)
                {
                    uC_dgvUsuarios.dataGridView1.Rows[selectedIndex].Selected = true;
                    uC_dgvUsuarios.dataGridView1.CurrentCell = uC_dgvUsuarios.dataGridView1.Rows[selectedIndex].Cells[0];
                    usuarioSeleccionado = (BEUsuario)uC_dgvUsuarios.dataGridView1.CurrentRow.DataBoundItem;
                }
                else if (uC_dgvUsuarios.dataGridView1.Rows.Count > 0)
                {
                    uC_dgvUsuarios.dataGridView1.Rows[0].Selected = true;
                    uC_dgvUsuarios.dataGridView1.CurrentCell = uC_dgvUsuarios.dataGridView1.Rows[0].Cells[0];
                    usuarioSeleccionado = (BEUsuario)uC_dgvUsuarios.dataGridView1.CurrentRow.DataBoundItem;
                }

                RefrescarTreeView();
                CargarListaPermisosDisponibles();
                CargarListaRolesDisponibles();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void CargarListaPermisosDisponibles()
        {
            listBoxPermisosDisponibles.Items.Clear();
            listaPermisos = bllPermisos.CargarPermisos().ToArray();

            var codigosPermisosAsociados = ListaCodigosPermisosAsociados(usuarioSeleccionado.listaComponentes);

            foreach (BEPermiso permiso in listaPermisos)
            {
                if (!codigosPermisosAsociados.Contains(permiso.Codigo))
                {
                    listBoxPermisosDisponibles.Items.Add(new ListItem { Nombre = permiso.Nombre, Codigo = permiso.Codigo });
                }
            }

        }

        private List<int> ListaCodigosPermisosAsociados(List<BEComponente> listaComponentes)
        {
            var codigosPermisosAsociados = new List<int>();
            ObtenerCodigosPermisosAsociados(listaComponentes, codigosPermisosAsociados);
            return codigosPermisosAsociados;
        }

        private void ObtenerCodigosPermisosAsociados(List<BEComponente> listaComponentes, List<int> codigosPermisosAsociados)
        {

            foreach (BEComponente componente in listaComponentes)
            {
                if (componente is BEPermiso permiso)
                {
                    codigosPermisosAsociados.Add(permiso.Codigo);
                }
                else if (componente is BERoles rol)
                {
                    ObtenerCodigosPermisosAsociados((List<BEComponente>)rol.Hijos, codigosPermisosAsociados);
                }
            }

        }



        public class ListItem
        {
            public string Nombre { get; set; }
            public int Codigo { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }


        private void buttonAgregarPermiso_Click(object sender, EventArgs e)
        {
            TreeNode nodoUsuario = treeViewUsuariosPermisos.Nodes.Count > 0 ? treeViewUsuariosPermisos.Nodes[0] : null;

            if (nodoUsuario != null && nodoUsuario.Nodes.Count == 0)
            {
                FrmUsuarioAgregarPermisoIndependiente frmUsuarioAgregarPermisoIndependiente = new FrmUsuarioAgregarPermisoIndependiente(usuarioSeleccionado);
                frmUsuarioAgregarPermisoIndependiente.ShowDialog();
                CargarDataGrid();
            }
            else
            {
                TreeNode nodoSeleccionado = treeViewUsuariosPermisos.SelectedNode;

                if (nodoSeleccionado != null)
                {
                    if (nodoSeleccionado.Tag is BERoles)
                    {
                        if (permisoDisponibleSeleccionado != null)
                        {
                            bllRoles.AgregarHijo(rolAsociadoSeleccionado, permisoDisponibleSeleccionado);
                            MessageBox.Show($"Se agregó el permiso '{permisoDisponibleSeleccionado.Nombre}' al rol '{rolAsociadoSeleccionado.Nombre}' exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un permiso disponible");
                        }
                    }
                    else if (nodoSeleccionado.Tag is BEUsuario)
                    {
                        FrmUsuarioAgregarPermisoIndependiente frmUsuarioAgregarPermisoIndependiente = new FrmUsuarioAgregarPermisoIndependiente(usuarioSeleccionado);
                        frmUsuarioAgregarPermisoIndependiente.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un rol");
                    }

                }
                else
                {
                    FrmUsuarioAgregarPermisoIndependiente frmUsuarioAgregarPermisoIndependiente = new FrmUsuarioAgregarPermisoIndependiente(usuarioSeleccionado);
                    frmUsuarioAgregarPermisoIndependiente.ShowDialog();
                }
                CargarDataGrid();

            }
        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {

            if (permisoAsociadoSeleccionado != null)
            {
                TreeNode nodoPadre = treeViewUsuariosPermisos.SelectedNode.Parent;
                BERoles rol = nodoPadre.Tag as BERoles;

                try
                {
                    if (rol != null)
                    {

                        bllRoles.EliminarHijo(rol, permisoAsociadoSeleccionado, 2);
                        MessageBox.Show($"Se eliminó el permiso '{permisoAsociadoSeleccionado.Nombre}' del rol '{rol.Nombre}' exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        bllUsuario.EliminarPermisoUsuario(usuarioSeleccionado, permisoAsociadoSeleccionado);
                        MessageBox.Show($"Se eliminó el permiso '{permisoAsociadoSeleccionado.Nombre}' del usuario '{usuarioSeleccionado.ToString()}' exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Hubo un error al eliminar el permiso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CargarDataGrid();

        }



        private void uC_dgvUsuarios_Load(object sender, EventArgs e)
        {

            BEUsuario usuarioSeleccionado = (BEUsuario)uC_dgvUsuarios.dataGridView1.CurrentRow.DataBoundItem;
            rolDisponibleSeleccionado = null;
            CargarListaPermisosDisponibles();
            CargarListaRolesDisponibles();
        }



        private void buttonRolAgregar_Click(object sender, EventArgs e)
        {
            TreeNode nodoUsuario = treeViewUsuariosPermisos.Nodes.Count > 0 ? treeViewUsuariosPermisos.Nodes[0] : null;

            if (rolDisponibleSeleccionado != null)
            {
                if (nodoUsuario != null && nodoUsuario.Nodes.Count == 0)
                {
                    bllUsuario.GuardarRolUsuario(usuarioSeleccionado, rolDisponibleSeleccionado);
                    MessageBox.Show("Se agregó el rol al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rolDisponibleSeleccionado = null;
                }
                else
                {
                    TreeNode nodoSeleccionado = treeViewUsuariosPermisos.SelectedNode;

                    if (nodoSeleccionado != null)
                    {
                        if (nodoSeleccionado.Tag is BEPermiso)
                        {
                            MessageBox.Show("No se ha seleccionado un rol del usuario");
                            return;
                        }

                        BERoles rolPadre = null;

                        if (nodoSeleccionado.Tag is BERoles rolSeleccionado)
                        {
                            rolPadre = rolSeleccionado;
                        }
                        else if (nodoSeleccionado.Parent != null && nodoSeleccionado.Parent.Tag is BERoles rolPadreSeleccionado)
                        {
                            rolPadre = rolPadreSeleccionado;
                        }

                        if (rolPadre != null)
                        {
                            FrmRolAgregarRol frmRolAgregarRol = new FrmRolAgregarRol(rolPadre, usuarioSeleccionado);
                            frmRolAgregarRol.ShowDialog();
                        }
                        else
                        {
                            bllUsuario.GuardarRolUsuario(usuarioSeleccionado, rolDisponibleSeleccionado);
                            MessageBox.Show("Se agregó el rol al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rolDisponibleSeleccionado = null;
                        }
                    }
                    else
                    {
                        bllUsuario.GuardarRolUsuario(usuarioSeleccionado, rolDisponibleSeleccionado);
                        MessageBox.Show("Se agregó el rol al usuario exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rolDisponibleSeleccionado = null;
                    }
                }
            }
            else
            {
                TreeNode nodoSeleccionado = treeViewUsuariosPermisos.SelectedNode;
                if (nodoSeleccionado != null)
                {
                    if (nodoSeleccionado.Tag is BEPermiso)
                    {
                        MessageBox.Show("No se ha seleccionado un rol del usuario");
                        return;
                    }

                    BERoles rolPadre = null;

                    if (nodoSeleccionado.Tag is BERoles rolSeleccionado)
                    {
                        rolPadre = rolSeleccionado;
                    }
                    else if (nodoSeleccionado.Parent != null && nodoSeleccionado.Parent.Tag is BERoles rolPadreSeleccionado)
                    {
                        rolPadre = rolPadreSeleccionado;
                    }

                    if (rolPadre != null)
                    {
                        FrmRolAgregarRol frmRolAgregarRol = new FrmRolAgregarRol(rolPadre, usuarioSeleccionado);
                        frmRolAgregarRol.ShowDialog();
                    }
                }
            }
            CargarDataGrid();

        }

        private void buttonRolQuitar_Click(object sender, EventArgs e)
        {

            TreeNode nodoSeleccionado = treeViewUsuariosPermisos.SelectedNode;

            if (nodoSeleccionado != null && nodoSeleccionado.Tag is BEComponente componente)
            {
                if (componente is BEPermiso)
                {
                    MessageBox.Show("No es un rol");
                    return;
                }

                if (componente is BERoles rolSeleccionado)
                {
                    bool esRolDirecto = usuarioSeleccionado.listaComponentes.OfType<BERoles>().Any(r => r.Codigo == rolSeleccionado.Codigo);

                    if (esRolDirecto)
                    {
                        try
                        {
                            usuarioSeleccionado.listaComponentes.Remove(rolSeleccionado);
                            bllUsuario.EliminarRolUsuario(usuarioSeleccionado, rolSeleccionado);
                            MessageBox.Show("Rol eliminado correctamente del usuario.");

                            CargarDataGrid();
                            CargarListaRolesDisponibles();
                            RefrescarTreeView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el rol: {ex.Message}");
                        }
                    }
                    else
                    {
                        BERoles rolPadre = BuscarRolEnComponentes(usuarioSeleccionado.listaComponentes, nodoSeleccionado.Parent.Text);

                        if (rolPadre != null)
                        {
                            try
                            {
                                bllRoles.EliminarHijo(rolPadre, rolSeleccionado, 1);
                                MessageBox.Show("Rol eliminado correctamente del rol padre.");

                                CargarDataGrid();
                                CargarListaRolesDisponibles();
                                listBoxPermisosDisponibles.Items.Clear();
                                listBoxRolesDisponibles.Items.Clear();
                                RefrescarTreeView();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al eliminar el rol: {ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el rol seleccionado o el rol padre.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol para eliminar.");
            }

            CargarDataGrid();

        }


        private void listBoxPermisosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPermisosDisponibles.SelectedItem != null)
            {
                ListItem selectedItem = (ListItem)listBoxPermisosDisponibles.SelectedItem;
                permisoDisponibleSeleccionado = new BEPermiso(
                    selectedItem.Nombre,
                    selectedItem.Codigo)
                ;
            }
        }





        private void listBoxRolesDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRolesDisponibles.SelectedItem != null && listBoxRolesDisponibles.SelectedItem is ListItem selectedItem)
            {
                rolDisponibleSeleccionado = new BERoles(selectedItem.Nombre, selectedItem.Codigo);
            }
            else
            {
                rolDisponibleSeleccionado = null;
            }
        }

        private BERoles BuscarRolEnComponentes(IEnumerable<BEComponente> componentes, string nombreRol)
        {
            foreach (var componente in componentes)
            {
                if (componente is BERoles rol)
                {
                    if (rol.Nombre == nombreRol)
                    {
                        return rol;
                    }
                    var rolHijoEncontrado = BuscarRolEnComponentes(rol.Permisos.OfType<BEComponente>(), nombreRol);
                    if (rolHijoEncontrado != null)
                    {
                        return rolHijoEncontrado;
                    }
                }
            }
            return null;
        }

        private void buttonBorrarUsuario_Click(object sender, EventArgs e)
        {

            if (usuarioSeleccionado != null)
            {
                DialogResult Result = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?",
                                                             "Confirmar eliminación",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    bool resultado = bllUsuario.BorrarUsuario(usuarioSeleccionado);

                    if (resultado)
                    {
                        MessageBox.Show("Usuario borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    CargarDataGrid();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void buttonRolCrear_Click(object sender, EventArgs e)
        {
            FrmRolAgregar frmRolAgregar = new FrmRolAgregar(listaRoles);
            DialogResult result = frmRolAgregar.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Rol agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDataGrid();
                CargarListaRolesDisponibles();
                listBoxPermisosDisponibles.Items.Clear();
                listBoxRolesDisponibles.Items.Clear();
                treeViewUsuariosPermisos.Nodes.Clear();
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operación cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CargarDataGrid();
        }

        private void buttonRolEliminar_Click(object sender, EventArgs e)
        {
            if (rolDisponibleSeleccionado != null)
            {
                DialogResult Result = MessageBox.Show("¿Está seguro de que desea eliminar este rol?",
                                                             "Confirmar eliminación",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    bool resultado = bllRoles.EliminarRol(rolDisponibleSeleccionado);
                    if (resultado)
                    {
                        MessageBox.Show("Rol borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error al borrar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            CargarDataGrid();

        }

        private void treeViewUsuariosPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BEComponente componente;
            var selectedNode = e.Node;
            if (selectedNode != null && selectedNode.Tag is BEComponente component)
            {
                componente = component;

                if (componente is BERoles)
                {
                    rolAsociadoSeleccionado = (BERoles)componente;
                    permisoAsociadoSeleccionado = null;

                }

                else if (componente is BEPermiso)
                {
                    permisoAsociadoSeleccionado = (BEPermiso)componente;
                    rolAsociadoSeleccionado = null;
                }
            }
        }

        private void buttonActualizarSistema_Click(object sender, EventArgs e)
        {
            try
            {
                BEUsuario usuarioSeleccionado = (BEUsuario)uC_dgvUsuarios.dataGridView1.CurrentRow.DataBoundItem;
                parentForm.DeshabilitarVentanas();
                parentForm.CargarToolStripSegunPermisos(usuarioSeleccionado);
                MessageBox.Show("Se actualizó correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }
    }
}
