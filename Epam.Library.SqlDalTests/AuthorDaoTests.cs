using System;
using System.IO;
using DalContracts;
using Entities;
using Epam.Library.SqlDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.Library.SqlDalTests
{
    [TestClass]
    public class AuthorDaoTests
    {
        private IAuthorDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new AuthorDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        public void GetByIdReturnsCorrectAuthorById()
        {
            var result = this.dao.GetAuthorById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddThrowsArgumentNullExceptionIfAuthorIsNull()
        {
            this.dao.Add(null);
        }

        [TestMethod]
        public void AddsCorrectlyNewAuthor()
        {
            var author = new Author()
            {
                FirstName = "Иван",
                LastName = "Иванов",
            };
            int result = this.dao.Add(author);

            var gotAuthor = this.dao.GetAuthorById(result);
            Assert.IsTrue(gotAuthor.FirstName == author.FirstName);
            Assert.IsTrue(gotAuthor.LastName == author.LastName);
        }
    }
}
