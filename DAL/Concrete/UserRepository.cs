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

        public bool CheckUserWithEmail(string email) => context.Set<User>().Any(e => e.Email == email);

        public bool CheckUserWithUsername(string userName) => context.Set<User>().Any(e => e.UserName == userName);
        
        public void CreateUser(DalUser dalUser, int roleId)
        {
            var role = context.Set<Role>().FirstOrDefault(r => r.RoleId == roleId);
            
            var user = dalUser.ToOrmUser();

            if (!ReferenceEquals(role,null))
                user.Roles.Add(role);

            context.Set<User>().Add(user);
        }

        public string[] GetRolesForUser(string userName)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == userName);
            
            string[] roles = new string[user.Roles.Count];
            for (int i = 0; i < user.Roles.Count; i++)
                roles[i] = user.Roles.ElementAt(i).Name;

            return roles;
        }

        public DalUser GetUserByUserName(string userName)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == userName);

            if (ReferenceEquals(user, null))
                return null;

            return user.ToDalUser();
        }

        public void Update(DalUser dalUser)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == dalUser.UserName);

            user.Email = dalUser.Email;
            user.Surname = dalUser.Surname;
            user.Name = dalUser.Name;
            user.Password = dalUser.Password;
            user.DateOfBirth = dalUser.DateOfBirth;
            user.Description = dalUser.Description;
            user.Avatar = dalUser.Avatar;
        }

        //public DalUser GetUserByUserNameAndEmail(string userName, string email)
        //{
        //    var user = context.Set<User>().FirstOrDefault(u => u.UserName == userName);

        //    if (ReferenceEquals(user, null) || (!ReferenceEquals(user,null) && user.Email != email))
        //        return null;

        //    return new DalUser()
        //    {
        //        Id = user.UserId,
        //        UserName = user.UserName,
        //        Email = user.Email,
        //    };
        //}
    }
}
