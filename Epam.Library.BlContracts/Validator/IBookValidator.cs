using System.Collections.Generic;
using Entities;

namespace BlContracts
{
    public interface IBookValidator
    {
        bool IsValidTitle(string title);

        bool IsValidAuthor(HashSet<Author> authors);

        bool IsValidCity(string city);

        bool IsValidPublisher(Publisher publisher);

        bool IsValidYearOfPublishing(int year);

        bool IsValidNumberOfPages(int pages);

        bool IsValidNote(string note);

        bool IsValidISBN(string isbn);
    }
}