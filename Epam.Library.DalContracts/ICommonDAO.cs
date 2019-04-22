using System.Collections.Generic;
using System.Linq;
using Entities;
using Utility.Filter;

namespace DalContracts
{
    public interface ICommonDAO
    {
        IEnumerable<LibraryItem> GetAllLibraryItems();

        IEnumerable<LibraryItem> GetAllLibraryItems(int pageNumber, int numberOfResults, out int totalResult);

        LibraryItem GetItemById(int id);

        IEnumerable<T> GetByFilter<T>(AbstractFilter filter);

        bool Delete(int id);
    }
}