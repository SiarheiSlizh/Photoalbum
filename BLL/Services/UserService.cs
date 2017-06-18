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

        public bool CheckUserWithEmail(string email)
        {
            return userRepository.CheckUserWithEmail(email);
        }

        public bool CheckUserWithUserName(string userName)
        {
            return userRepository.CheckUserWithUsername(userName);
        }

        public void CreateUser(BllUser bllUser, int roleId)
        {
            userRepository.CreateUser(bllUser.ToDalUser(), roleId);
            uow.Commit();
        }

        public BllUser GetById(int userId)
        {
            return userRepository.GetById(userId)?.ToBllUser();
        }

        public string[] GetRolesForUser(string username)
        {
            return userRepository.GetRolesForUser(username);
        }

        public IEnumerable<BllUser> GetUsersBySubsrting(int pageSize, int page, string substring)
        {
            return userRepository.GetUsersBySubsrting(pageSize, page, substring)?.MapToBll();
        }

        public BllUser GetUserByUserName(string userName)
        {
            return userRepository.GetUserByUserName(userName)?.ToBllUser();
        }

        public void Update(BllUser user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }

        public int CountBySubstring(string substring)
        {
            return userRepository.CountBySubstring(substring);
        }

        public IEnumerable<BllUser> GetUserBySubstring(string substring)
        {
            return userRepository.GetUserBySubstring(substring)?.MapToBll();
        }
    }
}