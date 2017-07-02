using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Services;
using BLL.Interfacies.Entities;
using DAL.Interfacies.Repository;
using BLL.Mappers;
using BLL.Interfacies.PagingModels;

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
        private readonly ICommentRepository commentRepository;
        private readonly ILikeRepository likeRepository;
        #endregion

        #region ctor
        public PhotoService(IUnitOfWork uow, IPhotoRepository photoRepository, 
            ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            this.uow = uow;
            this.photoRepository = photoRepository;
            this.commentRepository = commentRepository;
            this.likeRepository = likeRepository;
        }
        #endregion

        #region photo's public methods
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
        /// find photo entity using identifier
        /// </summary>
        /// <param name="key">photo identifier</param>
        /// <returns>photo entity on BLL</returns>
        public BllPhoto GetById(int key)
        {
            return photoRepository.GetById(key)?.ToBllPhoto();
        }
        #endregion

        #region Comment's public methods
        /// <summary>
        /// create new comment entity
        /// </summary>
        /// <param name="bllComment">comment entity on BLL</param>
        public void CreateComment(BllComment bllComment)
        {
            commentRepository.Create(bllComment.ToDalComment());
            uow.Commit();
        }

        /// <summary>
        /// Delete comment by identifier
        /// </summary>
        /// <param name="key">comment identifier</param>
        public void DeleteComment(int key)
        {
            commentRepository.Delete(key);
            uow.Commit();
        }
        #endregion

        #region Like's public methods
        /// <summary>
        /// change number of likes on photo, add or delete like by particular user
        /// </summary>
        /// <param name="photoId">photo identifier</param>
        /// <param name="userId">user identifier</param>
        public void ChangeNumberOfLikes(int photoId, int userId)
        {
            var like = likeRepository.GetUserLike(photoId, userId)?.ToBllLike();
            bool isUserLike = false;

            if (like == null)
            {
                var newLike = new BllLike { PhotoId = photoId, UserId = userId };
                likeRepository.Create(newLike.ToDalLike());
            }
            else
            {
                isUserLike = true;
                likeRepository.Delete(like.Id);
            }

            photoRepository.ChangeNumberOfLikes(photoId, isUserLike);
            uow.Commit();
        }
        #endregion

        #region paging(Complex models)
        /// <summary>
        /// find photos for paging
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <param name="pageSize">amount of photos in page</param>
        /// <param name="page">page number</param>
        /// <returns>photo model for paging</returns>
        public BllPhotosPaging GetPhotosPaging(int userId, int pageSize, int page)
        {
            var photos = photoRepository.GetByPaging(pageSize, page, userId).MapToBll();
            var count = photoRepository.CountByUserId(userId);
            var pageInfo = new BllPageInfo { PageNumber = page, PageSize = pageSize, TotalItems = count };

            return new BllPhotosPaging
            {
                BllPageInfo = pageInfo,
                BllPhotos = photos
            };
        }

        /// <summary>
        /// find comments for paging
        /// </summary>
        /// <param name="photoId">photo identifier</param>
        /// <param name="pageSize">amount of comments in page</param>
        /// <param name="page">page number</param>
        /// <param name="definePage">define number of page by this flag: true - after creating comment, false - after deleting comment, null - default page</param>
        /// <returns>comment model for paging</returns>
        public BllCommentsPaging GetCommentsPaging(int photoId, int pageSize, int page, bool? definePage)
        {
            var count = commentRepository.CountByPhotoId(photoId);
            if (definePage == true)
                page = (int)Math.Ceiling((double)count / pageSize);
            else if (definePage == false) {
                if (count % pageSize == 0 && pageSize * page > count && page != 1)
                    page--;
            }

            var comments = commentRepository.GetByPaging(pageSize, page, photoId).MapToBll();
            var bllPageInfo = new BllPageInfo { PageNumber = page, PageSize = pageSize, TotalItems = count };

            return new BllCommentsPaging
            {
                BllPageInfo = bllPageInfo,
                BllComments = comments
            };
        }
        #endregion
    }
}