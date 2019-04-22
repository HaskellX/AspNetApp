using System.Collections.Generic;
using Entities;

namespace DataAccessLayer.Repository
{
    internal class PatentRepository
    {
        private static PatentRepository patentRepository;

        static PatentRepository()
        {
            patentRepository = new PatentRepository();
        }

        private PatentRepository()
        {
            this.Patents = new List<Patent>();
        }

        internal List<Patent> Patents { get; set; }

        public static PatentRepository GetPatentRepository()
        {
            return patentRepository;
        }
    }
}