using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia.Forms.Dashboard
{
    public partial class frmAgregarUsuario : Form
    {
        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text != "" && txtNombreCompleto.Text != "" && txtNumeroDocumento.Text != "" && txtTelefono.Text != "")
            {
                this.Hide();
                frmLogin form = new frmLogin();
                form.Show();
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar", "CUIDADO");
            }
        }
    }
}
