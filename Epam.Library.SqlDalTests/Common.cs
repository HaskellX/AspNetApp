using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

namespace Epam.Library.SqlDalTests
{
    internal static class Common
    {
        private static string conString;
        private static DbProviderFactory factory;

        static Common()
        {
            var settings = ConfigurationManager.ConnectionStrings["default"];
            Common.conString = settings.ConnectionString;
            Common.factory = DbProviderFactories.GetFactory(settings.ProviderName);
        }

        public static IDbConnection CreateConnection()
        {
            var con = Common.factory.CreateConnection();
            con.ConnectionString = Common.conString;

            return con;
        }

        internal static void Cleanup(string cleanupScript)
        {
                using (var connection = Common.CreateConnection())
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = File.ReadAllText(cleanupScript, Encoding.Unicode);
                    cmd.ExecuteNonQuery();
                }
        }

        internal static void Initialazation(string initialazerScript)
        {
                using (var connection = Common.CreateConnection())
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = File.ReadAllText(initialazerScript, Encoding.Unicode);
                    cmd.ExecuteNonQuery();
                }
        } 
    }
}
