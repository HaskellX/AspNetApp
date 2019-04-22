namespace BlContracts.Validator
{
    public interface IAuthorValidator
    {
        bool IsValidFirstName(string name);

        bool IsValidLastName(string name);
    }
}