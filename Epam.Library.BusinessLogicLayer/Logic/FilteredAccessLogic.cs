using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using Entities;
using Utility;
using BL_Contracts;
using Entities.Exceptions;

namespace BusinessLogicLayer.Logic
{
    public class FilteredAccessLogic
    {
        private IFilteredDAO filteredDAO;
        private ILogger logger;
        
        public FilteredAccessLogic(IFilteredDAO filteredDAO, ILogger logger)
        {
            this.logger = logger;
            this.filteredDAO = filteredDAO;
        }

        public IEnumerable<LibraryItem> GetLibraryItemsByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is empty or null", nameof(title));
            }

            try
            {
                return this.filteredDAO.GetLibraryItemsByTitle(title);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<LibraryItem> GetSortedByYearOfPublishing(Enums.Order order)
        {
            try
            {

                return this.filteredDAO.GetAllItemsSortedByYearOfPublishing(order);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<LibraryItem> GetBooksByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("author is null", nameof(author));
            }

            try
            {
                return this.filteredDAO.GetBooksByAuthor(author);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<LibraryItem> GetPatentsByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("author is null", nameof(author));
            }

            try
            {
                return this.filteredDAO.GetPatentsByAuthor(author);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<LibraryItem> GetBooksAndPatentsByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("author is null", nameof(author));
            }

            try
            {
                return this.filteredDAO.GetBooksAndPatentsByAuthor(author);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<IGrouping<Publisher, Book>> GetBooksGroupedByPublisherStartedWithString(string publisherName)
        {
            if (publisherName == null)
            {
                throw new ArgumentException("publisher name is null", nameof(publisherName));
            }

            try
            {
                return this.filteredDAO.GetBooksGroupedByPublisherStartedWithString(publisherName);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<IGrouping<int, LibraryItem>> GetItemsGroupedByYearOfPublishing()
        {
            try
            {
                return this.filteredDAO.GetItemsGroupedByYearPublishing();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}