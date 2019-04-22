using DalContracts;
using DataAccessLayer.DaoAccess;

namespace BusinessLogicLayer
{
    internal static class DalAccess
    {
        static DalAccess()
        {
            BookDAO = new BookDAO();
            PublisherDAO = new PublisherDAO();
            AuthorDAO = new AuthorDAO();
            PaperDAO = new PaperDAO();
            PatentDAO = new PatentDAO();
            CommonDAO = new CommonDAO();
            FilteredDAO = new FilteredDAO();
            PaperIssueDAO = new PaperIssueDAO();
        }

        internal static IPaperIssueDAO PaperIssueDAO { get; set; }

        internal static IBookDAO BookDAO { get; set; }

        internal static IPublisherDAO PublisherDAO { get; set; }

        internal static IAuthorDAO AuthorDAO { get; set; }

        internal static IPaperDAO PaperDAO { get; set; }

        internal static IPatentDAO PatentDAO { get; set; }

        internal static ICommonDAO CommonDAO { get; set; }

        internal static IFilteredDAO FilteredDAO { get; set; }
    }
}