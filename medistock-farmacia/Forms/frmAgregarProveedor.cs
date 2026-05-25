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
    public partial class frmAgregarProveedor : Form
    {
        public frmAgregarProveedor()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(txtNombreEmpresa.Text!="" && txtNombreContacto.Text!="" && txtTelefono.Text!="" && txtEmail.Text!="" &&txtDireccion.Text!="" && cbxAcuerdo.Checked==true)
            {
                Proveedores.agregarProveedor(txtNombreEmpresa.Text, txtNombreContacto.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Faltan Campos por llenar", "CUIDADO");
            }

        }
    }
}
