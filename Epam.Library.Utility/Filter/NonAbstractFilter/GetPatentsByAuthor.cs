using System;
using Entities;

namespace Utility.Filter.NonAbstractFilter
{
    public class GetPatentsByAuthor : AbstractFilter
    {
        public GetPatentsByAuthor(Author author)
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