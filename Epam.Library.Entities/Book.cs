using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Book : LibraryItem
    {
        public HashSet<Author> Authors { get; set; }

        public string CityOfPublishing { get; set; }

        public Publisher Publisher { get; set; }

        public string ISBN { get; set; }

        public string Name { get; set; }

        public int NumberOfPages { get; set; }

        public string Note { get; set; }

        public override bool Equals(object obj)
        {
            Book book = obj as Book;
            if (book == null)
            {
                return false;
            }

            if (this.ISBN != null ||
                book.ISBN != null)
            {
                return this.ISBN == book.ISBN;
            }

            return
                this.Name == book.Name &&
                this.Authors.SetEquals(book.Authors) &&
                this.YearOfPublishing == book.YearOfPublishing;
        }

        public override int GetHashCode()
        {
            if (this.ISBN != null)
            {
                return this.ISBN.GetHashCode();
            }

            return this.Name.GetHashCode() ^ this.YearOfPublishing ^ this.Authors.Aggregate(0, (s, a) => s ^ a.GetHashCode());
        }
    }
}