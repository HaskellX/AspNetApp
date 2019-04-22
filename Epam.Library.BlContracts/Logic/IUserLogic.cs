using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Contracts.Logic
{
    public interface IUserLogic
    {
        bool Add(string login, string role, string password);

        IEnumerable<User> GetAll();

        User GetUserByLogin(string login);

        bool ChangeRole(string login, string role);

        bool CanLogin(string login, string password);

        IEnumerable<string> GetRolesForUser(string login);

        bool Exists(string login);

        bool IsUserInRole(string login, string role);
    }
}
