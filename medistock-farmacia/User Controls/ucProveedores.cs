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
    }
}
