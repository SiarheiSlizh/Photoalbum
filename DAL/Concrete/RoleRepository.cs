using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using System.Data.Entity;
using ORM.Entities;
using DAL.Mappers;

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
            context.Set<Role>()
                .Add(dalRole.ToOrmRole());
        }

        public void Delete(int key)
        {
            var role = context.Set<Role>()
                .FirstOrDefault(r => r.RoleId == key);

            context.Set<Role>().Remove(role);
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>()
                .ToList()
                .Select(r => r.ToDalRole());
        }

        public DalRole GetById(int key)
        {
            return context.Set<Role>()
                .FirstOrDefault(r => r.RoleId == key)
                ?.ToDalRole();
        }

        public bool IsUserInRole(string userName, string roleName)
        {
            var user = context.Set<User>()
                .FirstOrDefault(u => u.UserName == userName);

            if (ReferenceEquals(user, null))
                return false;

            return user.Roles.Any(r => r.Name == roleName);
        }
    }
}