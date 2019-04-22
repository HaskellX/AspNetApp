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
    public class PatentDaoTests
    {
        private IPatentDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new PatentDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        public void GetByIdReturnsCorrectPatent()
        {
            var result = this.dao.GetItemById(7);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 7);
        }

        [TestMethod]
        public void RemovesCorrectly()
        {
            Assert.IsTrue(this.dao.RemoveItem(1));
        }

        [TestMethod]
        public void ReturnCorrectEntityAfterGettingById()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                }
                            },
                Country = "USA",
                DateOfPublication = new DateTime(1910, 01, 09),
                Id = 7,
                Name = "Лампочка",
                Note = "Note",
                NumberOfPages = 300,
                RegNumber = "1",
                SubmissionDocuments = new DateTime(1907, 02, 02),
                YearOfPublishing = 1910
            };
            var result = this.dao.GetItemById(7);
            Assert.IsTrue(result.Equals(patent));
        }

        public void AddNewPatentWorksCorrectly()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                },
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                }
                            },
                Country = "Canada",
                DateOfPublication = new DateTime(1930, 05, 05),
                Name = "Переменный ток",
                Note = "Note",
                NumberOfPages = 30000,
                RegNumber = "1548",
                SubmissionDocuments = new DateTime(1925, 08, 01),
                YearOfPublishing = 1930
            };

            int addedId = this.dao.AddItem(patent);
            var result = this.dao.GetItemById(addedId);
            Assert.IsTrue(patent.Equals(result));
        }

        [TestMethod]
        public void PatentExistsWorksProperly()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                }
                            },
                Country = "USA",
                DateOfPublication = new DateTime(1910, 01, 09),
                Id = 7,
                Name = "Лампочка",
                Note = "Note",
                NumberOfPages = 300,
                RegNumber = "1",
                SubmissionDocuments = new DateTime(1907, 02, 02),
                YearOfPublishing = 1910
            };

            Assert.IsTrue(this.dao.Exists(patent));
        }

        [TestMethod]
        public void ExistsInDatabaseAfterAdding()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                },
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                }
                            },
                Country = "Canada",
                DateOfPublication = new DateTime(1930, 05, 05),
                Name = "Переменный ток",
                Note = "Note",
                NumberOfPages = 30000,
                RegNumber = "1548",
                SubmissionDocuments = new DateTime(1925, 08, 01),
                YearOfPublishing = 1930
            };

            this.dao.AddItem(patent);
            Assert.IsTrue(patent.Equals(patent));
        }

        [TestMethod]
        public void GetCorrectEntitiesAfterGettingAll()
        {
            var set = new HashSet<Patent>()
            {
                        new Patent()
                        {
                            Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                }
                            },
                            Country = "USA",
                            DateOfPublication = new DateTime(1910, 01, 09),
                            Id = 7,
                            Name = "Лампочка",
                            Note = "Note",
                            NumberOfPages = 300,
                            RegNumber = "1",
                            SubmissionDocuments = new DateTime(1907, 02, 02),
                            YearOfPublishing = 1910
                        },
                        new Patent()
                        {
                            Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                }
                            },
                            Country = "USA",
                            DateOfPublication = new DateTime(1940, 08, 08),
                            Id = 8,
                            Name = "Вечный двигатель",
                            Note = "some note",
                            NumberOfPages = 322,
                            RegNumber = "200",
                            SubmissionDocuments = new DateTime(1939, 05, 05),
                            YearOfPublishing = 1940,
                        },
                        new Patent()
                        {
                            Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                },
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                },
                            },
                            Country = "USA",
                            DateOfPublication = new DateTime(1920, 02, 02),
                            Id = 9,
                            Name = "Башня Уордклифф",
                            Note = "Note",
                            NumberOfPages = 1500,
                            RegNumber = "500",
                            SubmissionDocuments = new DateTime(1919, 03, 03),
                            YearOfPublishing = 1920,
                        },
            };
            var result = new HashSet<Patent>(this.dao.GetAllItems());
            Assert.IsTrue(result.SetEquals(set));
        }

        [TestMethod]
        public void GetsCorrectAuthorsAfterAddingAndExtracting()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Tomas",
                                    Id = 5,
                                    LastName = "Edison"
                                },
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                }
                            },
                Country = "Canada",
                DateOfPublication = new DateTime(1930, 05, 05),
                Name = "Переменный ток",
                Note = "Note",
                NumberOfPages = 30000,
                RegNumber = "1548",
                SubmissionDocuments = new DateTime(1925, 08, 01),
                YearOfPublishing = 1930
            };
            int addedId = this.dao.AddItem(patent);
            var result = this.dao.GetItemById(addedId);
            Assert.IsTrue(patent.Authors.SetEquals(result.Authors));
        }

        [TestMethod]
        public void ReturnCorrectAuthorsAfterExtracting()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                }
                            },
                Country = "USA",
                DateOfPublication = new DateTime(1940, 08, 08),
                Id = 8,
                Name = "Вечный двигатель",
                Note = "some note",
                NumberOfPages = 322,
                RegNumber = "200",
                SubmissionDocuments = new DateTime(1939, 05, 05),
                YearOfPublishing = 1940,
            };

            var result = this.dao.GetItemById(8);
            Assert.IsTrue(patent.Authors.SetEquals(result.Authors));
        }

        [TestMethod]
        public void ReturnsCorrectValueWhenTupleAlreadyExists()
        {
            Patent patent = new Patent()
            {
                Authors = new HashSet<Author>()
                            {
                                new Author()
                                {
                                    FirstName = "Nikola",
                                    Id = 4,
                                    LastName = "Tesla"
                                }
                            },
                Country = "USA",
                DateOfPublication = new DateTime(1940, 08, 08),
                Id = 8,
                Name = "Вечный двигатель",
                Note = "some note",
                NumberOfPages = 322,
                RegNumber = "200",
                SubmissionDocuments = new DateTime(1939, 05, 05),
                YearOfPublishing = 1940,
            };

            Assert.IsTrue(this.dao.AddItem(patent) == -1);
        }
    }
}
