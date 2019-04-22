using BlContracts.Validator;

namespace BusinessLogicLayer.Validator
{
    public class PublisherValidator : IPublisherValidator
    {
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