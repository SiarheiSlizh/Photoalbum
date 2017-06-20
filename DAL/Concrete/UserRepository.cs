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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public bool CheckUserWithEmail(string email)
        {
            return context.Set<User>()
                .Any(e => e.Email == email);
        }

        public bool CheckUserWithUsername(string userName)
        {
            return context.Set<User>()
                .Any(e => e.UserName == userName);
        }
        
        public void CreateUser(DalUser dalUser, int roleId)
        {
            var role = context.Set<Role>()
                .FirstOrDefault(r => r.RoleId == roleId);
            
            var user = dalUser.ToOrmUser();

            if (role != null)
                user.Roles.Add(role);

            context.Set<User>().Add(user);
        }

        public DalUser GetById(int userId)
        {
            return context.Set<User>()
                .FirstOrDefault(u => u.UserId == userId)
                ?.ToDalUser();
        }

        public string[] GetRolesForUser(string userName)
        {
            var user = context.Set<User>()
                .FirstOrDefault(u => u.UserName == userName);
            
            string[] roles = new string[user.Roles.Count];
            for (int i = 0; i < user.Roles.Count; i++)
                roles[i] = user.Roles.ElementAt(i).Name;

            return roles;
        }

        public IEnumerable<DalUser> GetUsersBySubsrting(int pageSize, int page, string substring)
        {
            return context.Set<User>()
                .Where(u => u.UserName.Contains(substring))
                .OrderBy(u => u.UserId).Skip((page - 1) * pageSize)
                .Take(pageSize)
                .MapToDal();
        }

        public DalUser GetUserByUserName(string userName)
        {
            return context.Set<User>()
                .FirstOrDefault(u => u.UserName == userName)
                ?.ToDalUser();
        }

        public void Update(DalUser dalUser)
        {
            var user = context.Set<User>()
                .FirstOrDefault(u => u.UserName == dalUser.UserName);

            user.Email = dalUser.Email;
            user.Surname = dalUser.Surname;
            user.Name = dalUser.Name;
            user.Password = dalUser.Password;
            user.Description = dalUser.Description;
            user.Avatar = dalUser.Avatar;
        }

        public int CountBySubstring(string substring)
        {
            return context.Set<User>()
                .Where(u => u.UserName.Contains(substring))
                .Count();
        }

        public IEnumerable<DalUser> GetUserBySubstring(string substring)
        {
            return context.Set<User>()
                .Where(u => u.UserName.Contains(substring))
                .MapToDal();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>()
                .ToList()
                .Select(u => u.ToDalUser());
        }

        public void Delete(int key)
        {
            var user = context.Set<User>()
                .FirstOrDefault(u => u.UserId == key);

            context.Set<User>().Remove(user);
        }

        #region stubs
        public void Create(DalUser e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}