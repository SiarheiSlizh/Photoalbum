using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRepository 
    {
        DalUser GetUserByUserName(string userName);
        //DalUser GetUserByUserNameAndEmail(string userName, string email);
        void CreateUser(DalUser dalUser, int roleId);
        string[] GetRolesForUser(string userName);
        bool CheckUserWithEmail(string email);
        bool CheckUserWithUsername(string userName);
        void Update(DalUser user);
    }
}
