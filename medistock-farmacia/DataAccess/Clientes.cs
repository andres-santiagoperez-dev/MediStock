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
        public static bool agregarCliente()
        {
            try
            {
                SqlConnection cnn = Conexion.obtenerConexion();


                MessageBox.Show("Cliente Agregado con exito","Felicidades");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR",e.Message);
                return false;
            }
        }
    }
}
