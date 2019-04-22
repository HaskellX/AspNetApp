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
    public class BookDaoTests
    {
        private IBookDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new BookDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        public void GetByIdReturnsCorrectBookById()
        {
            var result = this.dao.GetItemById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 1);
        }

        [TestMethod]
        public void RemovesCorrectly()
        {
            Assert.IsTrue(this.dao.RemoveItem(1));
        }

        [TestMethod]
        public void ThereIsNothingLeftInDBAfterRemoving()
        {
            int id = 1;
            this.dao.RemoveItem(id);
            Assert.IsTrue(this.dao.GetItemById(id) == null);
        }

        [TestMethod]
        public void GetsCorrectEntityAfterExtracting()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                    new[]
                    {
                        new Author()
                        {
                            Id = 7,
                            FirstName = "Herman",
                            LastName = "Melvill"
                        }
                    }),
                CityOfPublishing = "New-York",
                Id = 2,
                ISBN = "ISBN 22222-22222",
                Name = "Moby Dick",
                Note = "note",
                NumberOfPages = 500,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            var result = this.dao.GetItemById(2);
            Assert.IsTrue(book.Equals(result));
        }

        [TestMethod]
        public void GetsFalseWhenEntitiesAreNotEqual()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                       new[]
                        {
                                new Author()
                                {
                                    Id = 7,
                                    FirstName = "Herman",
                                    LastName = "Melvill"
                                },
                                new Author()
                                {
                                    Id = 2,
                                    FirstName = "Alexandr",
                                    LastName = "Pushkin"
                                }
                        }),
                CityOfPublishing = "New-York",
                Id = 2,
                ISBN = "xxx",
                Name = "Moby Dick",
                Note = "note",
                NumberOfPages = 500,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            var result = this.dao.GetItemById(2);
            Assert.IsFalse(book.Equals(result));
        }

        [TestMethod]
        public void AddsCorrectlyNewBook()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                    new[]
                    {
                        new Author()
                        {
                            Id = 3,
                            FirstName = "Михаил",
                            LastName = "Лермонтов"
                        }
                    }),
                CityOfPublishing = "Москва",
                ISBN = "ISBN 88848-84751",
                Name = "Мцыри",
                Note = string.Empty,
                NumberOfPages = 50,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            int resultId = this.dao.AddItem(book);
            var gotEntity = this.dao.GetItemById(resultId);
            Assert.IsTrue(book.Equals(gotEntity));
        }

        [TestMethod]
        public void CorrectExists()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                        new[]
                        {
                                new Author()
                                {
                                    Id = 7,
                                    FirstName = "Herman",
                                    LastName = "Melvill"
                                },
                                new Author()
                                {
                                    Id = 2,
                                    FirstName = "Alexandr",
                                    LastName = "Pushkin"
                                }
                        }),
                CityOfPublishing = "New-York",
                Id = 2,
                ISBN = "ISBN 22222-22222",
                Name = "Moby Dick",
                Note = "note",
                NumberOfPages = 500,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            Assert.IsTrue(this.dao.Exists(book));
        }

        [TestMethod]
        public void ExistsInDatabaseAfterAdding()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                    new[]
                    {
                        new Author()
                        {
                            Id = 3,
                            FirstName = "Михаил",
                            LastName = "Лермонтов"
                        }
                    }),
                CityOfPublishing = "Москва",
                ISBN = "ISBN 88848-84751",
                Name = "Мцыри",
                Note = string.Empty,
                NumberOfPages = 50,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            this.dao.AddItem(book);
            Assert.IsTrue(this.dao.Exists(book));
        }

        [TestMethod]
        public void GetsCorrectResultAfterGetAll()
        {
            HashSet<Book> list = new HashSet<Book>(
                   new[]
                   {
                        new Book()
                        {
                            Authors = new HashSet<Author>(
                                    new[]
                                    {
                                            new Author()
                                            {
                                                Id = 7,
                                                FirstName = "Herman",
                                                LastName = "Melvill"
                                            },
                                            new Author()
                                            {
                                                Id = 2,
                                                FirstName = "Alexandr",
                                                LastName = "Pushkin"
                                            }
                                    }),
                            CityOfPublishing = "New-York",
                            Id = 2,
                            ISBN = "ISBN 22222-22222",
                            Name = "Moby Dick",
                            Note = "note",
                            NumberOfPages = 500,
                            Publisher = new Publisher()
                            {
                                Id = 4,
                                PublisherName = "US books"
                            },
                            YearOfPublishing = 2009
                        },
                        new Book()
                        {
                            Authors = new HashSet<Author>(
                                new[]
                                {
                                    new Author()
                                    {
                                        Id = 1,
                                        FirstName = "Алексей",
                                        LastName = "Толстой"
                                    }
                                }),
                            Id = 1,
                            CityOfPublishing = "Саратов",
                            ISBN = "ISBN 11111-11111",
                            Name = "Война и Мир",
                            Note = string.Empty,
                            NumberOfPages = 1500,
                            Publisher = new Publisher()
                            {
                                Id = 1,
                                PublisherName = "URSS"
                            },
                            YearOfPublishing = 2008
                        },
                        new Book()
                        {
                            Authors = new HashSet<Author>(
                                new[]
                                {
                                    new Author()
                                    {
                                        Id = 2,
                                        FirstName = "Alexandr",
                                        LastName = "Pushkin"
                                    }
                                }),
                            Id = 3,
                            CityOfPublishing = "Moscow",
                            Name = "Капитанская дочка",
                            Note = "xxx",
                            NumberOfPages = 200,
                            Publisher = new Publisher()
                            {
                                Id = 2,
                                PublisherName = "Свобода"
                            },
                            YearOfPublishing = 2010
                        },
                   });

            var resultSet = new HashSet<Book>(this.dao.GetAllItems());
            Assert.IsTrue(resultSet.SetEquals(list));
        }

        [TestMethod]
        public void GetsCorrectAuthorsAfterAddingAndExtracting()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                    new[]
                    {
                        new Author()
                        {
                            Id = 3,
                            FirstName = "Михаил",
                            LastName = "Лермонтов"
                        }
                    }),
                CityOfPublishing = "Москва",
                ISBN = "ISBN 88848-84751",
                Name = "Мцыри",
                Note = string.Empty,
                NumberOfPages = 50,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            int addedId = this.dao.AddItem(book);
            var result = this.dao.GetItemById(addedId);
            Assert.IsTrue(book.Authors.SetEquals(result.Authors));
        }

        [TestMethod]
        public void GetsCorrectAuthorsAfterExtracting()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                        new[]
                        {
                                new Author()
                                {
                                    Id = 7,
                                    FirstName = "Herman",
                                    LastName = "Melvill"
                                },
                                new Author()
                                {
                                    Id = 2,
                                    FirstName = "Alexandr",
                                    LastName = "Pushkin"
                                }
                        }),
                CityOfPublishing = "New-York",
                Id = 2,
                ISBN = "ISBN 22222-22222",
                Name = "Moby Dick",
                Note = "note",
                NumberOfPages = 500,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            var result = this.dao.GetItemById(2);
            Assert.IsTrue(result.Authors.SetEquals(book.Authors));
        }

        [TestMethod]
        public void ReturnCorrectResultWhenEntryAlreadyExists()
        {
            Book book = new Book()
            {
                Authors = new HashSet<Author>(
                        new[]
                        {
                                new Author()
                                {
                                    Id = 7,
                                    FirstName = "Herman",
                                    LastName = "Melvill"
                                },
                                new Author()
                                {
                                    Id = 2,
                                    FirstName = "Alexandr",
                                    LastName = "Pushkin"
                                }
                        }),
                CityOfPublishing = "New-York",
                ISBN = "ISBN 22222-22222",
                Name = "Moby Dick",
                Note = "note",
                NumberOfPages = 500,
                Publisher = new Publisher()
                {
                    Id = 4,
                    PublisherName = "US books"
                },
                YearOfPublishing = 2009
            };

            Assert.IsTrue(this.dao.AddItem(book) == -1);
        }
    }
}
