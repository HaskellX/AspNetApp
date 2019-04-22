using System.Collections.Generic;
using Entities;

namespace DalContracts
{
    public interface IPatentDAO
    {
        bool RemoveItem(int id);

        Patent GetItemById(int id);

        IEnumerable<Patent> GetAllItems();

        int AddItem(Patent patent);

        bool Update(Patent patent);

        bool Exists(Patent patent);
    }
}