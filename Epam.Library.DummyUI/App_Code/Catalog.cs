using Entities;
using Epam.Library.NinjectKernel;
using Epam.Library.UI.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Epam.Library.UI.App_Code
{
    public class Catalog : IHttpHandler
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

        private StringBuilder GetAuthors(HashSet<Author> authors)
        {
            StringBuilder authorStringBuilder = new StringBuilder();

                    if (authors.Count > 0)
                    {
                        foreach (Author author in authors)
                        {
                            authorStringBuilder.Append(author.FirstName).Append(" ").Append(author.LastName).Append(@"</br>");
                        }
                    }
                    else
                    {
                        authorStringBuilder.Append(@"<td></td>");
                    }

            return authorStringBuilder;
        }

        private string GetRows(IEnumerable<LibraryItem> items)
        {
            StringBuilder rows = new StringBuilder(Resources.oneRow);

            foreach (LibraryItem item in items)
            {
                if (item is Book)
                {
                    Book book = (Book)item;

                    rows.Replace("@type", "Book");
                    rows.Replace("@name", book.Name);
                    rows.Replace("@thethird", GetAuthors(book.Authors).ToString());
                    rows.Replace("@id", book.Id.ToString());

                }
                else if (item is PaperIssue)
                {
                    PaperIssue pi = (PaperIssue)item;

                    rows.Replace("@type", "Paper");
                    rows.Replace("@name", pi.Paper.Name);
                    rows.Replace("@thethird", pi.IssueNumber.ToString());
                    rows.Replace("@id", pi.Id.ToString());
                }
                else if (item is Patent)
                {
                    Patent patent = (Patent)item;

                    rows.Replace("@type", "Patent");
                    rows.Replace("@name", patent.Name);
                    rows.Replace("@thethird", GetAuthors(patent.Authors).ToString());
                    rows.Replace("@id", patent.Id.ToString());
                }
                else
                {
                    rows.Append(@"<td>Unknown type</td>");
                }
            }

            return rows.ToString();
        }

        public void ProcessRequest(HttpContext context)
        {
            IEnumerable<LibraryItem> items = Initializer.CommonAccessLogic.GetAll();
            context.Response.ContentType = "text/html";
            context.Response.Write(Resources.catalogTemplate.Replace("@rows", GetRows(items)));
        }

        #endregion
    }
}
