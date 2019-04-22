using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalContracts;
using Entities;

namespace Epam.Library.SqlDal
{
    public class PatentDAO : IPatentDAO
    {
        public int AddItem(Patent patent)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPatent";
                StringBuilder sb = new StringBuilder();
                sb.Capacity = patent.Authors.Count * 2;
                foreach (Author auth in patent.Authors)
                {
                    sb.Append(auth.Id);
                    sb.Append(',');
                }

                sb.Remove(sb.Length - 1, 1);

                IDbDataParameter authors = Common.CreateParameter("@authors", DbType.String, sb.ToString());
                IDbDataParameter id = Common.CreateOutputParameter("@id", DbType.Int32);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, patent.Name);
                IDbDataParameter country = Common.CreateParameter("@country", DbType.String, patent.Country);
                IDbDataParameter regNumber = Common.CreateParameter("@regnumber", DbType.Int32, patent.RegNumber);
                IDbDataParameter dateOfSubmission = Common.CreateParameter("@date_of_submission", DbType.DateTime, patent.SubmissionDocuments);
                IDbDataParameter dateOfPublicaton = Common.CreateParameter("@date_of_publication", DbType.DateTime, patent.DateOfPublication);
                IDbDataParameter numberOfPages = Common.CreateParameter("@number_of_pages", DbType.Int32, patent.NumberOfPages);
                IDbDataParameter note = Common.CreateParameter("@note", DbType.String, patent.Note);
                IDbDataParameter yearOfPublication = Common.CreateParameter("@yearOfPublication", DbType.Int32, patent.YearOfPublishing);

                cmd.Parameters.AddRange(new[] { authors, id, title, country, regNumber, dateOfSubmission, dateOfPublicaton, numberOfPages, note, yearOfPublication });
                cmd.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public bool Exists(Patent patent)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PatentExists";

                IDbDataParameter id = Common.CreateOutputParameter("@Exists", DbType.Int32);
                IDbDataParameter country = Common.CreateParameter("@Country", DbType.String, patent.Country);
                IDbDataParameter regnumber = Common.CreateParameter("@Regnumber", DbType.String, patent.RegNumber);

                cmd.Parameters.AddRange(new[] { id, country, regnumber });

                cmd.ExecuteNonQuery();

                return (int)id.Value == 1;
            }
        }

        public IEnumerable<Patent> GetAllItems()
        {
            List<Patent> list = new List<Patent>();
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllPatents";

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

        public Patent GetItemById(int id)
        {
            Patent patent = null;
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPatentById";

                IDbDataParameter databaseId = Common.CreateParameter("@id", DbType.Int32, id);

                cmd.Parameters.AddRange(new[] { databaseId });

                var reader = cmd.ExecuteReader();

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
                }
            }

            return patent;
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

        public bool Update(Patent patent)
        {
            using (var connection = Common.CreateConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePatent";
                StringBuilder sb = new StringBuilder();
                sb.Capacity = patent.Authors.Count * 2;
                foreach (Author auth in patent.Authors)
                {
                    sb.Append(auth.Id);
                    sb.Append(',');
                }

                sb.Remove(sb.Length - 1, 1);

                IDbDataParameter authors = Common.CreateParameter("@authors", DbType.String, sb.ToString());
                IDbDataParameter id = Common.CreateParameter("@id", DbType.Int32, patent.Id);
                IDbDataParameter title = Common.CreateParameter("@title", DbType.String, patent.Name);
                IDbDataParameter country = Common.CreateParameter("@country", DbType.String, patent.Country);
                IDbDataParameter regNumber = Common.CreateParameter("@regnumber", DbType.Int32, patent.RegNumber);
                IDbDataParameter dateOfSubmission = Common.CreateParameter("@date_of_submission", DbType.DateTime, patent.SubmissionDocuments);
                IDbDataParameter dateOfPublicaton = Common.CreateParameter("@date_of_publication", DbType.DateTime, patent.DateOfPublication);
                IDbDataParameter numberOfPages = Common.CreateParameter("@number_of_pages", DbType.Int32, patent.NumberOfPages);
                IDbDataParameter note = Common.CreateParameter("@note", DbType.String, patent.Note);
                IDbDataParameter yearOfPublication = Common.CreateParameter("@yearOfPublication", DbType.Int32, patent.YearOfPublishing);

                cmd.Parameters.AddRange(new[] { authors, id, title, country, regNumber, dateOfSubmission, dateOfPublicaton, numberOfPages, note, yearOfPublication });
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
