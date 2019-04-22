using System.Text.RegularExpressions;
using BlContracts.Validator;

namespace BusinessLogicLayer.Validator
{
    public class AuthorValidator : IAuthorValidator
    {
        public bool IsValidFirstName(string name)
        {
            if (name == null)
            {
                return false;
            }

            return Regex.IsMatch(name, @"((^([A-Z][a-z]*(-[A-Z])?[a-z]*)$)|(^([А-Я][а-я]*(-[А-Я])?[а-я]*)$))");
        }

        public bool IsValidLastName(string name)
        {
            if (name == null)
            {
                return false;
            }

            return Regex.IsMatch(name, @"^(?=[-'A-Za-z ]*$|[-'А-ЯЁа-яё ]*$)(?=[A-ZА-ЯЁ][^ ]*$|[a-zа-яё]+ )(?=([^- ']|[- ']A-ZА-ЯЁ)*$)(?!.*[- ']$).{1,200}$");
        }
    }
}