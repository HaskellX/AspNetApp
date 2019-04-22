using BL_Contracts;
using DalContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Epam.Library.SqlDal
{
    public class AuthorDAO : IAuthorDAO
    {
        private readonly ILogger logger;

        public AuthorDAO(ILogger logger)
        {
            this.logger = logger;
        }

        public int Add(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddAuthor";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter resultId = Common.CreateOutputParameter("@id", DbType.Int32);
                IDbDataParameter firstName = Common.CreateParameter("@firstName", DbType.String, author.FirstName);
                IDbDataParameter lastName = Common.CreateParameter("@lastName", DbType.String, author.LastName);

                cmd.Parameters.AddRange(new[] { resultId, firstName, lastName });

                cmd.ExecuteNonQuery();

                return (int)resultId.Value;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            List<Author> list = new List<Author>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllAuthors";
                cmd.CommandType = CommandType.StoredProcedure;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(
                        new Author
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["Firstname"],
                            LastName = (string)reader["Lastname"]
                        });
                }
            }
            return list.ToArray();
        }

        public IEnumerable<Author> GetAll(string startsWith)
        {
            List<Author> list = new List<Author>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetAuthorsByName";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter startStringDb = Common.CreateParameter("@authorName", DbType.String, startsWith);

                cmd.Parameters.Add(startStringDb);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(
                        new Author
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["Firstname"],
                            LastName = (string)reader["Lastname"]
                        });
                }
            }
            return list.ToArray();
        }

        public Author GetAuthorById(int id)
        {
            Author author = new Author();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetAuthorById";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter authorId = Common.CreateParameter("@id", DbType.Int32, id);

                cmd.Parameters.AddRange(new[] { authorId });

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    author = new Author()
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["Firstname"],
                        LastName = (string)reader["Lastname"]
                    };
                    return author;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateAuthor";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter resultId = Common.CreateParameter("@id", DbType.Int32, author.Id);
                IDbDataParameter firstName = Common.CreateParameter("@firstName", DbType.String, author.FirstName);
                IDbDataParameter lastName = Common.CreateParameter("@lastName", DbType.String, author.LastName);

                cmd.Parameters.AddRange(new[] { resultId, firstName, lastName });

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}