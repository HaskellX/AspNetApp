using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DalContracts
{
    public interface IPaperDAO
    {
        int Add(Paper paper);

        bool Update(Paper paper);


        Paper GetById(int id);

        IEnumerable<Paper> GetPapersStartsWith(string startsWith);

    }
}
