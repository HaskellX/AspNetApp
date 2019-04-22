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
    public class PaperIssueDAO : IPaperIssueDAO
    {
        public int AddItem(PaperIssue paper)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPaperIssue";

                IDbDataParameter id = Common.CreateOutputParameter("@id", DbType.Int32);
                IDbDataParameter paperId = Common.CreateParameter("@paperId", DbType.Int32, paper.Paper.Id);
                IDbDataParameter cityOfPublication = Common.CreateParameter("@cityOfPublication", DbType.String, paper.CityOfPublishing);
                IDbDataParameter publisherId = Common.CreateParameter("@publisherId", DbType.Int32, paper.Publisher.Id);
                IDbDataParameter numberOfPages = Common.CreateParameter("@numberOfPages", DbType.Int32, paper.NumberOfPages);
                IDbDataParameter note = Common.CreateParameter("@note", DbType.String, paper.Note);
                IDbDataParameter numberOfIssue = Common.CreateParameter("@number_of_issue", DbType.Int32, paper.IssueNumber);
                IDbDataParameter yearOfPublishing = Common.CreateParameter("@yearOfPublishing", DbType.Int32, paper.YearOfPublishing);
                IDbDataParameter dateOfIssue = Common.CreateParameter("@dateOfIssue", DbType.Date, paper.DateOfIssue);

                cmd.Parameters.AddRange(new[] { id, paperId, cityOfPublication, publisherId, numberOfPages, note, numberOfIssue, yearOfPublishing, dateOfIssue });

                cmd.ExecuteNonQuery();

                return (int)id.Value;
            }
        }

        public bool Exists(PaperIssue paper)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PaperIssueExists";

                IDbDataParameter id = Common.CreateOutputParameter("@Exists", DbType.Int32);
                IDbDataParameter publisherId = Common.CreateParameter("@publisherID", DbType.Int32, paper.Publisher.Id);
                IDbDataParameter dataOfIssue = Common.CreateParameter("@dateOfIssue", DbType.Date, paper.DateOfIssue);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, paper.Paper.Name);

                cmd.Parameters.AddRange(new[] { id, publisherId, dataOfIssue, title });

                cmd.ExecuteNonQuery();

                return (int)id.Value == 1;
            }
        }

        public IEnumerable<PaperIssue> GetAllItems()
        {
            List<PaperIssue> list = new List<PaperIssue>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPaperIssues";

                PaperIssue pi = new PaperIssue();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pi = new PaperIssue()
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
                    list.Add(pi);
                }
            }

            return list.ToArray();
        }

        public PaperIssue GetItemById(int id)
        {
            PaperIssue pi = null;
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPaperIssueById";
                IDbDataParameter idDb = Common.CreateParameter("@id", DbType.Int32, id);
                cmd.Parameters.Add(idDb);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pi = new PaperIssue()
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
                }
            }

            return pi;
        }

        public IEnumerable<PaperIssue> GetPaperIssuesByPaperId(int id)
        {
            List<PaperIssue> list = new List<PaperIssue>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPaperIssuesByPaperId";

                IDbDataParameter paperIdDb = Common.CreateParameter<int>("@id", DbType.Int32, id);
                cmd.Parameters.Add(paperIdDb);

                PaperIssue pi = new PaperIssue();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pi = new PaperIssue()
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
                    list.Add(pi);
                }
            }

            return list.ToArray();
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

                IDbDataParameter itemId = Common.CreateParameter("@id", DbType.String, id);

                cmd.Parameters.Add(itemId);

                result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Update(PaperIssue paper)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePaperIssue";

                IDbDataParameter id = Common.CreateParameter("@id", DbType.Int32, paper.Id);
                IDbDataParameter paperId = Common.CreateParameter("@paperId", DbType.Int32, paper.Paper.Id);
                IDbDataParameter cityOfPublication = Common.CreateParameter("@cityOfPublication", DbType.String, paper.CityOfPublishing);
                IDbDataParameter publisherId = Common.CreateParameter("@publisherId", DbType.Int32, paper.Publisher.Id);
                IDbDataParameter numberOfPages = Common.CreateParameter("@numberOfPages", DbType.Int32, paper.NumberOfPages);
                IDbDataParameter note = Common.CreateParameter("@note", DbType.String, paper.Note);
                IDbDataParameter numberOfIssue = Common.CreateParameter("@number_of_issue", DbType.Int32, paper.IssueNumber);
                IDbDataParameter yearOfPublishing = Common.CreateParameter("@yearOfPublishing", DbType.Int32, paper.YearOfPublishing);
                IDbDataParameter dateOfIssue = Common.CreateParameter("@dateOfIssue", DbType.Date, paper.DateOfIssue);

                cmd.Parameters.AddRange(new[] { id, paperId, cityOfPublication, publisherId, numberOfPages, note, numberOfIssue, yearOfPublishing, dateOfIssue });

                int result = cmd.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}
