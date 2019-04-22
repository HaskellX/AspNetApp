using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;
using Utility.Filter;

namespace DataAccessLayer.DaoAccess
{
    public class CommonDAO : ICommonDAO
    {
        public IEnumerable<LibraryItem> GetAllLibraryItems()
        {
            List<LibraryItem> result = new List<LibraryItem>();
            result.Concat(BookRepository.GetBookRepository().Books).Concat(PaperIssueRepository.GetPaperIssueRepository().Papers).Concat(PatentRepository.GetPatentRepository().Patents);

            return result.ToArray();
        }

        public IEnumerable<LibraryItem> GetAllLibraryItems(int pageNumber, int numberOfResults, out int totalResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetByFilter<T>(AbstractFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentException();
            }

            throw new NotImplementedException();
        }

        public LibraryItem GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}