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
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork uow;
        private readonly IPhotoRepository photoRepository;

        public PhotoService(IUnitOfWork uow, IPhotoRepository userRepository)
        {
            this.uow = uow;
            this.photoRepository = userRepository;
        }

        public void Create(BllPhoto photo)
        {
            photoRepository.Create(photo.ToDalPhoto());
            uow.Commit();
        }

        public void Delete(int key)
        {
            photoRepository.Delete(key);
            uow.Commit();
        }

        public IEnumerable<BllPhoto> GetAllByUserId(int userId)
        {
            return photoRepository.GetAllByUserId(userId)?.MapToBll();
        }

        public IEnumerable<BllPhoto> GetByPaging(int pageSize, int page, int userId)
        {
            return photoRepository.GetByPaging(pageSize, page, userId)?.MapToBll();
        }

        public BllPhoto GetById(int key)
        {
            return photoRepository.GetById(key)?.ToBllPhoto();
        }

        public int CountByUserId(int userId)
        {
            return photoRepository.CountByUserId(userId);
        }

        public void ChangeNumberOfLikes(int photoId, bool isUserLike)
        {
            photoRepository.ChangeNumberOfLikes(photoId, isUserLike);
            uow.Commit();
        }
    }
}
