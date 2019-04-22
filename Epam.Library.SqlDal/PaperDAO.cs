using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalContracts;
using Entities;

namespace Epam.Library.SqlDal
{
    public class PaperDAO : IPaperDAO
    {

        public int Add(Paper paper)
        {
            if (paper == null)
            {
                throw new ArgumentNullException(nameof(paper));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddPaper";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter id = Common.CreateOutputParameter("id", DbType.Int32);
                IDbDataParameter title = Common.CreateParameter("title", DbType.String, paper.Name);
                IDbDataParameter issn = Common.CreateParameter("issn", DbType.String, paper.Issn);

                cmd.Parameters.AddRange(new[] { id, title, issn });
                cmd.ExecuteNonQuery();

                return (int)id.Value;
            }
        }

        public Paper GetById(int id)
        {
            Paper paper = null;
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = "GetPaperById";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter inputId = Common.CreateParameter("id", DbType.Int32, id);
                cmd.Parameters.Add(inputId);
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    paper = new Paper()
                    {
                        Id = (int)reader["id"],
                        Issn = (string)reader["ISSN"],
                        Name = (string)reader["title"]
                    };
                }
            }

            return paper;
        }

        public IEnumerable<Paper> GetPapersStartsWith(string startsWith)
        {
            var list = new List<Paper>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = "GetPapersByName";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter nameDb = Common.CreateParameter("@name", DbType.String, startsWith);
                cmd.Parameters.Add(nameDb);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Paper()
                    {
                        Id = (int)reader["id"],
                        Issn = reader["ISSN"] as string,
                        Name = (string)reader["title"]
                    });
                }
            }

            return list.ToArray();
        }

        public bool Update(Paper paper)
        {
            if (paper == null)
            {
                throw new ArgumentNullException(nameof(paper));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdatePaper";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter id = Common.CreateParameter("@id", DbType.Int32, paper.Id);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, paper.Name);
                IDbDataParameter issn = Common.CreateParameter("@issn", DbType.String, paper.Issn);

                cmd.Parameters.AddRange(new[] { id, title, issn });
                int result = cmd.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}
