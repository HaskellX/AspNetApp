using System;
using System.Collections.Generic;
using BlContracts;
using BlContracts.Logic;
using DalContracts;
using Entities;
using BL_Contracts;
using Entities.Exceptions;

namespace BusinessLogicLayer.Logic
{
    public class BookLogic : IBookLogic
    {
        private IBookDAO bookDAO;
        private IBookValidator bookValidator;
        private ILogger logger;

        public BookLogic(IBookDAO bookDAO, IBookValidator bookValidator, ILogger logger)
        {
            this.logger = logger;
            this.bookDAO = bookDAO;
            this.bookValidator = bookValidator;
        }

        public int Add(string name, HashSet<Author> author, string cityOfPublishing, Publisher inputPublisher, int yearOfPublishing, int numberOfPages, string note, string inputISBN)
        {
            if (!this.bookValidator.IsValidTitle(name))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidAuthor(author))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidCity(cityOfPublishing))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidPublisher(inputPublisher))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidYearOfPublishing(yearOfPublishing))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidNumberOfPages(numberOfPages))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidNote(note))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidISBN(inputISBN))
            {
                throw new ArgumentException();
            }

            Book book = new Book()
            {
                Name = name,
                Authors = author,
                ISBN = inputISBN,
                CityOfPublishing = cityOfPublishing,
                Note = note,
                NumberOfPages = numberOfPages,
                Publisher = inputPublisher,
                YearOfPublishing = yearOfPublishing,
            };

            if (this.bookDAO.Exists(book))
            {
                throw new Exception();
            }

            try
            {
                return this.bookDAO.AddItem(book);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Update(int id, string name, HashSet<Author> author, string cityOfPublishing, Publisher inputPublisher, int yearOfPublishing, int numberOfPages, string note, string inputISBN)
        {
            if (id < 1)
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidTitle(name))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidAuthor(author))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidCity(cityOfPublishing))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidPublisher(inputPublisher))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidYearOfPublishing(yearOfPublishing))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidNumberOfPages(numberOfPages))
            {
                throw new ArgumentException();
            }

            if (!this.bookValidator.IsValidISBN(inputISBN))
            {
                throw new ArgumentException();
            }

            Book book = new Book()
            {
                Id = id,
                Name = name,
                Authors = author,
                ISBN = inputISBN,
                CityOfPublishing = cityOfPublishing,
                Note = note,
                NumberOfPages = numberOfPages,
                Publisher = inputPublisher,
                YearOfPublishing = yearOfPublishing,
            };

            try
            {
                return this.bookDAO.Update(book);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }

        }

        public bool Delete(int id)
        {
            try
            {
                return this.bookDAO.RemoveItem(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                return this.bookDAO.GetAllItems();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public Book GetBookById(int id)
        {
            try
            {
                return this.bookDAO.GetItemById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}