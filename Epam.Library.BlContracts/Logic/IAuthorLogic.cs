using Entities;
using System.Collections.Generic;

namespace BlContracts.Logic
{
    public interface IAuthorLogic
    {
        int Add(Author author);

        bool Update(Author author);

        IEnumerable<Author> GetAll();

        IEnumerable<Author> GetAll(string startsWith);

        Author GetAuthorById(int id);
    }
}