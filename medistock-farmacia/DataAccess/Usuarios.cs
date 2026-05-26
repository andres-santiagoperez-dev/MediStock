using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia.DataAccess
{
    internal class Usuarios
    {
        public static bool agregarUsuario(string nombreUsuario,string contrasena,string nombreCompleto,int idRol)
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();
                string sql = "insert into usuarios values(@nombreUsuario,@contrasena,@nombreCompleto,@idRol,1,GETDATE());";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                cmd.Parameters.AddWithValue("@idRol", idRol);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Usuario agregado con exito");
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
