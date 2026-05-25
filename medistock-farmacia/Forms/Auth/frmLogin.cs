using medistock_farmacia.DataAccess;
using medistock_farmacia.Forms.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object resultado;
            resultado =InicioSesion.verificarUsuario(txtUsuario.Text, txtContrasena.Text);
            if (resultado == null)
            {
                MessageBox.Show("Usuario o Contraseña Incorrecto", "Verifica Informacion");
            }
            else
            {
                frmPrincipal principal = new frmPrincipal();
                this.Hide();
                principal.Show();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmAgregarUsuario form = new frmAgregarUsuario();
            form.Show();
        }
    }
}
