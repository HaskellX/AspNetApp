using System;
using System.Collections.Generic;
using BL_Contracts.Validator;
using BlContracts.Logic;
using DalContracts;
using Entities;
using BL_Contracts;
using Entities.Exceptions;

namespace Business_Logic_Layer.Logic
{
    public class PaperIssueLogic : IPaperIssueLogic
    {
        private IPaperIssueDAO paperDAO;
        private IPaperIssueValidator paperValidator;
        private ILogger logger;

        public PaperIssueLogic(IPaperIssueDAO dao, IPaperIssueValidator paperValidator, ILogger logger)
        {
            this.logger = logger;
            this.paperDAO = dao;
            this.paperValidator = paperValidator;
        }

        public int Add(Paper paper, string cityOfPublishing, Publisher publisher, int yearOfPublishing, int numberOfPages, string note, int issueNumber, DateTime dateOfIssue)
        {
            if (paper == null)
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidCityOfPublishing(cityOfPublishing))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidPublisher(publisher))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.AreValidDates(dateOfIssue, yearOfPublishing))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidNumberPages(numberOfPages))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidNote(note))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidIssueNumber(issueNumber))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidPaper(paper))
            {
                throw new ArgumentException();
            }

            PaperIssue newPaperIssue = new PaperIssue
            {
                CityOfPublishing = cityOfPublishing,
                Publisher = publisher,
                YearOfPublishing = yearOfPublishing,
                NumberOfPages = numberOfPages,
                Note = note,
                IssueNumber = issueNumber,
                DateOfIssue = dateOfIssue,
                Paper = paper,
            };

            if (this.paperDAO.Exists(newPaperIssue))
            {
                throw new ArgumentException();
            }

            return this.paperDAO.AddItem(newPaperIssue);
        }

        public bool Update(int id, Paper paper, string cityOfPublishing, Publisher publisher, int yearOfPublishing, int numberOfPages, string note, int issueNumber, DateTime dateOfIssue)
        {
            if(id < 1)
            {
                throw new ArgumentException();
            }

            if (paper == null)
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidCityOfPublishing(cityOfPublishing))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidPublisher(publisher))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.AreValidDates(dateOfIssue, yearOfPublishing))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidNumberPages(numberOfPages))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidNote(note))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidIssueNumber(issueNumber))
            {
                throw new ArgumentException();
            }

            if (this.paperValidator.IsValidPaper(paper))
            {
                throw new ArgumentException();
            }

            PaperIssue newPaperIssue = new PaperIssue
            {
                CityOfPublishing = cityOfPublishing,
                Publisher = publisher,
                YearOfPublishing = yearOfPublishing,
                NumberOfPages = numberOfPages,
                Note = note,
                IssueNumber = issueNumber,
                DateOfIssue = dateOfIssue,
                Paper = paper,
            };

            if (this.paperDAO.Exists(newPaperIssue))
            {
                throw new ArgumentException();
            }

            try
            {
                return this.paperDAO.Update(newPaperIssue);
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
                return this.paperDAO.RemoveItem(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<PaperIssue> GetAll()
        {
            try
            {
                return this.paperDAO.GetAllItems();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public PaperIssue GetById(int id)
        {
            try
            {
                return this.paperDAO.GetItemById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<PaperIssue> GetPaperIssuesByPaperId(int id)
        {
            if(id < 1)
            {
                throw new ArgumentException();
            }

            try
            {
                return paperDAO.GetPaperIssuesByPaperId(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}
