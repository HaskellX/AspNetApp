using System.Collections.Generic;
using System.Linq;
using Entities;
using Utility;

namespace DalContracts
{
    public interface IFilteredDAO
    {
        IEnumerable<LibraryItem> GetLibraryItemsByTitle(string title);

        IEnumerable<LibraryItem> GetAllItemsSortedByYearOfPublishing(Enums.Order order);

        IEnumerable<LibraryItem> GetBooksByAuthor(Author author);

        IEnumerable<LibraryItem> GetPatentsByAuthor(Author author);

        IEnumerable<LibraryItem> GetBooksAndPatentsByAuthor(Author author);

        IEnumerable<IGrouping<Publisher, Book>> GetBooksGroupedByPublisherStartedWithString(string publisherName);

        IEnumerable<IGrouping<int, LibraryItem>> GetItemsGroupedByYearPublishing();
    }
}