using System;
using System.Collections.Generic;
using Entities;

namespace BlContracts.Logic
{
    public interface IPatentLogic
    {
        int AddPatent(string country, string regNumber, DateTime submission, DateTime dateOfPublication, int yearOfPublication, string name, int numberOfPages, string note, HashSet<Author> authors);

        bool Update(int id, string country, string regNumber, DateTime submission, DateTime dateOfPublication, int yearOfPublication, string name, int numberOfPages, string note, HashSet<Author> authors);

        bool RemovePatent(int id);

        Patent GetPatentById(int id);

        IEnumerable<Patent> GetAllPatents();
    }
}