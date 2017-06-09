using BLL.Interfacies.Services;
using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PLMvc.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        #region prop
        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IRoleService RoleService
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));
        #endregion

        #region methods
        public override bool IsUserInRole(string username, string roleName)
        {
            return RoleService.IsUserInRole(username, roleName);
        }

        public override void CreateRole(string roleName)
        {
            var role = new BllRole() { Name = roleName };
            RoleService.CreateRole(role);
        }

        public override string[] GetRolesForUser(string username)
        {
            return UserService.GetRolesForUser(username);
        }
        #endregion

        #region stubs
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

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
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

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}