using System;
using System.IO;
using DalContracts;
using Entities;
using Epam.Library.SqlDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.Library.SqlDalTests
{
    [TestClass]
    public class PaperDaoTests
    {
        private IPaperDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new PaperDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        public void GetCoGetByIdReturnsCorrectPaperByIdrrect()
        {
            var result = this.dao.GetById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorksProperlyIfPaperIsNull()
        {
            this.dao.Add(null);
        }

        [TestMethod]
        public void AddNewPaperWorksProperly()
        {
            Paper paper = new Paper()
            {
                Issn = "ISSN 7743-9873",
                Name = "Sunday News",
            };
            var addedId = this.dao.Add(paper);
            var result = this.dao.GetById(addedId);
            Assert.IsTrue(paper.Issn == result.Issn && paper.Name == result.Name);
        }
    }
}
