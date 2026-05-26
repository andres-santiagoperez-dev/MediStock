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

        private void dgvClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["id"].Value);
            string tipoDocumento = Convert.ToString(dgvClientes.CurrentRow.Cells["tipoDocumento"].Value);
            string numeroDocumento = Convert.ToString(dgvClientes.CurrentRow.Cells["numeroDocumento"].Value);
            string nombreCompleto = Convert.ToString(dgvClientes.CurrentRow.Cells["nombreCompleto"].Value);
            string telefono = Convert.ToString(dgvClientes.CurrentRow.Cells["telefono"].Value);
            string email = Convert.ToString(dgvClientes.CurrentRow.Cells["email"].Value);
            int estado = Convert.ToInt32(dgvClientes.CurrentRow.Cells["estado"].Value);
            if(tipoDocumento =="TI" || tipoDocumento=="CC")
            {
                DialogResult resultado = MessageBox.Show("Desea editar la casilla seleccionada", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Clientes.editarCliente(id, tipoDocumento, numeroDocumento, nombreCompleto, telefono, email, estado);
                }
            }
            else
            {
                dgvClientes.CancelEdit();
                MessageBox.Show("VERIFICA LOS DATOS", "ERROR");
            }
            dgvClientes.ReadOnly = true;
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            dgvClientes.ReadOnly = false;
            dgvClientes.Columns["id"].ReadOnly = true;
        }
    }
}
