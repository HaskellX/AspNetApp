using System;
using System.Collections.Generic;

namespace Entities
{
    public class Patent : LibraryItem
    {
        public HashSet<Author> Authors { get; set; }

        public string Country { get; set; }

        public string RegNumber { get; set; }

        public DateTime SubmissionDocuments { get; set; }

        public DateTime DateOfPublication { get; set; }

        public string Name { get; set; }

        public int NumberOfPages { get; set; }

        public string Note { get; set; }

        public override bool Equals(object obj)
        {
            Patent patent = obj as Patent;
            if (patent == null)
            {
                return false;
            }

            return
                this.RegNumber == patent.RegNumber &&
                this.Country == patent.Country;
        }

        public override int GetHashCode()
        {
            int regNumber = 0;
            int.TryParse(this.RegNumber, out regNumber);
            return regNumber.GetHashCode() ^ this.Country.GetHashCode();
        }
    }
}