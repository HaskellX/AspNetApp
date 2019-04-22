using System;
using System.Collections.Generic;
using System.IO;
using DalContracts;
using Entities;
using Epam.Library.SqlDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.Library.SqlDalTests
{
    [TestClass]
    public class PaperIssueTests
    {
        private IPaperIssueDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new PaperIssueDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        public void GetByIdReturnsCorrectEntity()
        {
            var result = this.dao.GetItemById(4);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 4);
        }

        [TestMethod]
        public void RemovesCorrectly()
        {
            Assert.IsTrue(this.dao.RemoveItem(5));
        }

        [TestMethod]
        public void GetCorrectPaperIssuesAfterGettingAll()
        {
            HashSet<PaperIssue> set = new HashSet<PaperIssue>()
            {
                        new PaperIssue()
                        {
                            CityOfPublishing = "New-York",
                            Id = 4,
                            IssueNumber = 23,
                            Note = "Some note",
                            NumberOfPages = 100,
                            Publisher = new Publisher()
                            {
                                Id = 1,
                                PublisherName = "URSS"
                            },
                            DateOfIssue = new DateTime(2010, 10, 10),
                            Paper = new Paper
                            {
                                Issn = "ISSN 4444-4444",
                                Name = "New-York Times"
                            },
                            YearOfPublishing = 2010,
                        },
                        new PaperIssue()
                        {
                            CityOfPublishing = "Washington",
                            DateOfIssue = new DateTime(1910, 02, 03),
                            Id = 5,
                            IssueNumber = 1,
                            Note = "bbb",
                            NumberOfPages = 20,
                            Paper = new Paper()
                            {
                                Name = "Washington Post"
                            },
                            Publisher = new Publisher()
                            {
                                Id = 5,
                                PublisherName = "Fairwood Press"
                            },
                            YearOfPublishing = 1910,
                        },
                        new PaperIssue()
                        {
                            CityOfPublishing = "New-York",
                            DateOfIssue = new DateTime(1910, 01, 01),
                            Id = 6,
                            IssueNumber = 2,
                            Note = "xxx",
                            NumberOfPages = 22,
                            Paper = new Paper()
                            {
                                Id = 3,
                                Issn = "ISSN 1111-1111",
                                Name = "Wall-Street Journal"
                            },
                            Publisher = new Publisher()
                            {
                                Id = 5,
                                PublisherName = "Fairwood Press"
                            },
                            YearOfPublishing = 1910,
                        },
            };

            var allDbPaperIssues = new HashSet<PaperIssue>(this.dao.GetAllItems());
            Assert.IsTrue(allDbPaperIssues.SetEquals(set));
        }

        [TestMethod]
        public void GetByIdReturnsCorrectPaperIssue()
        {
            PaperIssue pi = new PaperIssue()
            {
                CityOfPublishing = "New-York",
                DateOfIssue = new DateTime(1910, 01, 01),
                Id = 6,
                IssueNumber = 2,
                Note = "xxx",
                NumberOfPages = 22,
                Paper = new Paper()
                {
                    Id = 3,
                    Issn = "ISSN 1111-1111",
                    Name = "Wall-Street Journal"
                },
                Publisher = new Publisher()
                {
                    Id = 5,
                    PublisherName = "Fairwood Press"
                },
                YearOfPublishing = 1910,
            };

            var result = this.dao.GetItemById(6);
            Assert.IsTrue(result.Equals(pi));
        }

        [TestMethod]
        public void AddNewPaperIssueWorksCorrectly()
        {
            PaperIssue pi = new PaperIssue()
            {
                CityOfPublishing = "Mexico",
                DateOfIssue = new DateTime(1940, 02, 02),
                Id = 10,
                IssueNumber = 788,
                Note = "The most read mexican newspaper!",
                Paper = new Paper()
                {
                    Id = 3,
                    Issn = "ISSN 1111-1111",
                    Name = "Wall-Street Journal"
                },
                Publisher = new Publisher()
                {
                    Id = 5,
                    PublisherName = "Fairwood Press"
                },
                NumberOfPages = 50,
                YearOfPublishing = 1940
            };
            int result = this.dao.AddItem(pi);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetByIdExtractAddedEntityCorrectly()
        {
            PaperIssue pi = new PaperIssue()
            {
                CityOfPublishing = "Mexico",
                DateOfIssue = new DateTime(1940, 02, 02),
                Id = 10,
                IssueNumber = 788,
                Note = "The most read mexican newspaper!",
                Paper = new Paper()
                {
                    Id = 3,
                    Issn = "ISSN 1111-1111",
                    Name = "Wall-Street Journal"
                },
                Publisher = new Publisher()
                {
                    Id = 5,
                    PublisherName = "Fairwood Press"
                },
                NumberOfPages = 50,
                YearOfPublishing = 1940
            };
            int result = this.dao.AddItem(pi);
            var item = this.dao.GetItemById(result);
            Assert.IsTrue(item.Equals(pi));
        }

        [TestMethod]
        public void PaperIssueExistsWorksProperly()
        {
            PaperIssue pi = new PaperIssue()
            {
                CityOfPublishing = "New-York",
                DateOfIssue = new DateTime(1910, 01, 01),
                Id = 6,
                IssueNumber = 2,
                Note = "xxx",
                NumberOfPages = 22,
                Paper = new Paper()
                {
                    Id = 3,
                    Issn = "ISSN 1111-1111",
                    Name = "Wall-Street Journal"
                },
                Publisher = new Publisher()
                {
                    Id = 5,
                    PublisherName = "Fairwood Press"
                },
                YearOfPublishing = 1910,
            };

            Assert.IsTrue(this.dao.Exists(pi));
        }

        [TestMethod]
        public void PaperIssueExistsInDatabaseAfterAdding()
        {
            PaperIssue pi = new PaperIssue()
            {
                CityOfPublishing = "Mexico",
                DateOfIssue = new DateTime(1940, 02, 02),
                Id = 10,
                IssueNumber = 788,
                Note = "The most read mexican newspaper!",
                Paper = new Paper()
                {
                    Id = 3,
                    Issn = "ISSN 1111-1111",
                    Name = "Wall-Street Journal"
                },
                Publisher = new Publisher()
                {
                    Id = 5,
                    PublisherName = "Fairwood Press"
                },
                NumberOfPages = 50,
                YearOfPublishing = 1940
            };

            this.dao.AddItem(pi);
            Assert.IsTrue(this.dao.Exists(pi));
        }

        [TestMethod]
        public void GetCorrectResultWhenPaperIssueAlreadyExists()
        {
            PaperIssue pi = new PaperIssue()
            {
                CityOfPublishing = "New-York",
                DateOfIssue = new DateTime(1910, 01, 01),
                Id = 6,
                IssueNumber = 2,
                Note = "xxx",
                NumberOfPages = 22,
                Paper = new Paper()
                {
                    Id = 3,
                    Issn = "ISSN 1111-1111",
                    Name = "Wall-Street Journal"
                },
                Publisher = new Publisher()
                {
                    Id = 5,
                    PublisherName = "Fairwood Press"
                },
                YearOfPublishing = 1910,
            };
            int i = this.dao.AddItem(pi);
            Assert.IsTrue(-1 == i);
        }
    }
}
