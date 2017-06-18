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
    /// Service which contains main operations with comment entity
    /// </summary>
    public class CommentService : ICommentService
    {
        #region fields
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;
        #endregion

        #region ctor
        public CommentService(IUnitOfWork uow, ICommentRepository commentRepository)
        {
            this.uow = uow;
            this.commentRepository = commentRepository;
        }
        #endregion

        #region public methods
        /// <summary>
        /// find all comments by photo
        /// </summary>
        /// <param name="photoId">id which identify photo in database</param>
        /// <returns>comments</returns>
        public IEnumerable<BllComment> GetAllByPhotoId(int photoId)
        {
            return commentRepository.GetAllByPhotoId(photoId)?.MapToBll();
        }

        /// <summary>
        /// create new comment entity
        /// </summary>
        /// <param name="bllComment">comment entity on BLL</param>
        public void Create(BllComment bllComment)
        {
            commentRepository.Create(bllComment.ToDalComment());
            uow.Commit();
        }

        /// <summary>
        /// Delete comment by identifier
        /// </summary>
        /// <param name="key">comment identifier</param>
        public void Delete(int key)
        {
            commentRepository.Delete(key);
            uow.Commit();
        }

        /// <summary>
        /// find a comment by identifier
        /// </summary>
        /// <param name="key">comment identifier</param>
        /// <returns>Bll comment entity</returns>
        public BllComment GetById(int key)
        {
            return commentRepository.GetById(key)?.ToBllComment();
        }

        /// <summary>
        /// calculate amount of comments by photo using photo identifier
        /// </summary>
        /// <param name="photoId">photo identifier</param>
        /// <returns>number of comments</returns>
        public int CountByPhotoId(int photoId)
        {
            return commentRepository.CountByPhotoId(photoId);
        }

        /// <summary>
        /// find comments for paging
        /// </summary>
        /// <param name="pageSize">amount of comments in page</param>
        /// <param name="page">number of pages</param>
        /// <param name="photoId">photo identifier</param>
        /// <returns>comments</returns>
        public IEnumerable<BllComment> GetByPaging(int pageSize, int page, int photoId)
        {
            return commentRepository.GetByPaging(pageSize, page, photoId)?.MapToBll();
        }
        #endregion
    }
}