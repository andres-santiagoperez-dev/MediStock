using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medistock_farmacia.DataAccess
{
    internal class Conexion
    {
        public static string cadenaConexion = "workstation id=MediStockDB.mssql.somee.com;packet size=4096;user id=AndresPerez8103_SQLLogin_1;pwd=c5lsav1ckl;data source=MediStockDB.mssql.somee.com;persist security info=False;initial catalog=MediStockDB;TrustServerCertificate=True";
        public static SqlConnection obtenerConexion ()
        {
            SqlConnection cnn = new SqlConnection(cadenaConexion);
            return cnn;
        }
    }
}
