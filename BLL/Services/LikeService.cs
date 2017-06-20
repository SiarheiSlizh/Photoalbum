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
    /// Service which contains main operations with like entity
    /// </summary>
    public class LikeService : ILikeService
    {
        #region fields
        private readonly IUnitOfWork uow;
        private readonly ILikeRepository likeRepository;
        #endregion

        #region ctor
        public LikeService(IUnitOfWork uow, ILikeRepository likeRepository)
        {
            this.uow = uow;
            this.likeRepository = likeRepository;
        }
        #endregion

        #region public methods
        /// <summary>
        /// create new like entity
        /// </summary>
        /// <param name="bllLike">like entity on BLL</param>
        public void Create(BllLike bllLike)
        {
            likeRepository.Create(bllLike.ToDalLike());
            uow.Commit();
        }

        /// <summary>
        /// delete like by identifier
        /// </summary>
        /// <param name="key">like identifier</param>
        public void Delete(int key)
        {
            likeRepository.Delete(key);
            uow.Commit();
        }

        /// <summary>
        /// find all likes using photo identifier
        /// </summary>
        /// <param name="photoId">photo identifier</param>
        /// <returns>likes</returns>
        public IEnumerable<BllLike> GetByPhotoId(int photoId)
        {
            return likeRepository.GetByPhotoId(photoId).MapToBll();
        }

        /// <summary>
        /// find like using user and photo identifiers
        /// </summary>
        /// <param name="photoId">photo identifier</param>
        /// <param name="userId">user identifier</param>
        /// <returns>like entity on BLL</returns>
        public BllLike GetUserLike(int photoId, int userId)
        {
            return likeRepository.GetUserLike(photoId, userId)?.ToBllLike();
        }
        #endregion
    }
}