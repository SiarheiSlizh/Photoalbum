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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository userRepository)
        {
            this.uow = uow;
            this.userRepository = userRepository;
        }

        public bool CheckUserWithEmail(string email) => userRepository.CheckUserWithEmail(email);

        public bool CheckUserWithUserName(string userName) => userRepository.CheckUserWithUsername(userName);
        
        public void CreateUser(BllUser bllUser, int roleId)
        {
            userRepository.CreateUser(bllUser.ToDalUser(), roleId);
            uow.Commit();
        }

        public string[] GetRolesForUser(string username)
        {
            return userRepository.GetRolesForUser(username);
        }

        public BllUser GetUserByUserName(string userName)
        {
            var user = userRepository.GetUserByUserName(userName);

            if (ReferenceEquals(user, null))
                return null;
            else
                return user.ToBllUser();
        }

        public void Update(BllUser user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }

        //public BllUser GetUserByUserNameAndEmail(string userName, string email)
        //{
        //    var user = userRepository.GetUserByUserNameAndEmail(userName, email);

        //    if (ReferenceEquals(user, null))
        //        return null;
        //    else
        //        return user.ToBllUser();
        //}
    }
}