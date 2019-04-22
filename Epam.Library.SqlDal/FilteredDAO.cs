using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalContracts;
using Entities;
using Utility;

namespace Epam.Library.SqlDal
{
    public class FilteredDAO : IFilteredDAO
    {
        public IEnumerable<LibraryItem> GetBooksAndPatentsByAuthor(Author author)
        {
            List<LibraryItem> list = new List<LibraryItem>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetBooksAndPatentsByAuthor";
                cmd.CommandType = CommandType.StoredProcedure;

                IDbDataParameter authorId = Common.CreateParameter("authorId", DbType.Int32, author.Id);

                var reader = cmd.ExecuteReader();
                string type;
                while (reader.Read())
                {
                    type = (string)reader["Type"];
                    if (type == "patent")
                    {
                        Patent patent = new Patent()
                        {
                            Country = (string)reader["country"],
                            DateOfPublication = (DateTime)reader["date_of_publication"],
                            Id = (int)reader["library_item_ID"],
                            Name = (string)reader["title"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            RegNumber = (string)reader["reg_number"],
                            SubmissionDocuments = (DateTime)reader["date_of_submission"],
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                        patent.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));

                        list.Add(patent);
                    }
                    else if (type == "book")
                    {
                        Book book = new Book()
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
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }
            }

            return list;
        }

        public IEnumerable<LibraryItem> GetBooksByAuthor(Author author)
        {
            List<Book> list = new List<Book>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetBookByAuthor";
                cmd.CommandType = CommandType.StoredProcedure;
                IDbDataParameter authorId = Common.CreateParameter("@authorId", DbType.Int32, author.Id);

                cmd.Parameters.Add(authorId);

                var reader = cmd.ExecuteReader();
                Book book;
                while (reader.Read())
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

                    list.Add(book);
                }
            }

            return list.ToArray();
        }

        public IEnumerable<IGrouping<Publisher, Book>> GetBooksGroupedByPublisherStartedWithString(string publisherName)
        {
            List<Book> list = new List<Book>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "GetBooksWherePublisherStartsWith";
                cmd.CommandType = CommandType.StoredProcedure;
                IDbDataParameter databasePublisherName = Common.CreateParameter("@publisherName", DbType.String, publisherName);

                cmd.Parameters.Add(databasePublisherName);

                var reader = cmd.ExecuteReader();
                Book book;
                while (reader.Read())
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

                    list.Add(book);
                }
            }

            return list.GroupBy(book => book.Publisher);
        }

        public IEnumerable<IGrouping<int, LibraryItem>> GetItemsGroupedByYearPublishing()
        {
            List<LibraryItem> list = new List<LibraryItem>();
            using (IDbConnection connection = Common.CreateConnection())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAll";

                IDbDataParameter sortingMode = Common.CreateParameter("@sortParam", DbType.Int32, 0);

                cmd.Parameters.Add(sortingMode);

                var reader = cmd.ExecuteReader();
                string type;
                while (reader.Read())
                {
                    type = (string)reader["Type"];
                    if (type == "patent")
                    {
                        Patent patent = new Patent()
                        {
                            Country = (string)reader["country"],
                            DateOfPublication = (DateTime)reader["date_of_publication"],
                            Id = (int)reader["library_item_ID"],
                            Name = (string)reader["title"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            RegNumber = (string)reader["reg_number"],
                            SubmissionDocuments = (DateTime)reader["date_of_submission"],
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                        patent.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));

                        list.Add(patent);
                    }
                    else if (type == "paper")
                    {
                        PaperIssue pi = new PaperIssue()
                        {
                            CityOfPublishing = (string)reader["cityOfPublication"],
                            DateOfIssue = (DateTime)reader["dateOfIssue"],
                            Id = (int)reader["library_item_ID"],
                            IssueNumber = (int)reader["number_of_issue"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            Paper = new Paper()
                            {
                                Id = (int)reader["id"],
                                Issn = (string)reader["ISSN"],
                                Name = (string)reader["title"]
                            },
                            Publisher = new Publisher
                            {
                                Id = (int)reader["publisherId"],
                                PublisherName = (string)reader["publisherName"],
                            },
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        list.Add(pi);
                    }
                    else if (type == "book")
                    {
                        Book book = new Book()
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
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }
            }

            return list.GroupBy(item => item.YearOfPublishing);
        }

        public IEnumerable<LibraryItem> GetLibraryItemsByTitle(string title)
        {
            List<LibraryItem> list = new List<LibraryItem>();
            using (IDbConnection connection = Common.CreateConnection())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllItemsByTitle";
                IDbDataParameter databaseTitle = Common.CreateParameter("@title", DbType.String, title);
                cmd.Parameters.Add(databaseTitle);

                var reader = cmd.ExecuteReader();
                string type;
                while (reader.Read())
                {
                    type = (string)reader["Type"];
                    if (type == "patent")
                    {
                        Patent patent = new Patent()
                        {
                            Country = (string)reader["country"],
                            DateOfPublication = (DateTime)reader["date_of_publication"],
                            Id = (int)reader["library_item_ID"],
                            Name = (string)reader["title"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            RegNumber = (string)reader["reg_number"],
                            SubmissionDocuments = (DateTime)reader["date_of_submission"],
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                        patent.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));

                        list.Add(patent);
                    }
                    else if (type == "paper")
                    {
                        PaperIssue pi = new PaperIssue()
                        {
                            CityOfPublishing = (string)reader["cityOfPublication"],
                            DateOfIssue = (DateTime)reader["dateOfIssue"],
                            Id = (int)reader["library_item_ID"],
                            IssueNumber = (int)reader["number_of_issue"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            Paper = new Paper()
                            {
                                Id = (int)reader["id"],
                                Issn = (string)reader["ISSN"],
                                Name = (string)reader["title"]
                            },
                            Publisher = new Publisher
                            {
                                Id = (int)reader["publisherId"],
                                PublisherName = (string)reader["publisherName"],
                            },
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        list.Add(pi);
                    }
                    else if (type == "book")
                    {
                        Book book = new Book()
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
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }
            }

            return list.ToArray();
        }

        public IEnumerable<LibraryItem> GetPatentsByAuthor(Author author)
        {
            List<Patent> list = new List<Patent>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPatentsByAuthor";

                IDbDataParameter authorId = Common.CreateParameter("authorId", DbType.Int32, author.Id);

                cmd.Parameters.Add(authorId);

                var reader = cmd.ExecuteReader();
                Patent patent;

                while (reader.Read())
                {
                    patent = new Patent
                    {
                        Country = (string)reader["country"],
                        DateOfPublication = (DateTime)reader["date_of_publication"],
                        Id = (int)reader["library_item_ID"],
                        Name = (string)reader["title"],
                        Note = (string)reader["note"],
                        NumberOfPages = (int)reader["number_of_pages"],
                        RegNumber = (string)reader["reg_number"],
                        SubmissionDocuments = (DateTime)reader["date_of_submission"],
                        YearOfPublishing = (int)reader["YearOfPublication"],
                    };

                    XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                    patent.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));

                    list.Add(patent);
                }
            }

            return list;
        }

        public IEnumerable<LibraryItem> GetAllItemsSortedByYearOfPublishing(Enums.Order order)
        {
            List<LibraryItem> list = new List<LibraryItem>();
            using (IDbConnection connection = Common.CreateConnection())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAll";

                IDbDataParameter sortingMode = Common.CreateParameter("@sortParam", DbType.Int32, (int)order);

                cmd.Parameters.Add(sortingMode);

                var reader = cmd.ExecuteReader();
                string type;
                while (reader.Read())
                {
                    type = (string)reader["Type"];
                    if (type == "patent")
                    {
                        Patent patent = new Patent()
                        {
                            Country = (string)reader["country"],
                            DateOfPublication = (DateTime)reader["date_of_publication"],
                            Id = (int)reader["library_item_ID"],
                            Name = (string)reader["title"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            RegNumber = (string)reader["reg_number"],
                            SubmissionDocuments = (DateTime)reader["date_of_submission"],
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        XElement xmlAuthor = XElement.Parse((string)reader["authors"]);
                        patent.Authors = new HashSet<Author>(Common.GetAuthorsFromXML(xmlAuthor));

                        list.Add(patent);
                    }
                    else if (type == "paper")
                    {
                        PaperIssue pi = new PaperIssue()
                        {
                            CityOfPublishing = (string)reader["cityOfPublication"],
                            DateOfIssue = (DateTime)reader["dateOfIssue"],
                            Id = (int)reader["library_item_ID"],
                            IssueNumber = (int)reader["number_of_issue"],
                            Note = (string)reader["note"],
                            NumberOfPages = (int)reader["number_of_pages"],
                            Paper = new Paper()
                            {
                                Id = (int)reader["id"],
                                Issn = (string)reader["ISSN"],
                                Name = (string)reader["title"]
                            },
                            Publisher = new Publisher
                            {
                                Id = (int)reader["publisherId"],
                                PublisherName = (string)reader["publisherName"],
                            },
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        list.Add(pi);
                    }
                    else if (type == "book")
                    {
                        Book book = new Book()
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
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }
            }

            return list.ToArray();
        }
    }
}
