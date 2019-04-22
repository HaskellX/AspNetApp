using System.Collections.Generic;
using Entities;

namespace DataAccessLayer.Repository
{
    internal class PaperRepository
    {
        private static PaperRepository paperRepository;

        static PaperRepository()
        {
            paperRepository = new PaperRepository();
        }

        private PaperRepository()
        {
            this.Papers = new List<Paper>();
        }

        internal List<Paper> Papers { get; set; }

        public static PaperRepository GetPaperRepository()
        {
            return paperRepository;
        }
    }
}