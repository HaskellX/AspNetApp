using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BlContracts;
using Entities;

namespace BusinessLogicLayer.Validator
{
    public class BookValidator : IBookValidator
    {
        public bool IsValidAuthor(HashSet<Author> authors)
        {
            if (authors == null)
            {
                return false;
            }

            return authors.Count > 0;
        }

        public bool IsValidCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return false;
            }

            return Regex.IsMatch(city, @"(^[A-Z][a-z]+(((-[a-z]+-[A-Z][a-z]*)?)|(-[A-Z][a-z]*))(\s(([A-Z])|([a-z]))[a-z]*)*$)|(^[А-ЯЁ][а-яё]+(((-[а-яё]+-[А-ЯЁ][а-яё]*)?)|(-[А-ЯЁ][а-яё]*))(\s(([А-ЯЁ])|([а-яё]))[а-яё]*)*$)");
        }

        public bool IsValidISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                return true;
            }
            else
            {
                return Regex.IsMatch(isbn, @"^ISBN(-1(?:0))?:?\x20(?=.{13}$)(?:[0-7]|8[0-9]|9[0-4]|9(?:[5-8][0-9]|9[0-3])|99[4-8][0-9]|999[0-9][0-9])-\d{1,7}-\d{1,7}-[\dX]$");
            }
        }

        public bool IsValidNote(string note)
        {
            if (note == null)
            {
                return false;
            }

            return !(note.Length > 2000);
        }

        public bool IsValidNumberOfPages(int pages)
        {
            return pages >= 0;
        }

        public bool IsValidPublisher(Publisher publisher)
        {
            return publisher != null;
        }

        public bool IsValidTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return false;
            }

            return title.Length <= 300;
        }

        public bool IsValidYearOfPublishing(int year)
        {
            return year >= 1400 & year <= DateTime.Now.Year;
        }
    }
}