using System;
using Entities;

namespace Utility.Filter.NonAbstractFilter
{
    public class GetBooksByAuthor : AbstractFilter
    {
        public GetBooksByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException();
            }

            this.Author = author;
        }

        public Author Author { get; private set; }
    }
}