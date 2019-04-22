using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;
using Utility;

namespace DataAccessLayer.DaoAccess
{
    public class FilteredDAO : IFilteredDAO
    {
        public IEnumerable<LibraryItem> GetBooksAndPatentsByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("Author reference is null", nameof(author));
            }

            List<LibraryItem> list = new List<LibraryItem>();

            list.Concat(from patent in PatentRepository.GetPatentRepository().Patents
                        where patent.Authors.Contains(author)
                        select patent);

            list.Concat(BookRepository.GetBookRepository().Books.Where(book => book.Authors.Contains(author)));

            return list.ToArray();
        }

        public IEnumerable<LibraryItem> GetBooksByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("Author reference is null", nameof(author));
            }

            var result = from book in BookRepository.GetBookRepository().Books
                         where book.Authors.Contains(author)
                         select book;
            return result.ToArray();
        }

        public IEnumerable<IGrouping<Publisher, Book>> GetBooksGroupedByPublisherStartedWithString(string publisherName)
        {
            IEnumerable<Publisher> publishers = PublisherRepository.GetPublisherRepository().Publishers.Where(publisher => publisher.PublisherName.StartsWith(publisherName));

            return BookRepository.GetBookRepository().Books.Where(book => publishers.Contains(book.Publisher)).GroupBy(s => s.Publisher);
        }

        public IEnumerable<IGrouping<int, LibraryItem>> GetItemsByYearPublishing()
        {
            List<LibraryItem> result = new List<LibraryItem>();
            result.Concat(BookRepository.GetBookRepository().Books).Concat(PaperIssueRepository.GetPaperIssueRepository().Papers).Concat(PatentRepository.GetPatentRepository().Patents);
            return result.GroupBy(s => s.YearOfPublishing);
        }

        public IEnumerable<IGrouping<int, LibraryItem>> GetItemsGroupedByYearPublishing()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibraryItem> GetLibraryItemsByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is null or empty", nameof(title));
            }

            List<LibraryItem> list = new List<LibraryItem>();

            list.Concat(from patent in PatentRepository.GetPatentRepository().Patents
                        where patent.Name.Contains(title)
                        select patent);

            list.Concat(from book in BookRepository.GetBookRepository().Books
                        where book.Name.Contains(title)
                        select book);

            list.Concat(from newspaper in PaperIssueRepository.GetPaperIssueRepository().Papers
                        where newspaper.Paper.Name.Contains(title)
                        select newspaper);

            return list.ToArray();
        }

        public IEnumerable<LibraryItem> GetPatentsByAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("Author reference is null", nameof(author));
            }

            var result = from patent in PatentRepository.GetPatentRepository().Patents
                         where patent.Authors.Contains(author)
                         select patent;
            return result.ToArray();
        }

        public IEnumerable<LibraryItem> GetSortedByYearOfPublishing()
        {
            List<LibraryItem> result = new List<LibraryItem>();
            result.Concat(BookRepository.GetBookRepository().Books).Concat(PaperIssueRepository.GetPaperIssueRepository().Papers).Concat(PatentRepository.GetPatentRepository().Patents);
            return result.ToArray().OrderBy(s => s.YearOfPublishing);
        }

        public IEnumerable<LibraryItem> GetAllItemsSortedByYearOfPublishing(Enums.Order order)
        {
            throw new NotImplementedException();
        }
    }
}