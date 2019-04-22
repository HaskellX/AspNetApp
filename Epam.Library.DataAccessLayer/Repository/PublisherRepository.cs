using System.Collections.Generic;
using Entities;

namespace DataAccessLayer.Repository
{
    internal class PublisherRepository
    {
        private static PublisherRepository publisherRepository;

        static PublisherRepository()
        {
            publisherRepository = new PublisherRepository();
        }

        private PublisherRepository()
        {
            this.Publishers = new List<Publisher>();
        }

        internal List<Publisher> Publishers { get; set; }

        public static PublisherRepository GetPublisherRepository()
        {
            return publisherRepository;
        }
    }
}