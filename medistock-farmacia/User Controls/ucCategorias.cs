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
    public partial class ucCategorias : UserControl
    {
        public void cargarCategorias()
        {
            dgvCategorias.DataSource = Categorias.obtenerCategorias();
        }
        public DataTable DataSource
        {
            get => dgvCategorias.DataSource as DataTable;
            set => dgvCategorias.DataSource = value;
        }
        public ucCategorias()
        {
            InitializeComponent();
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            frmAgregarCategoria frm = new frmAgregarCategoria();
            frm.FormClosed += (s, eArgs) =>
            {
                cargarCategorias();
            };
            frm.ShowDialog();
        }
    }
}
