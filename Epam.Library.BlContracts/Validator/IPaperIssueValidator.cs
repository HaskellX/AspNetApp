using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BL_Contracts.Validator
{
    public interface IPaperIssueValidator
    {
        bool IsValidPaper(Paper paper);

        bool IsValidCityOfPublishing(string city);

        bool IsValidPublisher(Publisher publisher);

        bool IsValidIssueNumber(int issueNumber);

        bool AreValidDates(DateTime dateOfIssue, int year);

        bool IsValidNumberPages(int pages);

        bool IsValidNote(string note);
    }
}
