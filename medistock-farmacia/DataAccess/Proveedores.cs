using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace medistock_farmacia.DataAccess
{
    internal class Proveedores
    {
        public static SqlConnection cnn = Conexion.obtenerConexion();
        public static DataTable obtenerProveedores()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select top 100 * from proveedores";
                SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                data.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas tecnicos con los proveedores" + e.Message, "ERROR");
                return dt;
            }
        }
        public static bool agregarProveedor(string nombreEmpresa,string nombreContacto,string telefono,string email,string direccion)
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();
                string sql = "insert into proveedores values(@nombreEmpresa,@nombreContacto,@telefono,@email,@direccion,1);";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@nombreEmpresa", nombreEmpresa);
                cmd.Parameters.AddWithValue("@nombreContacto", nombreContacto);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@direccion", email);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Proveedor agregado con exito");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
        }
    }
}
