using System;

namespace Entities
{
    public class PaperIssue : LibraryItem
    {
        public string CityOfPublishing { get; set; }

        public Publisher Publisher { get; set; }

        public Paper Paper { get; set; }

        public int IssueNumber { get; set; }

        public DateTime DateOfIssue { get; set; }

        public int NumberOfPages { get; set; }

        public string Note { get; set; }

        public override bool Equals(object obj)
        {
            PaperIssue paper = obj as PaperIssue;
            if (paper == null)
            {
                return false;
            }

            if (this.Paper.Issn != null &&
                paper.Paper.Issn != null)
            {
                return this.Paper.Issn == paper.Paper.Issn && this.Paper.Name == paper.Paper.Name;
            }

            return
                this.Paper.Name == paper.Paper.Name &&
                this.Publisher.Equals(paper.Publisher) &&
                this.DateOfIssue == paper.DateOfIssue;
        }

        public override int GetHashCode()
        {
            if (this.Paper.Issn != null)
            {
                return this.Paper.Issn.GetHashCode();
            }

            return this.Paper.Name.GetHashCode() ^ this.Publisher.GetHashCode() ^ this.DateOfIssue.GetHashCode();
        }
    }
}