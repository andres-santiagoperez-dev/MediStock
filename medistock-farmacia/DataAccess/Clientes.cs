using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia.DataAccess
{
    internal class Clientes
    {
        public static SqlConnection cnn = Conexion.obtenerConexion();
        public static DataTable obtenerClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select top 100 * from clientes";
                SqlDataAdapter data = new SqlDataAdapter(sql, cnn);
                data.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas tecnicos con los clientes" + e.Message, "ERROR");
                return dt;
            }
        }
        public static bool agregarCliente(string tipoDocumento,string numeroDocumento,string nombreCompleto,string telefono,string email)
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();
                string sql = "insert into clientes (tipoDocumento,numeroDocumento,nombreCompleto,telefono,email,estado) values(@tipoDocumento,@numeroDocumento,@nombreCompleto,@telefono,@email,1);";
                SqlCommand cmd = new SqlCommand(sql,cnn);
                cmd.Parameters.AddWithValue("@tipoDocumento",tipoDocumento);
                cmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
                cmd.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Cliente Agregado con exito","Felicidades");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR",e.Message);
                return false;
            }
        }
        public static bool editarCliente(int id, string tipoDocumento,string numeroDocumento,string nombreCompleto,string telefono,string email,int estado)
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();
                string sql = "update clientes set tipoDocumento=@tipoDocumento,numeroDocumento=@numeroDocumento,nombreCompleto=@nombreCompleto,telefono=@telefono,email=@email,estado=@estado where id=@id;";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
                cmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);
                cmd.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@estado", estado);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Cliente editado con exito", "Felicidades");
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
