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

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            dgvCategorias.ReadOnly = false;
            dgvCategorias.Columns["id"].ReadOnly = true;
        }

        private void dgvCategorias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["id"].Value);
            string nombre = Convert.ToString(dgvCategorias.CurrentRow.Cells["nombre"].Value);
            int estado = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["estado"].Value);
            string descripcion = Convert.ToString(dgvCategorias.CurrentRow.Cells["descripcion"].Value);
            DialogResult resultado = MessageBox.Show("Desea Editar la Casilla Seleccionada", "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Categorias.editarCategoria(id, nombre, descripcion, estado);
                dgvCategorias.ReadOnly = true;
            }
        }
    }
}
