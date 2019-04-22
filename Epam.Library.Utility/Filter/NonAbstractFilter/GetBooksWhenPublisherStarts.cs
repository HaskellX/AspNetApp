using System;

namespace Utility.Filter.NonAbstractFilter
{
    public class GetBooksWhenPublisherStarts : AbstractFilter
    {
        public GetBooksWhenPublisherStarts(string input)
        {
            if (input == null)
            {
                throw new ArgumentException();
            }

            this.PublisherName = input;
        }

        public string PublisherName { get; private set; }
    }
}