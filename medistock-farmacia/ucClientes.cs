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
    public partial class ucClientes : UserControl
    {
        public DataTable DataSource
        {
            get => dgvInventario.DataSource as DataTable;
            set => dgvInventario.DataSource = value;
        }
        public ucClientes()
        {
            InitializeComponent();
        }
    }
}
