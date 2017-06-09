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

        public void Delete(BllPhoto photo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllPhoto> GetAllByUserId(int userId)
        {
            var photos = photoRepository.GetAllByUserId(userId);

            if (ReferenceEquals(photos, null))
                return null;
            else
                return photos.MapToBll();
        }
    }
}
