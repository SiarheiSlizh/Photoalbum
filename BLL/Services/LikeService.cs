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
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork uow;
        private readonly ILikeRepository likeRepository;

        public LikeService(IUnitOfWork uow, ILikeRepository likeRepository)
        {
            this.uow = uow;
            this.likeRepository = likeRepository;
        }

        public void Create(BllLike bllLike)
        {
            likeRepository.Create(bllLike.ToDalLike());
            uow.Commit();
        }

        public void Delete(int key)
        {
            likeRepository.Delete(key);
            uow.Commit();
        }

        public IEnumerable<BllLike> GetByPhotoId(int photoId)
        {
            return likeRepository.GetByPhotoId(photoId)?.MapToBll();
        }

        public BllLike GetUserLike(int photoId, int userId)
        {
            return likeRepository.GetUserLike(photoId, userId)?.ToBllLike();
        }
    }
}
