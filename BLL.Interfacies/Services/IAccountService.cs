using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IAccountService
    {
        #region User
        bool CheckUserWithEmail(string email);
        bool CheckUserWithUserName(string userName);
        int CountBySubstring(string substring);
        void CreateUser(BllUser bllUser, int roleId);
        BllUser GetByUserId(int userId);
        BllUser GetUserByUserName(string userName);
        IEnumerable<BllUser> GetUsersBySubsrting(int pageSize, int page, string substring);
        IEnumerable<BllUser> GetUserBySubstring(string substring);
        string[] GetRolesForUser(string username);
        void Update(BllUser user);
        #endregion

        #region Role
        BllRole GetByRoleId(int key);
        IEnumerable<BllRole> GetAll();
        bool IsUserInRole(string userName, string roleName);
        void CreateRole(BllRole role);
        #endregion
    }
}