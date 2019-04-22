using Entities;
using System.Collections.Generic;

namespace DalContracts
{
    public interface IAuthorDAO
    {
        IEnumerable<Author> GetAll();

        Author GetAuthorById(int id);

        int Add(Author author);

        bool Update(Author author);

        IEnumerable<Author> GetAll(string startsWith);

    }
}