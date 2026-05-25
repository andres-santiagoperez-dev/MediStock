using medistock_farmacia.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia.Forms
{
    public partial class frmAgregarProducto : Form
    {
        public frmAgregarProducto()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            DateTime date = dtpFechaVencimiento.Value.Date;
            Inventario.agregarProducto(txtCodigo.Text,txtNombre.Text,txtDescripcion.Text,Convert.ToInt32(txtIdCategoria.Text),Convert.ToInt32(txtIdProveedor.Text),Convert.ToDecimal(txtPrecioCompra.Text), Convert.ToDecimal(txtPrecioVenta.Text), Convert.ToInt32(txtStockActual.Text),Convert.ToInt32(txtStockMinimo.Text),date);
            this.Close();
        }
    }
}
