using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medistock_farmacia.DataAccess
{
    internal class Categorias
    {
        public static SqlConnection cnn = Conexion.obtenerConexion();
        public static DataTable obtenerCategorias()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select top 100 * from categorias;";
                SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                data.Fill(dt);
                return dt;
            }
            catch ( Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return dt;
            }
            
        }
    }
}
