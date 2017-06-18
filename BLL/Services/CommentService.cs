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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;

        public CommentService(IUnitOfWork uow, ICommentRepository commentRepository)
        {
            this.uow = uow;
            this.commentRepository = commentRepository;
        }

        public IEnumerable<BllComment> GetAllByPhotoId(int photoId)
        {
            return commentRepository.GetAllByPhotoId(photoId)?.MapToBll();
        }

        public void Create(BllComment bllComment)
        {
            commentRepository.Create(bllComment.ToDalComment());
            uow.Commit();
        }

        public void Delete(int key)
        {
            commentRepository.Delete(key);
            uow.Commit();
        }

        public BllComment GetById(int key)
        {
            return commentRepository.GetById(key)?.ToBllComment();
        }

        public int CountByPhotoId(int photoId)
        {
            return commentRepository.CountByPhotoId(photoId);
        }

        public IEnumerable<BllComment> GetByPaging(int pageSize, int page, int photoId)
        {
            return commentRepository.GetByPaging(pageSize, page, photoId)?.MapToBll();
        }
    }
}
