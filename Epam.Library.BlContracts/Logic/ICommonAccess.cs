using System.Collections.Generic;
using Entities;
using Utility.Filter;

namespace BlContracts.Logic
{
    public interface ICommonAccess
    {
        IEnumerable<LibraryItem> GetAll();

        IEnumerable<LibraryItem> GetAll(int pageNumber, int numberOfResults, out int totalResult);

        LibraryItem GetItemById(int id);

        IEnumerable<T> GetByFilter<T>(AbstractFilter filter);

        bool Delete(int id);
    }
}