using System.Collections.Generic;
using Entities;

namespace DataAccessLayer.Repository
{
    internal class PaperIssueRepository
    {
        private static PaperIssueRepository paperIssueRepository;

        static PaperIssueRepository()
        {
            paperIssueRepository = new PaperIssueRepository();
        }

        private PaperIssueRepository()
        {
            this.Papers = new List<PaperIssue>();
        }

        internal List<PaperIssue> Papers { get; set; }

        public static PaperIssueRepository GetPaperIssueRepository()
        {
            return paperIssueRepository;
        }
    }
}