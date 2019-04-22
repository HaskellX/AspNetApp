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
    public class CommonDaoTests
    {
        private ICommonDAO dao;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new CommonDAO();
            string initializer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "initialize.sql");
            string cleaner = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cleanup.sql");
            Common.Cleanup(cleaner);
            Common.Initialazation(initializer);
        }

        [TestMethod]
        public void ReturnCorrectResultAfterGettingAll()
        {
            HashSet<LibraryItem> set = new HashSet<LibraryItem>(
                new LibraryItem[]
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
                });

            HashSet<LibraryItem> resultSet = new HashSet<LibraryItem>(this.dao.GetAllLibraryItems());
            Assert.IsTrue(resultSet.SetEquals(set));
        }
    }
}