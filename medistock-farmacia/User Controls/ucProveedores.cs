using medistock_farmacia.DataAccess;
using medistock_farmacia.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia
{
    public partial class ucProveedores : UserControl
    {
        public void cargarProveedores()
        {
            dgvProveedores.DataSource = Categorias.obtenerCategorias();
        }
        public DataTable DataSource
        {
            get => dgvProveedores.DataSource as DataTable;
            set => dgvProveedores.DataSource = value;
        }
        public ucProveedores()
        {
            InitializeComponent();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmAgregarProveedor frm = new frmAgregarProveedor();
            frm.FormClosed += (s, eArgs) =>
            {
                cargarProveedores();
            };
            frm.ShowDialog();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            dgvProveedores.ReadOnly = false;
            dgvProveedores.Columns["id"].ReadOnly = true;
        }

        private void dgvProveedores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["id"].Value);
            string nombreEmpresa = Convert.ToString(dgvProveedores.CurrentRow.Cells["nombreEmpresa"].Value);
            string nombreContacto = Convert.ToString(dgvProveedores.CurrentRow.Cells["nombreContacto"].Value);
            string telefono = Convert.ToString(dgvProveedores.CurrentRow.Cells["telefono"].Value);
            string email = Convert.ToString(dgvProveedores.CurrentRow.Cells["email"].Value);
            string direccion = Convert.ToString(dgvProveedores.CurrentRow.Cells["direccion"].Value);
            int estado = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["estado"].Value);
            Proveedores.editarProveedor(id, nombreEmpresa, nombreContacto, telefono, email, direccion, estado);
            dgvProveedores.ReadOnly = true;
        }
    }
}
