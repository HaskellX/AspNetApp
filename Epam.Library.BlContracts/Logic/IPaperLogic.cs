using Entities;
using System.Collections.Generic;

namespace BlContracts.Logic
{
    public interface IPaperLogic
    {
        int Add(string name, string issn);

        bool Update(int id, string name, string issn);

        Paper GetById(int id);

        IEnumerable<Paper> GetPapersStartsWith(string startsWith);
    }
}
