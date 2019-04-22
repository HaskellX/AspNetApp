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
    public class PublisherDAO : IPublisherDAO
    {
        public int AddPublisher(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddPublisher";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter id = Common.CreateOutputParameter("@id", DbType.Int32);
                IDbDataParameter publisherName = Common.CreateParameter("@PublisherName", DbType.String, publisher.PublisherName);

                cmd.Parameters.AddRange(new[] { id, publisherName });

                cmd.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public IEnumerable<Publisher> GetAll()
        {
            List<Publisher> list = new List<Publisher>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllPublishers";
                cmd.CommandType = CommandType.StoredProcedure;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Publisher()
                    {
                        Id = (int)reader["publisher_Id"],
                        PublisherName = (string)reader["publisherName"]
                    });
                }
            }
                return list.ToArray();
        }

        public IEnumerable<Publisher> GetAll(string startsWith)
        {
            List<Publisher> list = new List<Publisher>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetPublishersByName";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter stringStartDb = Common.CreateParameter("@publisherName", DbType.String, startsWith);
                cmd.Parameters.Add(stringStartDb);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Publisher()
                    {
                        Id = (int)reader["publisher_Id"],
                        PublisherName = (string)reader["publisherName"]
                    });
                }
            }
            return list.ToArray();
        }

        public Publisher GetPublisherById(int id)
        {
            Publisher publisher = new Publisher();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetPublisherById";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter authorId = Common.CreateParameter("@id", DbType.Int32, id);

                cmd.Parameters.Add(authorId);

                var reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    publisher = new Publisher()
                    {
                        Id = (int)reader["publisher_Id"],
                        PublisherName = (string)reader["publisherName"]
                    };
                    return publisher;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdatePublisher";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter id = Common.CreateParameter("@id", DbType.Int32, publisher.Id);
                IDbDataParameter publisherName = Common.CreateParameter("@PublisherName", DbType.String, publisher.PublisherName);

                cmd.Parameters.AddRange(new[] { id, publisherName });

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
