using System;
using System.Collections.Generic;
using System.Linq;
using DalContracts;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.DaoAccess
{
    public class AuthorDAO : IAuthorDAO
    {
        public int Add(Author author)
        {
            author.Id = ++IdStorage.AuthorUniqueId;
            AuthorsRepository.GetAuthorsRepository().Authors.Add(author);
            return IdStorage.AuthorUniqueId;
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll(string startsWith)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorById(int id)
        {
            return AuthorsRepository.GetAuthorsRepository().Authors.FirstOrDefault(i => i.Id == id);
        }

        public bool Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}