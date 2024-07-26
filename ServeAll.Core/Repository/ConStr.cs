using MySql.Data.MySqlClient;
using System.Configuration;


namespace ServeAll.Core.Repository
{
    public class ConStr
    {
        internal static MySqlConnection ConString()
        {
            var str = ConfigurationManager.ConnectionStrings["ServeAll.Properties.Settings.GConString"].ConnectionString;
            var conn = new MySqlConnection(str);
            return conn;
        }
    }
}