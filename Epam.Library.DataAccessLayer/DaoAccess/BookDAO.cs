using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.DaoAccess
{
    public class BookDAO : IBookDAO
    {
        public int AddItem(Book book)
        {
            book.Id = ++IdStorage.UniqueId;
            BookRepository.GetBookRepository().Books.Add(book);
            return IdStorage.UniqueId;
        }

        public bool Exists(Book book)
        {
            if (!string.IsNullOrEmpty(book.ISBN))
            {
                var result = from bookEnt in BookRepository.GetBookRepository().Books
                             where bookEnt.ISBN == book.ISBN
                             select bookEnt;

                return result.Any();
            }
            else
            {
                var result = from bookEnt in BookRepository.GetBookRepository().Books
                             where bookEnt.Name == book.Name
                             where bookEnt.YearOfPublishing == book.YearOfPublishing
                             where bookEnt.Authors == book.Authors
                             select bookEnt;
                return result.Any();
            }
        }

        public IEnumerable<Book> GetAllItems()
        {
            return BookRepository.GetBookRepository().Books.ToArray();
        }

        public Book GetItemById(int id)
        {
            return BookRepository.GetBookRepository().Books.FirstOrDefault(i => i.Id == id);
        }

        public bool RemoveItem(int id)
        {
            var result = BookRepository.GetBookRepository().Books.RemoveAll(book => book.Id == id);

            return result > 0;
        }

        public bool Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}