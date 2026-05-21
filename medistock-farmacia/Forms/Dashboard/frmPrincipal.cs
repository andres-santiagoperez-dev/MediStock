using medistock_farmacia.DataAccess;
using medistock_farmacia.Helpers;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            pnlUserControls.Visible = true;
            Diseno.ocultarLabels(lblInventario, lblCategoria, lblProveedores, lblClientes);
            lblInventario.Visible = true;
            pnlUserControls.Controls.Clear();
            ucInventario inventario = new ucInventario();
            inventario.Dock = DockStyle.Fill;
            pnlUserControls.Controls.Add(inventario);

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            pnlUserControls.Visible = true;
            Diseno.ocultarLabels(lblInventario, lblCategoria, lblProveedores, lblClientes);
            lblCategoria.Visible = true;
            pnlUserControls.Controls.Clear();
            ucCategorias categorias = new ucCategorias();
            categorias.Dock = DockStyle.Fill;
            pnlUserControls.Controls.Add(categorias);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            pnlUserControls.Visible = true;
            Diseno.ocultarLabels(lblInventario, lblCategoria, lblProveedores, lblClientes);
            lblProveedores.Visible = true;
            pnlUserControls.Controls.Clear();
            ucProveedores proveedores = new ucProveedores();
            proveedores.Dock = DockStyle.Fill;
            pnlUserControls.Controls.Add(proveedores);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            pnlUserControls.Visible = true;
            Diseno.ocultarLabels(lblInventario, lblCategoria,lblProveedores,lblClientes);
            lblClientes.Visible = true;
            pnlUserControls.Controls.Clear();
            ucClientes clientes = new ucClientes();
            clientes.Dock = DockStyle.Fill;
            pnlUserControls.Controls.Add(clientes);
        }
    }
}
