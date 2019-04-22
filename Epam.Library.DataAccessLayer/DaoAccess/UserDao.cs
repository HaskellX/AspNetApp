using DAL_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;

namespace Data_Access_Layer.DaoAccess
{
    public class UserDao : IUserDao
    {
        public bool Add(string login, string role, string hash)
        {
            throw new NotImplementedException();
        }

        public bool CanLogin(string login, string hash)
        {
            throw new NotImplementedException();
        }

        public bool ChangeRole(string login, string role)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetRolesForUser(string login)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string login, string role)
        {
            throw new NotImplementedException();
        }
    }
}
