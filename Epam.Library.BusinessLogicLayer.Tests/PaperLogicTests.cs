using System;
using System.Collections.Generic;
using System.Linq;
using BL_Contracts.Validator;
using BlContracts.Logic;
using Business_Logic_Layer.Logic;
using DalContracts;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicLayer.Tests
{
    [TestClass]
    public class PaperLogicTests
    {
        private IPaperIssueLogic logic;
        private Mock<IPaperIssueDAO> dao;
        private Mock<IPaperIssueValidator> validator;

        [TestInitialize]
        public void Initialize()
        {
            this.dao = new Mock<IPaperIssueDAO>();
            this.validator = new Mock<IPaperIssueValidator>();
            this.logic = new PaperIssueLogic(this.dao.Object, this.validator.Object);
        }

        [TestMethod]
        public void WorksCorrectlyWhenPaperWasAdded()
        {
            this.dao.Setup(x => x.AddItem(It.IsAny<PaperIssue>())).Returns(89);

            Assert.IsTrue(this.logic.Add(
                new Paper()
                {
                    Issn = "ISSN 1111-1111",
                    Name = "Аргументы и факты", 
                },                
                "Саратов",
                 new Publisher()
                 {
                     Id = 1,
                     PublisherName = "Правда",
                 },
                 2011,
                 200,
                 "Some note",
                 1,
                 new DateTime(2010, 01, 01)) == 89);
        }

        [TestMethod]
        public void RemoveReturnsTrueIfRemovalWasSuccessful()
        {
            this.dao.Setup(x => x.RemoveItem(It.IsAny<int>())).Returns(true);

            int existingId = 0;

            var result = this.logic.Delete(existingId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCorrectResultWhenGetAllPapers()
        {
            var paper = new PaperIssue()
            {
                CityOfPublishing = "Саратов",
                DateOfIssue = new DateTime(2010, 01, 01),
                Paper = new Paper
                {
                    Issn = "ISSN 1111-1111",
                    Name = "Аргументы и факты",
                },
                Id = 1,
                IssueNumber = 1,
                Note = "Some note",
                NumberOfPages = 200,
                Publisher = new Publisher()
                {
                    Id = 1,
                    PublisherName = "Правда",
                },
                YearOfPublishing = 2011,
            };

            this.dao.Setup(x => x.GetAllItems()).Returns(new List<PaperIssue>()
            {
                new PaperIssue
                {
                    CityOfPublishing = "Саратов",
                    DateOfIssue = new DateTime(2010, 01, 01),
                    Paper = new Paper
                    {
                        Issn = "ISSN 1111-1111",
                        Name = "Аргументы и факты",
                    },
                    Id = 1,
                    IssueNumber = 1,
                    Note = "Some note",
                    NumberOfPages = 200,
                    Publisher = new Publisher()
                    {
                        Id = 1,
                        PublisherName = "Правда",
                    },
                    YearOfPublishing = 2011,
                    }
            });

            var result = this.logic.GetAll();

            Assert.IsTrue(result.Contains(paper));
        }

        [TestMethod]
        public void GetCorrectResultGettingById()
        {
            var paper = new PaperIssue()
            {
                CityOfPublishing = "Саратов",
                DateOfIssue = new DateTime(2010, 01, 01),
                Paper = new Paper
                {
                    Issn = "ISSN 1111-1111",
                    Name = "Аргументы и факты",
                },
                Id = 1,
                IssueNumber = 1,
                Note = "Some note",
                NumberOfPages = 200,
                Publisher = new Publisher()
                {
                    Id = 1,
                    PublisherName = "Правда",
                },
                YearOfPublishing = 2011,
            };

            this.dao.Setup(x => x.GetItemById(It.IsAny<int>())).Returns(paper);
            Assert.IsTrue(paper.Equals(this.logic.GetById(88)));
        }
    }
}