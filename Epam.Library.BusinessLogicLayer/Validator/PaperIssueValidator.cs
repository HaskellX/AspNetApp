using System;
using System.Text.RegularExpressions;
using BL_Contracts.Validator;
using Entities;

namespace Business_Logic_Layer.Validator
{
    public class PaperIssueValidator : IPaperIssueValidator
    {
        public bool IsValidCityOfPublishing(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return false;
            }

            return Regex.IsMatch(city, @"(^[A-Z][a-z]+(((-[a-z]+-[A-Z][a-z]*)?)|(-[A-Z][a-z]*))(\s(([A-Z])|([a-z]))[a-z]*)*$)|(^[А-ЯЁ][а-яё]+(((-[а-яё]+-[А-ЯЁ][а-яё]*)?)|(-[А-ЯЁ][а-яё]*))(\s(([А-ЯЁ])|([а-яё]))[а-яё]*)*$)");
        }

        public bool AreValidDates(DateTime dateOfIssue, int year)
        {
            if (dateOfIssue == null)
            {
                return false;
            }

            return year >= 1400 & year <= DateTime.Now.Year & year == dateOfIssue.Year;
        }

        public bool IsValidIssueNumber(int issueNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsValidNote(string note)
        {
            if (note == null)
            {
                return false;
            }

            return !(note.Length > 2000);
        }

        public bool IsValidNumberPages(int pages)
        {
            return pages > 0;
        }

        public bool IsValidPublisher(Publisher publisher)
        {
            return publisher != null;
        }

        public bool IsValidPaper(Paper paper)
        {
            return paper != null;
        }
    }
}
