using System;
using BlContracts.Logic;
using BlContracts.Validator;
using BusinessLogicLayer.Logic;
using DalContracts;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace BusinessLogicLayer.Tests
{
    public class AuthorUnitTest
    {
        private Mock<IAuthorDAO> dao;
        private Mock<IAuthorValidator> validator;
        private IAuthorLogic authorLogic;

        public AuthorUnitTest()
        {
            this.dao = new Mock<IAuthorDAO>();
            this.validator = new Mock<IAuthorValidator>();
            this.authorLogic = new AuthorLogic(this.dao.Object, this.validator.Object);
        }

        [Theory]
        [InlineData("Jonh")]
        [InlineData("Mary-Jane")]
        [InlineData("d'Artanjan")]
        public void AuthorNamePositiveTest(string name, string lastName)
        {
            Author author = new Author();
            author.FirstName = name;

            this.authorLogic.Add(author);
        }

        [Theory]
        [InlineData("JOHN")]
        [ExpectedException(typeof(ArgumentException))]
        public void AuthorNameNegativeTest(string name)
        {
            Author author = new Author();
            author.FirstName = name;

            this.authorLogic.Add(author);
        }
    }
}