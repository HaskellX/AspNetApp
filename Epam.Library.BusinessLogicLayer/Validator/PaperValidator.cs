using System;
using System.Text.RegularExpressions;
using BlContracts;
using Entities;

namespace BusinessLogicLayer.Validator
{
    public class PaperValidator : IPaperValidator
    {
        public bool IsValidISSN(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return true;
            }
            else
            {
                return Regex.IsMatch(inputString, @"(^ISSN (?:[0-9]{4}-[0-9]{4}$)");
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
    }
}