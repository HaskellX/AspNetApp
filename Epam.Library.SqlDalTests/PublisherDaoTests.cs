using System;
using System.IO;
using DalContracts;
using Entities;
using Epam.Library.SqlDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.Library.SqlDalTests
{
    [TestClass]
    public class PublisherDaoTests
    {
        private IPublisherDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new PublisherDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddThrowsArgumentNullExceptionIfPublisherIsNull()
        {
            this.dao.AddPublisher(null);
        }

        [TestMethod]
        public void GetByIdReturnsCorrectPublisher()
        {
            var result = this.dao.GetPublisherById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 1);
        }

        [TestMethod]
        public void AddCorrectlyNewPublisher()
        {
            var newPublisher = new Publisher()
            {
                PublisherName = "Желтая пресса",
            };
            int newId = this.dao.AddPublisher(newPublisher);
            var result = this.dao.GetPublisherById(newId);
            Assert.IsTrue(newPublisher.PublisherName == result.PublisherName);
        }
    }
}
