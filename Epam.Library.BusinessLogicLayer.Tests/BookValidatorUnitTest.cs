using System.Collections.Generic;
using BlContracts;
using BusinessLogicLayer.Validator;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicLayer.Tests
{
    [TestClass]
    public class BookValidatorUnitTest
    {
        private IBookValidator vld;

        [TestInitialize]
        public void Initialise()
        {
            this.vld = new BookValidator();
        }

        [TestMethod]
        public void GetCorrectResultWhenNumberOfPagesIsIncorrect()
        {
            int numberOfPages = -300;
            Assert.IsFalse(this.vld.IsValidNumberOfPages(numberOfPages));
        }

        [TestMethod]
        public void GetCorrectResultWhenNumberOfPagesIsCorrect()
        {
            int numberOfPages = 0;
            Assert.IsTrue(this.vld.IsValidNumberOfPages(numberOfPages));
        }

        [TestMethod]
        public void GetCorrectResultWhenAuthorIsNull()
        {
            HashSet<Author> authors = null;
            Assert.IsFalse(this.vld.IsValidAuthor(authors));
        }

        [TestMethod]
        public void GetCorrectResultWhenAuthorsAreCorrect()
        {
            HashSet<Author> authors = new HashSet<Author>()
            {
                new Author { FirstName = "Иван", LastName = "Иванов" },
            };

            Assert.IsTrue(this.vld.IsValidAuthor(authors));
        }

        [TestMethod]
        public void GetCorrectResultIfCityIsCorrect()
        {
            string city = "Moscow";
            Assert.IsTrue(this.vld.IsValidCity(city));
        }

        [TestMethod]
        public void GetCorrectResultIfCityIsIncorrect()
        {
            string city = "Mosква";
            Assert.IsFalse(this.vld.IsValidCity(city));
        }

        [TestMethod]
        public void GetCorrectResultWhenISBNIsNull()
        {
            string isbn = null;
            Assert.IsTrue(this.vld.IsValidISBN(isbn));
        }

        [TestMethod]
        public void GetCorrectResultWhenISBNIsSet()
        {
            string isbn = "ISBN 99999-12-89-X";
            Assert.IsTrue(this.vld.IsValidISBN(isbn));
        }

        [TestMethod]
        public void GetCorrectResultWhenISBNIsWrong()
        {
            string isbn = "ISBN 99999-12-XX-X";
            Assert.IsFalse(this.vld.IsValidISBN(isbn));
        }

        [TestMethod]
        public void GetCorrectResultWhenNoteIsTooLong()
        {
            string note = new string('a', 2001);
            Assert.IsFalse(this.vld.IsValidNote(note));
        }

        [TestMethod]
        public void GetCorrectResultWhenNoteIsCorrect()
        {
            string note = "Note";
            Assert.IsTrue(this.vld.IsValidNote(note));
        }

        [TestMethod]
        public void GetCorrectResultWhenPublisherIsNull()
        {
            Publisher publisher = null;
            Assert.IsFalse(this.vld.IsValidPublisher(publisher));
        }

        [TestMethod]
        public void GetCorrectResultWhenPublisherIsNotNull()
        {
            Publisher publisher = new Publisher();
            Assert.IsTrue(this.vld.IsValidPublisher(publisher));
        }

        [TestMethod]
        public void GetCorrectResultWhenTitleIsNull()
        {
            string title = null;
            Assert.IsFalse(this.vld.IsValidTitle(title));
        }

        [TestMethod]
        public void GetCorrectResultWhenTitleIsTooLong()
        {
            string title = new string('x', 301);
            Assert.IsFalse(this.vld.IsValidTitle(title));
        }

        [TestMethod]
        public void GetCorrectResultWhenTitleIsCorrect()
        {
            string title = "Correct title";
            Assert.IsTrue(this.vld.IsValidTitle(title));
        }
    }
}