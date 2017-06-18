using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Services;
using BLL.Interfacies.Entities;
using DAL.Interfacies.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    /// <summary>
    /// Service which contains main operations with photo entity
    /// </summary>
    public class PhotoService : IPhotoService
    {
        #region fields
        private readonly IUnitOfWork uow;
        private readonly IPhotoRepository photoRepository;
        #endregion

        #region ctor
        public PhotoService(IUnitOfWork uow, IPhotoRepository userRepository)
        {
            this.uow = uow;
            this.photoRepository = userRepository;
        }
        #endregion

        #region public methods
        /// <summary>
        /// create photo entity
        /// </summary>
        /// <param name="photo">photo entity on BLL</param>
        public void Create(BllPhoto photo)
        {
            photoRepository.Create(photo.ToDalPhoto());
            uow.Commit();
        }

        /// <summary>
        /// Delete photo by identifier
        /// </summary>
        /// <param name="key">photo identifier</param>
        public void Delete(int key)
        {
            photoRepository.Delete(key);
            uow.Commit();
        }

        /// <summary>
        /// find all photos by user using identifier
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns>photos</returns>
        public IEnumerable<BllPhoto> GetAllByUserId(int userId)
        {
            return photoRepository.GetAllByUserId(userId)?.MapToBll();
        }

        /// <summary>
        /// find photos for paging
        /// </summary>
        /// <param name="pageSize">amount of photos in page</param>
        /// <param name="page">number of pages</param>
        /// <param name="userId">user identifier</param>
        /// <returns>photos</returns>
        public IEnumerable<BllPhoto> GetByPaging(int pageSize, int page, int userId)
        {
            return photoRepository.GetByPaging(pageSize, page, userId)?.MapToBll();
        }

        /// <summary>
        /// find photo entity using identifier
        /// </summary>
        /// <param name="key">photo identifier</param>
        /// <returns>photo entity on BLL</returns>
        public BllPhoto GetById(int key)
        {
            return photoRepository.GetById(key)?.ToBllPhoto();
        }

        /// <summary>
        /// calculate amount of photo by user using identifier
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns>number of photos</returns>
        public int CountByUserId(int userId)
        {
            return photoRepository.CountByUserId(userId);
        }

        /// <summary>
        /// change number of likes on photo using photo identifier
        /// </summary>
        /// <param name="photoId">photo identifier</param>
        /// <param name="isUserLike">define if user leave like on photo</param>
        public void ChangeNumberOfLikes(int photoId, bool isUserLike)
        {
            photoRepository.ChangeNumberOfLikes(photoId, isUserLike);
            uow.Commit();
        }
        #endregion
    }
}