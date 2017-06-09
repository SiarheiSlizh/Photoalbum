using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using DAL.Interfacies.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository roleRepository)
        {
            this.uow = uow;
            this.roleRepository = roleRepository;
        }

        public BllRole GetById(int key)
        {
            var role = roleRepository.GetById(key);

            if (ReferenceEquals(role, null))
                return null;
            else
                return role.ToBllRole();
        }

        public IEnumerable<BllRole> GetAll() => roleRepository.GetAll().MapToBll();

        public bool IsUserInRole(string userName, string roleName) => roleRepository.IsUserInRole(userName, roleName);

        public void CreateRole(BllRole role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }
    }
}
