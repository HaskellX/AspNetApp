using System;
using System.Collections.Generic;
using BlContracts.Logic;
using DalContracts;
using Entities;
using Utility.Filter;
using BL_Contracts;
using Entities.Exceptions;

namespace BusinessLogicLayer.Logic
{
    public class CommonAccess : ICommonAccess
    {
        private ICommonDAO commonDAO;
        private ILogger logger;

        public CommonAccess(ICommonDAO commonDAO, ILogger logger)
        {
            this.commonDAO = commonDAO;
            this.logger = logger;
        }

        public IEnumerable<LibraryItem> GetAll()
        {
            return commonDAO.GetAllLibraryItems();
        }

        public LibraryItem GetItemById(int id)
        {
            if(id < 1)
            {
                throw new ArgumentException();
            }
            try
            {
                return commonDAO.GetItemById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<T> GetByFilter<T>(AbstractFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibraryItem> GetAll(int pageNumber, int numberOfResults, out int totalResult)
        {
            try
            {
                return commonDAO.GetAllLibraryItems(pageNumber, numberOfResults, out totalResult);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return this.commonDAO.Delete(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}