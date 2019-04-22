using System;
using System.Collections.Generic;
using BlContracts.Logic;
using BlContracts.Validator;
using DalContracts;
using Entities;
using BL_Contracts;
using Entities.Exceptions;

namespace BusinessLogicLayer.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        private IAuthorDAO authorDAO;
        private IAuthorValidator authorValidator;
        private ILogger logger;

        public AuthorLogic(IAuthorDAO authorDao, IAuthorValidator authorValidator, ILogger logger)
        {
            this.logger = logger;
            this.authorDAO = authorDao;
            this.authorValidator = authorValidator;
        }

        public int Add(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException("author is null", nameof(author));
            }

            if (!this.authorValidator.IsValidFirstName(author.FirstName))
            {
                throw new ArgumentException("Author's firstname is not valid", nameof(author.FirstName));
            }

            if (!this.authorValidator.IsValidLastName(author.LastName))
            {
                throw new ArgumentException("Author's lastname is not valid", nameof(author.LastName));
            }

            try
            {
                return this.authorDAO.Add(author);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                return this.authorDAO.GetAll();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Author> GetAll(string startsWith)
        {
            try
            {
                return this.authorDAO.GetAll(startsWith);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public Author GetAuthorById(int id)
        {
            try
            {
                return this.authorDAO.GetAuthorById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Update(Author author)
        {
            try
            {
                return this.Update(author);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}