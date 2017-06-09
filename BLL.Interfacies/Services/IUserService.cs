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
        void CreateUser(BllUser bllUser, int roleId);
        BllUser GetUserByUserName(string userName);
        //BllUser GetUserByUserNameAndEmail(string userName, string email);
        string[] GetRolesForUser(string username);
        void Update(BllUser user);
    }
}
