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
    public class PatentLogic : IPatentLogic
    {
        private IPatentDAO patentDAO;
        private IPatentValidator patentValidator;
        private ILogger logger;
        public PatentLogic(IPatentDAO patentDAO, IPatentValidator patentValidator, ILogger logger)
        {
            this.logger = logger;
            this.patentDAO = patentDAO;
            this.patentValidator = patentValidator;
        }

        public int AddPatent(string country, string regNumber, DateTime submission, DateTime dateOfPublication, int yearOfPublication, string name, int numberOfPages, string note, HashSet<Author> authors_Input)
        {
            if (this.patentValidator.AreValidDates(dateOfPublication, submission))
            {
                throw new ArgumentException();
            }

            if (this.patentValidator.IsValidCountry(country))
            {
                throw new ArgumentException();
            }

            if (this.patentValidator.IsValidRegNumber(regNumber))
            {
                throw new ArgumentException();
            }

            if (this.patentValidator.IsValidName(name))
            {
                throw new ArgumentException();
            }

            if (this.patentValidator.IsValidNumberOfPages(numberOfPages))
            {
                throw new ArgumentException();
            }

            if (this.patentValidator.IsValidNote(note))
            {
                throw new ArgumentException();
            }

            if (this.patentValidator.IsValidAuthor(authors_Input))
            {
                throw new ArgumentException();
            }

            Patent patent = new Patent()
            {
                Authors = authors_Input,
                Country = country,
                DateOfPublication = dateOfPublication,
                SubmissionDocuments = submission,
                Name = name,
                Note = note,
                NumberOfPages = numberOfPages,
                RegNumber = regNumber,
                YearOfPublishing = yearOfPublication,
            };

            if (this.patentDAO.Exists(patent))
            {
                throw new ArgumentException();
            }

            try
            {
                return this.patentDAO.AddItem(patent);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Update(int id, string country, string regNumber, DateTime submission, DateTime dateOfPublication, int yearOfPublication, string name, int numberOfPages, string note, HashSet<Author> authors_Input)
        {
            if(id < 1)
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.AreValidDates(dateOfPublication, submission))
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.IsValidCountry(country))
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.IsValidRegNumber(regNumber))
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.IsValidName(name))
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.IsValidNumberOfPages(numberOfPages))
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.IsValidNote(note))
            {
                throw new ArgumentException();
            }

            if (!this.patentValidator.IsValidAuthor(authors_Input))
            {
                throw new ArgumentException();
            }

            Patent patent = new Patent()
            {
                Id = id,
                Authors = authors_Input,
                Country = country,
                DateOfPublication = dateOfPublication,
                SubmissionDocuments = submission,
                Name = name,
                Note = note,
                NumberOfPages = numberOfPages,
                RegNumber = regNumber,
                YearOfPublishing = yearOfPublication,
            };

            //if (this.patentDAO.Exists(patent))
            //{
            //    throw new ArgumentException();
            //}

            try
            {
                return this.patentDAO.Update(patent);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<Patent> GetAllPatents()
        {
            try
            {
                return this.patentDAO.GetAllItems();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public Patent GetPatentById(int id)
        {
            try
            {
                return this.patentDAO.GetItemById(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool RemovePatent(int id)
        {
            try
            {
                return this.patentDAO.RemoveItem(id);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}