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
    }
}
