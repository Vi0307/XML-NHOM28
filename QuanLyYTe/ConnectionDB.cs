using System.Data.SqlClient;

namespace QuanLyYTe
{
    public class ConnectionDB
    {
        private static string strConn =
            @"Data Source=VIETHOANG\MSSQLSERVER01;Initial Catalog=QuanLyYTe;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(strConn);
            return conn;
        }
    }
}
