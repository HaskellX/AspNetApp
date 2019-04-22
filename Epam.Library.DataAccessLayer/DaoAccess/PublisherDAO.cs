using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.DaoAccess
{
    public class PublisherDAO : IPublisherDAO
    {
        public int AddPublisher(Publisher publisher)
        {
            publisher.Id = ++IdStorage.PublisherUniqueId;
            PublisherRepository.GetPublisherRepository().Publishers.Add(publisher);
            return IdStorage.PublisherUniqueId;
        }

        public IEnumerable<Publisher> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> GetAll(string startsWith)
        {
            throw new NotImplementedException();
        }

        public Publisher GetPublisherById(int id)
        {
            return PublisherRepository.GetPublisherRepository().Publishers.FirstOrDefault(i => i.Id == id);
        }

        public bool Update(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}