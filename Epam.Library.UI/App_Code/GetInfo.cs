using Entities;
using Epam.Library.NinjectKernel;
using Epam.Library.UI.Properties;
using System;
using System.Text;
using System.Web;

namespace Epam.Library.UI
{
    public class GetInfo : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        private string GetInfoForBook(Book book)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(book?.Name ?? String.Empty);
            sb.Append("\n");
            sb.Append(book?.CityOfPublishing ?? String.Empty);

            sb.Append("Id:");
            sb.Append(book.Id);
            sb.Append("\n");

            sb.Append("ISBN:");
            sb.Append(book?.ISBN ?? String.Empty);
            sb.Append("\n");

            sb.Append("Note:");
            sb.Append(book?.Note ?? String.Empty);
            sb.Append("\n");

            sb.Append("NumberOfPages:");
            sb.Append(book.NumberOfPages);
            sb.Append("\n");

            sb.Append("Publisher:");
            sb.Append(book.Publisher?.PublisherName ?? String.Empty);
            sb.Append("\n");

            sb.Append("Year of publishing:");
            sb.Append(book.YearOfPublishing);
            sb.Append("\n");

            sb.Append("Authors");
            foreach(Author author in book.Authors)
            {
                sb.Append("\n");
                sb.Append(author.FirstName);
                sb.Append(" ");
                sb.Append(author.LastName);
            }

            return sb.ToString();
        }

        private string GetInfoForPatent(Patent patent)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Name of patent: ");
            sb.Append(patent?.Name ?? String.Empty);
            sb.Append("\n");

            sb.Append("Country of patent: ");
            sb.Append(patent?.Country ?? String.Empty);
            sb.Append("\n");

            sb.Append("Date of publication of the patent: ");
            sb.Append(patent.DateOfPublication);
            sb.Append("\n");

            sb.Append("Date of submission: ");
            sb.Append(patent.SubmissionDocuments);
            sb.Append("\n");

            sb.Append("Registration number: ");
            sb.Append(patent.RegNumber);
            sb.Append("\n");

            sb.Append("Number of pages: ");
            sb.Append(patent.NumberOfPages);
            sb.Append("\n");

            sb.Append("Note: ");
            sb.Append(patent?.Note ?? String.Empty);
            sb.Append("\n");

            sb.Append("Authors");
            foreach (Author author in patent.Authors)
            {
                sb.Append("\n");
                sb.Append(author.FirstName);
                sb.Append(" ");
                sb.Append(author.LastName);
            }

            return sb.ToString();
        }

        private string GetInfoForPaper(PaperIssue pi)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("City of publishing: ");
            sb.Append(pi?.CityOfPublishing ?? String.Empty);
            sb.Append("\n");

            sb.Append("Date if issue: ");
            sb.Append(pi.DateOfIssue);
            sb.Append("\n");

            sb.Append("Issue number: ");
            sb.Append(pi.IssueNumber);
            sb.Append("\n");

            sb.Append("Note: ");
            sb.Append(pi?.Note ?? String.Empty);
            sb.Append("\n");

            sb.Append("Number of pages: ");
            sb.Append(pi.NumberOfPages);
            sb.Append("\n");

            sb.Append("ISSN: ");
            sb.Append(pi.Paper?.Issn ?? String.Empty);
            sb.Append("\n");

            sb.Append("Newspaper title: ");
            sb.Append(pi.Paper?.Name ?? String.Empty);
            sb.Append("\n");

            sb.Append("Publisher:");
            sb.Append(pi.Publisher?.PublisherName ?? String.Empty);
            sb.Append("\n");

            return sb.ToString();
        }

        public void ProcessRequest(HttpContext context)
        {
                           
            //write your handler implementation here.
            StringBuilder sb = new StringBuilder();
            string url = context.Request.Url.LocalPath;
            string[] parsedUrl = url.Split(new[]{'/'});

            int result;
            int.TryParse(parsedUrl[parsedUrl.Length - 1], out result);

            LibraryItem li = Initializer.CommonAccessLogic.GetItemById(result);

            
            context.Response.ContentType = "text/plain";

            if(li is Book)
            {
                Book book = (Book)li;
                context.Response.Write(GetInfoForBook(book));
            }
            else if (li is PaperIssue)
            {
                PaperIssue pi = (PaperIssue)li;
                context.Response.Write(GetInfoForPaper(pi));
            }
            else if (li is Patent)
            {
                Patent patent = (Patent)li;
                context.Response.Write(GetInfoForPatent(patent));
            }
            else
            {
                context.Response.Write("Unexpected type");
            }
        }

        #endregion
    }
}
