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
    /// Service which contains main operations with user entity
    /// </summary>
    public class UserService : IUserService
    {
        #region fields
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;
        #endregion

        #region ctor
        public UserService(IUnitOfWork uow, IUserRepository userRepository)
        {
            this.uow = uow;
            this.userRepository = userRepository;
        }
        #endregion

        #region public fields
        /// <summary>
        /// check if email has already existed in database 
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>true in case existing email else false</returns>
        public bool CheckUserWithEmail(string email)
        {
            return userRepository.CheckUserWithEmail(email);
        }

        /// <summary>
        /// check if username has already existed in database
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns>true in case existing username else false</returns>
        public bool CheckUserWithUserName(string userName)
        {
            return userRepository.CheckUserWithUsername(userName);
        }

        /// <summary>
        /// create user entity
        /// </summary>
        /// <param name="bllUser">user entity on Bll</param>
        /// <param name="roleId">role identifier which user will have after creating</param>
        public void CreateUser(BllUser bllUser, int roleId)
        {
            userRepository.CreateUser(bllUser.ToDalUser(), roleId);
            uow.Commit();
        }

        /// <summary>
        /// find user entity using identifier
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns>user entity on BLL</returns>
        public BllUser GetById(int userId)
        {
            return userRepository.GetById(userId)?.ToBllUser();
        }

        /// <summary>
        /// find all roles which user has
        /// </summary>
        /// <param name="username">username which identifier user in database</param>
        /// <returns>array of roles</returns>
        public string[] GetRolesForUser(string username)
        {
            return userRepository.GetRolesForUser(username);
        }

        /// <summary>
        /// find users for paging
        /// </summary>
        /// <param name="pageSize">amount of users in page</param>
        /// <param name="page">number of page</param>
        /// <param name="substring">substring which is used for selection of photos(check if username contains this substring)</param>
        /// <returns>users</returns>
        public IEnumerable<BllUser> GetUsersBySubsrting(int pageSize, int page, string substring)
        {
            return userRepository.GetUsersBySubsrting(pageSize, page, substring)?.MapToBll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public BllUser GetUserByUserName(string userName)
        {
            return userRepository.GetUserByUserName(userName)?.ToBllUser();
        }

        /// <summary>
        /// update data about user in database
        /// </summary>
        /// <param name="user">user with new data</param>
        public void Update(BllUser user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }

        /// <summary>
        /// calculate amount of users whoose usernames contain substring
        /// </summary>
        /// <param name="substring">substring which is used for selection users</param>
        /// <returns>number of users</returns>
        public int CountBySubstring(string substring)
        {
            return userRepository.CountBySubstring(substring);
        }

        /// <summary>
        /// find users by substring
        /// </summary>
        /// <param name="substring">substring which is used for selection user</param>
        /// <returns>users</returns>
        public IEnumerable<BllUser> GetUserBySubstring(string substring)
        {
            return userRepository.GetUserBySubstring(substring)?.MapToBll();
        }
        #endregion
    }
}