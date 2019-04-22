using System;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.DaoAccess
{
    public class PaperDAO : IPaperDAO
    {
        public int Add(Paper paper)
        {
            paper.Id = ++IdStorage.PaperUniqueId;
            PaperRepository.GetPaperRepository().Papers.Add(paper);
            return IdStorage.PaperUniqueId;
        }

        public Paper GetById(int id)
        {
            return PaperRepository.GetPaperRepository().Papers.FirstOrDefault(i => i.Id == id);
        }

        public bool Update(Paper paper)
        {
            throw new NotImplementedException();
        }
    }
}
