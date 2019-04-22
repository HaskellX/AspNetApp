using System.Collections.Generic;
using Entities;

namespace DalContracts
{
    public interface IBookDAO
    {
        bool RemoveItem(int id);

        Book GetItemById(int id);

        IEnumerable<Book> GetAllItems();

        int AddItem(Book book);

        bool Update(Book book);

        bool Exists(Book book);
    }
}