using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.DaoAccess
{
    public class PatentDAO : IPatentDAO
    {
        public int AddItem(Patent patent)
        {
            patent.Id = ++IdStorage.UniqueId;
            PatentRepository.GetPatentRepository().Patents.Add(patent);
            return IdStorage.UniqueId;
        }

        public bool Exists(Patent patent)
        {
            var result = from patentEnt in PatentRepository.GetPatentRepository().Patents
                         where patentEnt.Country == patent.Country
                         where patentEnt.RegNumber == patent.RegNumber
                         select patentEnt;

            return result.Count() > 0;
        }

        public IEnumerable<Patent> GetAllItems()
        {
            return PatentRepository.GetPatentRepository().Patents.ToArray();
        }

        public Patent GetItemById(int id)
        {
            return PatentRepository.GetPatentRepository().Patents.FirstOrDefault(patent => patent.Id == id);
        }

        public bool RemoveItem(int id)
        {
            var result = PatentRepository.GetPatentRepository().Patents.RemoveAll(patent => patent.Id == id);

            return result > 0;
        }

        public bool Update(Patent patent)
        {
            throw new NotImplementedException();
        }
    }
}