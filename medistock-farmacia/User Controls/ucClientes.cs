using medistock_farmacia.DataAccess;
using medistock_farmacia.Forms;
using medistock_farmacia.Forms.Dashboard;
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
    public partial class ucClientes : UserControl
    {
        public void cargarClientes()
        {
            dgvClientes.DataSource = Clientes.obtenerClientes();
        }
        public DataTable DataSource
        {
            get => dgvClientes.DataSource as DataTable;
            set => dgvClientes.DataSource = value;
        }
        public ucClientes()
        {
            InitializeComponent();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAgregarCliente frm = new frmAgregarCliente();

            frm.FormClosed += (s, eArgs) =>
            {
                cargarClientes();
            };
            frm.ShowDialog();

        }

        private void ucClientes_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Clientes.obtenerClientes();
            dgvClientes.DataSource = dt;
        }
    }
}
