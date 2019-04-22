using BL_Contracts.Validator;
using BlContracts;
using BlContracts.Validator;
using Business_Logic_Layer.Validator;
using BusinessLogicLayer.Validator;

namespace BusinessLogicLayer
{
    internal static class Validators
    {
        static Validators()
        {
            AuthorValidator = new AuthorValidator();
            BookValidator = new BookValidator();
            PublisherValidator = new PublisherValidator();
            PaperValidator = new PaperValidator();
            PatentValidator = new PatentValidator();
            PaperIssueValidator = new PaperIssueValidator();
        }

        internal static IPaperIssueValidator PaperIssueValidator { get; set; }

        internal static IAuthorValidator AuthorValidator { get; set; }

        internal static IBookValidator BookValidator { get; set; }

        internal static IPublisherValidator PublisherValidator { get; set; }

        internal static IPaperValidator PaperValidator { get; set; }

        internal static IPatentValidator PatentValidator { get; set; }
    }
}