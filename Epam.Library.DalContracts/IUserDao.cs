using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Contracts
{
    public interface IUserDao
    {
        bool Add(string login, string role, string hash);

        IEnumerable<User> GetAll();

        bool ChangeRole(string login, string role);

        bool CanLogin(string login, string hash);

        IEnumerable<string> GetRolesForUser(string login);

        bool Exists(string login);

        bool IsUserInRole(string login, string role);

        User GetUserByLogin(string login);
    }
}
