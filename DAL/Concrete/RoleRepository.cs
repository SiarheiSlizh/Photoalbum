using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using System.Data.Entity;
using ORM.Entities;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalRole dalRole)
        {
            var role = new Role()
            {
                Name = dalRole.Name
            };

            context.Set<Role>().Add(role);
        }

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            var roles = context.Set<Role>().ToList();
            var dalRoles = new List<DalRole>();

            foreach (var role in roles)
                dalRoles.Add(new DalRole() { Id = role.RoleId, Name = role.Name });

            return dalRoles;
        }

        public DalRole GetById(int key)
        {
            var role = context.Set<Role>().FirstOrDefault(r => r.RoleId == key);

            if (ReferenceEquals(role, null))
                return null;

            return new DalRole()
            {
                Id = role.RoleId,
                Name = role.Name
            };
        }

        public bool IsUserInRole(string userName, string roleName)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == userName);

            return user.Roles.Any(r => r.Name == roleName);
        }
    }
}