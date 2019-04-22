using System;
using System.Collections.Generic;
using Entities;

namespace BlContracts
{
    public interface IPatentValidator
    {
        bool IsValidAuthor(HashSet<Author> authors);

        bool IsValidCountry(string country);

        bool AreValidDates(DateTime date, DateTime dateOfSubmission);

        bool IsValidName(string name);

        bool IsValidNumberOfPages(int number);

        bool IsValidNote(string note);

        bool IsValidRegNumber(string regNumber);
    }
}