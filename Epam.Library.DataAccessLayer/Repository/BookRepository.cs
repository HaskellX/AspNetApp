using System.Collections.Generic;
using Entities;

namespace DataAccessLayer.Repository
{
    internal class BookRepository
    {
        private static BookRepository bookRepository;

        static BookRepository()
        {
            bookRepository = new BookRepository();
        }

        private BookRepository()
        {
            this.Books = new List<Book>();
        }

        internal List<Book> Books { get; set; }

        public static BookRepository GetBookRepository()
        {
            return bookRepository;
        }
    }
}