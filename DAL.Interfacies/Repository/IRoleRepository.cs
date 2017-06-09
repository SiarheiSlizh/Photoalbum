using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        bool IsUserInRole(string userName, string roleName);
    }
}
