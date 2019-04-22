using System.Collections.Generic;
using Entities;

namespace DataAccessLayer.Repository
{
    internal class AuthorsRepository
    {
        private static AuthorsRepository authorsRepository;

        static AuthorsRepository()
        {
            authorsRepository = new AuthorsRepository();
        }

        private AuthorsRepository()
        {
            this.Authors = new List<Author>();
        }

        internal List<Author> Authors { get; set; }

        public static AuthorsRepository GetAuthorsRepository()
        {
            return authorsRepository;
        }
    }
}