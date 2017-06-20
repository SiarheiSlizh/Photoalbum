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
    /// <summary>
    /// Service which contains main operations with role entity
    /// </summary>
    public class RoleService : IRoleService
    {
        #region fields
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;
        #endregion

        #region ctor
        public RoleService(IUnitOfWork uow, IRoleRepository roleRepository)
        {
            this.uow = uow;
            this.roleRepository = roleRepository;
        }
        #endregion

        #region public methods
        /// <summary>
        /// find photo entity using identifier
        /// </summary>
        /// <param name="key">role identifier</param>
        /// <returns>role entity on BLL</returns>
        public BllRole GetById(int key)
        {
            return roleRepository.GetById(key)?.ToBllRole();
        }

        /// <summary>
        /// find all roles in database
        /// </summary>
        /// <returns>roles</returns>
        public IEnumerable<BllRole> GetAll()
        {
            return roleRepository.GetAll().MapToBll();
        }

        /// <summary>
        /// check if user has definite role
        /// </summary>
        /// <param name="userName">username</param>
        /// <param name="roleName">name of role</param>
        /// <returns>true in case positive results else false</returns>
        public bool IsUserInRole(string userName, string roleName)
        {
            return roleRepository.IsUserInRole(userName, roleName);
        }

        /// <summary>
        /// create new role entity
        /// </summary>
        /// <param name="role">role entity on BLL</param>
        public void CreateRole(BllRole role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }
        #endregion
    }
}