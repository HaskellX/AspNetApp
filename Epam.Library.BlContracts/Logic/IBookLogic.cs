using System.Collections.Generic;
using Entities;

namespace BlContracts.Logic
{
    public interface IBookLogic
    {
        Book GetBookById(int id);

        bool Delete(int id);

        int Add(string name, HashSet<Author> authors, string cityOfPublishing, Publisher publisher, int yearOfPublishing, int numberOfPages, string note, string isbn);

        bool Update(int id, string name, HashSet<Author> authors, string cityOfPublishing, Publisher publisher, int yearOfPublishing, int numberOfPages, string note, string isbn);


        IEnumerable<Book> GetAllBooks();
    }
}