using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BlContracts;
using Entities;

namespace BusinessLogicLayer.Validator
{
    public  class PatentValidator : IPatentValidator
    {
        public bool IsValidAuthor(HashSet<Author> authors)
        {
            if (authors == null)
            {
                return false;
            }

            return authors.Count > 0;
        }

        public bool IsValidCountry(string country)
        {
            if (country == null)
            {
                return false;
            }

            if (country.Length > 200)
            {
                return false;
            }

            var countryPattern = "(?:(^[A-Z][a-z]+$)|(^[A-Z]+$))|(?:(^[А-ЯЁ][а-яё]+$)|([А-ЯЁ]+$))";
            Regex regexCountry = new Regex(countryPattern);
            return regexCountry.IsMatch(country);
        }

        public bool AreValidDates(DateTime date, DateTime dateOfSubmission)
        {
            if (dateOfSubmission == null)
            {
                if (date == null)
                {
                    return false;
                }

                return (date.Year >= 1474) & (date <= DateTime.Now);
            }
            else
            {
                if (date == null)
                {
                    return false;
                }

                return (date.Year >= 1474) && (date <= DateTime.Now) && (date >= dateOfSubmission) && dateOfSubmission.Year >= 1474;
            }
        }

        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return name.Length <= 300;
        }

        public bool IsValidNote(string note)
        {
            if (note == null)
            {
                return false;
            }

            return !(note.Length > 2000);
        }

        public bool IsValidNumberOfPages(int number)
        {
            return number >= 0;
        }

        public bool IsValidRegNumber(string regNumber)
        {
            if (regNumber == null)
            {
                return false;
            }

            var regPattern = @"^(?:[0-9]){1,10}$";
            Regex regexRegNumber = new Regex(regPattern);
            return regexRegNumber.IsMatch(regNumber);
        }
    }
}