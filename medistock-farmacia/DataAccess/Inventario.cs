using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace medistock_farmacia.DataAccess
{
    internal class Inventario
    {
        public static SqlConnection cnn = Conexion.obtenerConexion();
        public static DataTable obtenerInventario()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select top 100 * from productos";
                SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                data.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas tecnicos en el inventario" + e.Message, "ERROR");
                return dt;
            }
        }
        public static bool agregarProducto(string codigo,string nombre,string descipcion,int idCategoria,int idProveedor,decimal precioCompra,decimal precioVenta,int stockActual,int stockMinimo,DateTime fechaVencimiento)
        {
            try
            {
                string sql = "insert into productos values(@codigo,@nombre,@descripcion,@idCategoria,@idProveedor,@precioCompra,@precioVenta,@stockActual,@stockMinimo,@fechaVencimiento,1);";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descipcion);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                cmd.Parameters.AddWithValue("@precioCompra", precioCompra);
                cmd.Parameters.AddWithValue("@precioVenta", precioVenta);
                cmd.Parameters.AddWithValue("@stockActual", stockActual);
                cmd.Parameters.AddWithValue("@stockMinimo", stockMinimo);
                cmd.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Producto agregado con exito");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return false;
            }
        }
    }
}
