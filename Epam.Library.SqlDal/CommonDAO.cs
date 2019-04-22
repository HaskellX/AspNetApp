using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalContracts;
using Entities;
using Utility.Filter;

namespace Epam.Library.SqlDal
{
    public class CommonDAO : ICommonDAO
    {
        public IEnumerable<LibraryItem> GetAllLibraryItems()
        {
            List<LibraryItem> list = new List<LibraryItem>();
            using (IDbConnection connection = Common.CreateConnection())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAll";

                IDbDataParameter sortingMode = Common.CreateParameter("@sortParam", DbType.Int32, (int)0);

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
                                Issn = reader["ISSN"] as string,
                                Name = (string)reader["title"]
                            },
                            Publisher = new Publisher
                            {
                                Id = (int)reader["publisher_Id"],
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
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }
            }

            return list.ToArray();
        }

        public LibraryItem GetItemById(int id)
        {
            LibraryItem li = null;
            using (IDbConnection connection = Common.CreateConnection())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetItemById";

                IDbDataParameter itemDbId = Common.CreateParameter("@id", DbType.Int32, id);

                cmd.Parameters.Add(itemDbId);


                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string type = (string)reader["Type"];
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

                        li = patent;
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
                                Issn = reader["ISSN"] as string,
                                Name = (string)reader["title"]
                            },
                            Publisher = new Publisher
                            {
                                Id = (int)reader["publisher_Id"],
                                PublisherName = (string)reader["publisherName"],
                            },
                            YearOfPublishing = (int)reader["YearOfPublication"],
                        };

                        li = pi;
                    }
                    else if (type == "book")
                    {
                        Book book = new Book()
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

                        li = book;
                    }
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }
            }

            return li;
        }

        public IEnumerable<T> GetByFilter<T>(AbstractFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibraryItem> GetAllLibraryItems(int pageNumber, int numberOfResults, out int totalResult)
        {
            List<LibraryItem> list = new List<LibraryItem>();
            //totalResult = -1;
            int offset = (pageNumber - 1) * numberOfResults;
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllOffset";


                IDbDataParameter sortingMode = Common.CreateParameter<int>("@sortParam", DbType.Int32, 0);
                IDbDataParameter offsetDB = Common.CreateParameter<int>("@offset", DbType.Int32, offset);
                IDbDataParameter numberOfResultsDB = Common.CreateParameter<int>("@page", DbType.Int32, numberOfResults);
                IDbDataParameter totalResultDB = Common.CreateOutputParameter("@totalResult", DbType.Int32);

                cmd.Parameters.AddRange(new[] { sortingMode, offsetDB, numberOfResultsDB, totalResultDB });

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
                                Issn = reader["ISSN"] as string,
                                Name = (string)reader["title"]
                            },
                            Publisher = new Publisher
                            {
                                Id = (int)reader["publisher_Id"],
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
                    else
                    {
                        throw new Exception("Unexpected type of an object in database");
                    }
                }

                reader.Close();
                totalResult = (int)totalResultDB.Value;
            }
            return list.ToArray();
        }

        public bool Delete(int id)
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
    }
}
