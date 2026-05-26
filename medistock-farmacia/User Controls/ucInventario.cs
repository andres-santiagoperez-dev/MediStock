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
    public partial class ucInventario : UserControl
    {
        public void cargarProductos()
        {
            dgvInventario.DataSource = Inventario.obtenerInventario();
        }
        public DataTable DataSource
        {
            get => dgvInventario.DataSource as DataTable;
            set => dgvInventario.DataSource = value;
        }
        public ucInventario()
        {
            InitializeComponent();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmAgregarProducto frm = new frmAgregarProducto();
            frm.FormClosed += (s, eArgs) =>
            {
                cargarProductos();
            };
            frm.ShowDialog();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            dgvInventario.ReadOnly = false;
            dgvInventario.Columns["id"].ReadOnly = true;
            dgvInventario.Columns["codigo"].ReadOnly = true;
        }

        private void dgvInventario_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvInventario.CurrentRow.Cells["id"].Value);
            string codigo = Convert.ToString(dgvInventario.CurrentRow.Cells["codigo"].Value);
            string nombre = Convert.ToString(dgvInventario.CurrentRow.Cells["nombre"].Value);
            string descripcion = Convert.ToString(dgvInventario.CurrentRow.Cells["descripcion"].Value);
            int idCategoria = Convert.ToInt32(dgvInventario.CurrentRow.Cells["idCategoria"].Value);
            int idProveedor = Convert.ToInt32(dgvInventario.CurrentRow.Cells["idProveedor"].Value);
            decimal precioCompra = Convert.ToDecimal(dgvInventario.CurrentRow.Cells["precioCompra"].Value);
            decimal precioVenta = Convert.ToDecimal(dgvInventario.CurrentRow.Cells["precioVenta"].Value);
            int stockActual = Convert.ToInt32(dgvInventario.CurrentRow.Cells["stockActual"].Value);
            int stockMinimo = Convert.ToInt32(dgvInventario.CurrentRow.Cells["stockMinimo"].Value);
            DateTime fechaVencimiento = Convert.ToDateTime(dgvInventario.CurrentRow.Cells["fechaVencimiento"].Value);
            int estado = Convert.ToInt32(dgvInventario.CurrentRow.Cells["estado"].Value);
            Inventario.editarProducto(id,codigo,nombre,descripcion,idCategoria,idProveedor,precioCompra,precioVenta,stockActual,stockMinimo,fechaVencimiento,estado);
            dgvInventario.ReadOnly = true;
        }
    }
}
