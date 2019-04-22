using System.Collections.Generic;
using Entities;

namespace DalContracts
{
    public interface IPaperIssueDAO
    {
        bool RemoveItem(int id);

        PaperIssue GetItemById(int id);

        IEnumerable<PaperIssue> GetAllItems();

        int AddItem(PaperIssue paper);

        bool Update(PaperIssue paper);

        bool Exists(PaperIssue paper);

        IEnumerable<PaperIssue> GetPaperIssuesByPaperId(int id);
    }
}