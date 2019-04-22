using BL_Contracts;
using BL_Contracts.Logic;
using Entities.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;


namespace Epam.Library.Mvc.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private IUserLogic logic;
        private ILogger logger;

        public MyRoleProvider()
        {
            this.logic = (IUserLogic)DependencyResolver.Current.GetService(typeof(IUserLogic));
            this.logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
        }

        #region not implemented roleprovider methods

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        #endregion not implemented roleprovider methods

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                return this.logic.GetRolesForUser(username).ToArray();
            }
            catch (System.Exception e)
            {
                logger.Warning("BL", e);
                throw;
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                return this.logic.IsUserInRole(username, roleName);
            }
            catch (System.Exception e)
            {
                this.logger.Warning("BL", e);
                throw;
            }
        }
    }


}
