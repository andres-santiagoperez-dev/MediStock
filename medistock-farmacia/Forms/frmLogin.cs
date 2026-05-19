using medistock_farmacia.DataAccess;
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
            resultado =Usuario.verificarUsuario(txtUsuario.Text, txtContrasena.Text);
            if (resultado == null)
            {
                MessageBox.Show("Usuario o Contraseña Incorrecto", "Verifica Informacion");
            }
            else
            {
                MessageBox.Show("Usuario existe");
            }
        }
    }
}
