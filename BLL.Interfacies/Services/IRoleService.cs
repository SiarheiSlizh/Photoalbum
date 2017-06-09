using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        BllRole GetById(int key);
        IEnumerable<BllRole> GetAll();
        bool IsUserInRole(string userName, string roleName);
        void CreateRole(BllRole role);
    }
}
