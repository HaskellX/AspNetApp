using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entities;

namespace Epam.Library.SqlDal
{
        internal static class Common
        {
            private static DbProviderFactory factory;
            private static string connectionString;

            static Common()
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["default"];

                Common.connectionString = settings.ConnectionString;

                Common.factory = DbProviderFactories.GetFactory(settings.ProviderName);
            }

            internal static DbConnection CreateConnection()
            {
                var con = Common.factory.CreateConnection();
                con.ConnectionString = Common.connectionString;
                return con;
            }

            internal static DbParameter CreateParameter<T>(string name, DbType databaseType, T value = default(T))
            {
                var result = Common.factory.CreateParameter();
                result.ParameterName = name;
                result.DbType = databaseType;

                if (value == null)
                {
                    result.Value = DBNull.Value;
                }
                else
                {
                    result.Value = value;
                }

                return result;
            }

            internal static DbParameter CreateOutputParameter(string name, DbType databaseType, ParameterDirection direction = ParameterDirection.Output)
            {
                var result = Common.factory.CreateParameter();
                result.ParameterName = name;
                result.DbType = databaseType;
                result.Direction = direction;

                return result;
            }
            
            internal static IEnumerable<Author> GetAuthorsFromXML(XElement xmlAuthor)
            {
                return xmlAuthor.Elements("Author").Select(item => new Author()
                {
                    Id = int.Parse(item.Attribute("Id").Value),
                    FirstName = item.Attribute("Firstname").Value,
                    LastName = item.Attribute("Lastname").Value,
                });
        }
        }
}
