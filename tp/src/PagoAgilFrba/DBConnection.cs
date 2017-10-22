using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace PagoAgilFrba
{
     public sealed class DBConnection
    {
        string server = ConfigurationManager.AppSettings["server"].ToString();
        string user = ConfigurationManager.AppSettings["user"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();

        private static readonly DBConnection instance = new DBConnection();

        private DBConnection() { }

        public static DBConnection getInstance()
        {
            return instance;
        }

        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012;DATABASE=GD2C2017;UID=" + user + ";PASSWORD=" + password + ";";
            return con;
        }
    }
}
