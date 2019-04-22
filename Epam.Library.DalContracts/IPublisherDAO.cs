using Entities;
using System.Collections.Generic;

namespace DalContracts
{
    public interface IPublisherDAO
    {
        int AddPublisher(Publisher publisher);

        bool Update(Publisher publisher);

        IEnumerable<Publisher> GetAll();

        Publisher GetPublisherById(int id);

        IEnumerable<Publisher> GetAll(string startsWith);
    }
}