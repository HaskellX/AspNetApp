using System;
using System.Collections.Generic;
using BlContracts;
using BlContracts.Logic;
using DalContracts;
using Entities;
using BL_Contracts;
using Entities.Exceptions;

namespace BusinessLogicLayer.Logic
{
    public class PaperLogic : IPaperLogic
    {
        private IPaperDAO paperDAO;
        private IPaperValidator paperValidator;
        private ILogger logger;
        public PaperLogic(IPaperDAO dao, IPaperValidator paperValidator, ILogger logger)
        {
            this.logger = logger;
            this.paperDAO = dao;
            this.paperValidator = paperValidator;
        }

        public int Add(string name, string issn)
        {
            if (this.paperValidator.IsValidISSN(issn))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidName(name))
            {
                throw new ArgumentException();
            }

            Paper paper = new Paper()
            {
                Issn = issn,
                Name = name,
            };

            try
            {
                return this.paperDAO.Add(paper);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Update(int id, string name, string issn)
        {
            if(id < 1)
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidISSN(issn))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidName(name))
            {
                throw new ArgumentException();
            }

            Paper paper = new Paper()
            {
                Issn = issn,
                Name = name,
            };

            try
            {
                return this.paperDAO.Update(paper);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }


        public Paper GetById(int id)
        {
            try
            {
                return this.paperDAO.GetById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Paper> GetPapersStartsWith(string startsWith)
        {
            try
            {
                return this.paperDAO.GetPapersStartsWith(startsWith);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}