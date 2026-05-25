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
    public partial class frmAgregarCategoria : Form
    {
        public frmAgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                Categorias.agregarCategoria(txtNombre.Text, txtDescripcion.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Faltan datos", "CUIDADO");
            }
        }
    }
}
