using Entities;
using System.Collections.Generic;

namespace BlContracts.Logic
{
    public interface IPublisherLogic
    {
        int Add(Publisher publisher);

        bool Update(Publisher publisher);

        IEnumerable<Publisher> GetAll();

        IEnumerable<Publisher> GetAll(string startsWith);

        Publisher GetById(int id);
    }
}