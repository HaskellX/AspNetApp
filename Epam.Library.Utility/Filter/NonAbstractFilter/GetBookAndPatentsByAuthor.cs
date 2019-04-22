using System;
using Entities;

namespace Utility.Filter.NonAbstractFilter
{
    public class GetBookAndPatentsByAuthor : AbstractFilter
    {
        public GetBookAndPatentsByAuthor(Author author)
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