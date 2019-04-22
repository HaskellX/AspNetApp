using BL_Contracts.Logic;
using DAL_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using ENTITIES;
using BL_Contracts;
using Entities.Exceptions;

namespace Business_Logic_Layer.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao logic;
        private ILogger logger;
        public UserLogic(IUserDao logic, ILogger logger)
        {
            this.logic = logic;
            this.logger = logger;
        }

        public bool Add(string login, string role, string password)
        {
            if(login == null)
            {
                throw new ArgumentNullException();
            }

            if(password == null)
            {
                throw new ArgumentNullException();
            }

            if(password.Contains(login))
            {
                throw new ArgumentException();
            }

            if(password.Length < 3)
            {
                throw new ArgumentException();
            }

            for(int i = 0; i < password.Length; i++)
            {
                // типа проверка
                if((int)password[i] < 32)
                {
                    throw new ArgumentException();
                }
            }

            string hash = Security.ComputeHash(password);
            try
            {
                return this.logic.Add(login, role, hash);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool CanLogin(string login, string password)
        {
            string hash = Security.ComputeHash(password);
            try
            {
                return this.logic.CanLogin(login, hash);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool ChangeRole(string login, string role)
        {
            try
            {
                return this.logic.ChangeRole(login, role);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool Exists(string login)
        {
            try
            {
                return this.logic.Exists(login);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return this.logic.GetAll();
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public IEnumerable<string> GetRolesForUser(string login)
        {
            try
            {
                return this.logic.GetRolesForUser(login);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                return this.logic.GetUserByLogin(login);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }

        public bool IsUserInRole(string login, string role)
        {
            try
            {
                return this.logic.IsUserInRole(login, role);
            }
            catch (Exception e)
            {
                logger.Error("DAL", e);
                throw new DalException(e);
            }
        }
    }
}
