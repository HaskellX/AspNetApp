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
    public class PublisherLogic : IPublisherLogic
    {
        private IPublisherDAO publisherDAO;
        private IPublisherValidator publisherValidator;
        private ILogger logger;
        public PublisherLogic(IPublisherDAO publisherDAO, IPublisherValidator publisherValidator, ILogger logger)
        {
            this.logger = logger;
            this.publisherDAO = publisherDAO;
            this.publisherValidator = publisherValidator;
        }

        public int Add(Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentException("publisher cannot be null");
            }

            if (!this.publisherValidator.IsValidName(publisher.PublisherName))
            {
                throw new ArgumentException();
            }

            try
            {
                return this.publisherDAO.AddPublisher(publisher);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Update(Publisher publisher)
        {
            if(publisher.Id < 1)
            {
                throw new Exception();
            }

            if (publisher == null)
            {
                throw new ArgumentException("publisher cannot be null");
            }

            if (!this.publisherValidator.IsValidName(publisher.PublisherName))
            {
                throw new ArgumentException();
            }

            try
            {
                return this.publisherDAO.Update(publisher);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Publisher> GetAll()
        {
            try
            {
                return this.publisherDAO.GetAll();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Publisher> GetAll(string startsWith)
        {
            try
            {
                return this.publisherDAO.GetAll(startsWith);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public Publisher GetById(int id)
        {
            try
            {
                return this.publisherDAO.GetPublisherById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}