using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetUserByUserName(string userName);
        IEnumerable<DalUser> GetUsersBySubsrting(int pageSize, int page, string substring);
        void CreateUser(DalUser dalUser, int roleId);
        int CountBySubstring(string substring);
        IEnumerable<DalUser> GetUserBySubstring(string substring);
        string[] GetRolesForUser(string userName);
        bool CheckUserWithEmail(string email);
        bool CheckUserWithUsername(string userName);
        void Update(DalUser user);
    }
}
