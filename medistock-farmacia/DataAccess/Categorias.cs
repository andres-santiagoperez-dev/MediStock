using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                string sql = "select top 100 * from categorias";
                SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                data.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas tecnicos con las categorias" + e.Message, "ERROR");
                return dt;
            }
        }
        public static bool agregarCategoria(string nombre,string descripcion)
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();
                string sql = "insert into categorias values(@nombre,@descripcion,1);";
                SqlCommand cmd = new SqlCommand(sql,cnn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion",descripcion);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Categoria agregada con exito");
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"ERROR");
                return false;
            }
        }
        public static bool editarCategoria(int id, string nombre, string descripcion, int estado)
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();
                string sql = "update categorias set nombre=@nombre,descripcion=@descripcion,estado=@estado where id=@id;";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Categoria editada con exito");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"ERROR");
                return false;
            }
        }
    }
}
