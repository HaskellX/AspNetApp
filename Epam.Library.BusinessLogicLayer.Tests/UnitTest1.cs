using BusinessLogicLayer.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicLayer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsInValidCityForBookTest()
        {
            BookValidator vld = new BookValidator();

            string city = null;

            Assert.AreEqual(false, vld.IsValidCity(city));
        }

        [TestMethod]
        public void IsValidCityForBookTest()
        {
            BookValidator vld = new BookValidator();

            string city = "Саратов";

            Assert.AreEqual(true, vld.IsValidCity(city));
        }

        [TestMethod]
        public void GetFalseWhenPublishersNameIsNull()
        {
            PublisherValidator vld = new PublisherValidator();

            string publisherName = null;
            Assert.AreEqual(false, vld.IsValidName(publisherName));
        }

        [TestMethod]
        public void GetFalseWhenPublishersNameIsLongerThanNeeded()
        {
            PublisherValidator vld = new PublisherValidator();
            string longName = new string('x', 301);

            Assert.AreEqual(false, vld.IsValidName(longName));
        }

        public void GetTrueWhenPublishersNameIsCorrect()
        {
            PublisherValidator vld = new PublisherValidator();
            string correctPublisherName = "Аргументы и факты";
            Assert.AreEqual(true, vld.IsValidName(correctPublisherName));
        }
    }
}