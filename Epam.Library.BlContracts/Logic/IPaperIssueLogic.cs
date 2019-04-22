using System;
using System.Collections.Generic;
using Entities;

namespace BlContracts.Logic
{
    public interface IPaperIssueLogic
    {
        int Add(Paper paper, string cityOfPublishing, Publisher publisher, int yearOfPublishing, int numberOfPages, string note, int issueNumber, DateTime dateOfIssue);

        bool Update(int id, Paper paper, string cityOfPublishing, Publisher publisher, int yearOfPublishing, int numberOfPages, string note, int issueNumber, DateTime dateOfIssue);

        IEnumerable<PaperIssue> GetPaperIssuesByPaperId(int id);

        bool Delete(int id);

        PaperIssue GetById(int id);

        IEnumerable<PaperIssue> GetAll();
    }
}