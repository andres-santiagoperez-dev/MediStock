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
            if(txtIdRol.Text != "" && txtNombreCompleto.Text != "" && txtNombreUsuario.Text != "" && txtContrasena.Text != "")
            {
                Usuarios.agregarUsuario(txtNombreUsuario.Text,txtContrasena.Text,txtNombreCompleto.Text,Convert.ToInt32(txtIdRol.Text));
                frmLogin form = new frmLogin();
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar", "CUIDADO");
            }
        }

    }
}
