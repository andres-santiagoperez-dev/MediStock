using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia.Helpers
{
    internal class Diseno
    {
        public static void ocultarLabels(Label lblInventario,Label lblCategoria, Label lblProveedores, Label lblClientes)
        {
            lblCategoria.Visible=false;
            lblInventario.Visible=false;
            lblClientes.Visible = false;
            lblProveedores.Visible = false;
        }
    }
}
