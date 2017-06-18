using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IUserService
    {
        bool CheckUserWithEmail(string email);
        bool CheckUserWithUserName(string userName);
        int CountBySubstring(string substring);
        void CreateUser(BllUser bllUser, int roleId);
        BllUser GetById(int userId);
        BllUser GetUserByUserName(string userName);
        IEnumerable<BllUser> GetUsersBySubsrting(int pageSize, int page, string substring);
        IEnumerable<BllUser> GetUserBySubstring(string substring);
        string[] GetRolesForUser(string username);
        void Update(BllUser user);
    }
}
