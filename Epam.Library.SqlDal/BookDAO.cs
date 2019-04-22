using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DalContracts;
using Entities;

namespace Epam.Library.SqlDal
{
    public class BookDAO : IBookDAO
    {
        public int AddItem(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddBook";
                cmd.CommandType = CommandType.StoredProcedure;

                StringBuilder stringAuthors = new StringBuilder();
                foreach (Author x in book.Authors)
                {
                    stringAuthors.Append(x.Id).Append(',');
                }

                if (stringAuthors.Length > 1)
                {
                    stringAuthors.Remove(stringAuthors.Length - 1, 1);
                }

                IDbDataParameter authors = Common.CreateParameter("@authors", DbType.String, stringAuthors.ToString());
                IDbDataParameter yearOfPublishing = Common.CreateParameter("@yearOfPublishing", DbType.Int32, book.YearOfPublishing);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, book.Name);
                IDbDataParameter cityOfPublishing = Common.CreateParameter("@cityOfPublishing", DbType.String, book.CityOfPublishing);
                IDbDataParameter publisher_ID = Common.CreateParameter("@publisher_ID", DbType.Int32, book.Publisher.Id);
                IDbDataParameter numberOfPages = Common.CreateParameter("@numberOfPages", DbType.Int32, book.NumberOfPages);
                IDbDataParameter note = Common.CreateParameter("@note", DbType.String, book.Note);
                IDbDataParameter isbn = Common.CreateParameter("@ISBN", DbType.String, book.ISBN);

                IDbDataParameter resultId = Common.CreateOutputParameter("@bookId", DbType.Int32);

                cmd.Parameters.AddRange(new[] { authors, yearOfPublishing, title, cityOfPublishing, publisher_ID, numberOfPages, note, isbn, resultId });

                cmd.ExecuteNonQuery();
                return (int)resultId.Value;
            }
        }

        public bool Exists(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book is null", nameof(book));
            }

            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "BookExists";
                cmd.CommandType = CommandType.StoredProcedure;

                StringBuilder stringAuthors = new StringBuilder();
                foreach (Author x in book.Authors)
                {
                    stringAuthors.Append(x.Id);
                }

                string auth = stringAuthors.ToString();
                auth.TrimEnd(new char[] { ',' });

                IDbDataParameter resultId = Common.CreateOutputParameter("@result", DbType.Int32);
                IDbDataParameter isbn = Common.CreateParameter("@ISBN", DbType.String, book.ISBN);
                IDbDataParameter authors = Common.CreateParameter("@authors", DbType.String, auth);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, book.Name);
                IDbDataParameter yearOfPublishing = Common.CreateParameter("@yearOfPublishing", DbType.Int32, book.YearOfPublishing);

                cmd.Parameters.AddRange(new[] { resultId, isbn, authors, title, yearOfPublishing });

                connection.Open();
                cmd.ExecuteNonQuery();
                return (int)resultId.Value > 0;
            }
        }

        public IEnumerable<Book> GetAllItems()
        {
            List<Book> list = new List<Book>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllBooks";
                cmd.CommandType = CommandType.StoredProcedure;

                var reader = cmd.ExecuteReader();
                Book book;
                while (reader.Read())
                {
                    book = new Book()
                    {
                        CityOfPublishing = (string)reader["city_of_publishing"],
                        Id = (int)reader["library_item_ID"],
                        ISBN = reader["ISBN"] as string,
                        Name = (string)reader["title"],
                        NumberOfPages = (int)reader["number_of_pages"],
                        Note = (string)reader["note"],
                        Publisher = new Publisher()
                        {
                            Id = (int)reader["publisher_Id"],
                            PublisherName = (string)reader["publisherName"]
                        },
                        YearOfPublishing = (int)reader["YearOfPublication"]
                    };

                    XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                    book.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));

                    list.Add(book);
                }
            }

            return list;
        }

        public Book GetItemById(int id)
        {
            using (var connection = Common.CreateConnection())
            {
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "GetBookById";
                    cmd.CommandType = CommandType.StoredProcedure;
                    IDbDataParameter databaseId = Common.CreateParameter("@id", DbType.Int32, id);

                    cmd.Parameters.Add(databaseId);
                    Book book = null;
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        book = new Book()
                        {
                            CityOfPublishing = (string)reader["city_of_publishing"],
                            Id = (int)reader["library_item_ID"],
                            ISBN = (string)reader["ISBN"],
                            Name = (string)reader["title"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            Note = (string)reader["note"],
                            Publisher = new Publisher()
                            {
                                Id = (int)reader["publisher_Id"],
                                PublisherName = (string)reader["publisherName"]
                            },
                            YearOfPublishing = (int)reader["YearOfPublication"]
                        };

                        XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                        book.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));
                }

                return book;
            }
        }

        public bool RemoveItem(int id)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                int result;
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DeleteLibraryItem";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter firstName = Common.CreateParameter("@id", DbType.String, id);

                cmd.Parameters.Add(firstName);

                result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateBook";
                cmd.CommandType = CommandType.StoredProcedure;

                StringBuilder stringAuthors = new StringBuilder();
                foreach (Author x in book.Authors)
                {
                    stringAuthors.Append(x.Id).Append(',');
                }

                if (stringAuthors.Length > 1)
                {
                    stringAuthors.Remove(stringAuthors.Length - 1, 1);
                }

                IDbDataParameter authors = Common.CreateParameter("@authors", DbType.String, stringAuthors.ToString());
                IDbDataParameter yearOfPublishing = Common.CreateParameter("@yearOfPublishing", DbType.Int32, book.YearOfPublishing);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, book.Name);
                IDbDataParameter cityOfPublishing = Common.CreateParameter("@cityOfPublishing", DbType.String, book.CityOfPublishing);
                IDbDataParameter publisher_ID = Common.CreateParameter("@publisher_ID", DbType.Int32, book.Publisher.Id);
                IDbDataParameter numberOfPages = Common.CreateParameter("@numberOfPages", DbType.Int32, book.NumberOfPages);
                IDbDataParameter note = Common.CreateParameter("@note", DbType.String, book.Note);
                IDbDataParameter isbn = Common.CreateParameter("@ISBN", DbType.String, book.ISBN);
                IDbDataParameter resultId = Common.CreateParameter("@bookId", DbType.Int32, book.Id);

                cmd.Parameters.AddRange(new[] { authors, yearOfPublishing, title, cityOfPublishing, publisher_ID, numberOfPages, note, isbn, resultId });

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}