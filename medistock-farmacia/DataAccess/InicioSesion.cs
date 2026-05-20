using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medistock_farmacia.DataAccess
{
    internal class InicioSesion
    {

        public static object verificarUsuario(string usuario, string contrasena)
        {
            SqlConnection cnn = Conexion.obtenerConexion();
            object resultado;
            string sql = "select id from usuarios where nombreUsuario =@usuario and contrasena =@contrasena;";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contrasena", contrasena);
            cnn.Open();
            resultado = cmd.ExecuteScalar();
            cnn.Close();
            return resultado;
        }
    }
}
