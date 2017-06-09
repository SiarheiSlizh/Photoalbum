using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using System.Data.Entity;
using ORM.Entities;
using DAL.Mappers;

namespace DAL.Concrete
{
    public class PhotoRepository : IPhotoRepository
    {
        public DbContext context;

        public PhotoRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalPhoto dalPhoto)
        {
            var photo = dalPhoto.ToOrmPhoto();

            context.Set<Photo>().Add(photo);
        }

        public void Delete(DalPhoto dalPhoto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalPhoto> GetAllByUserId(int UserId)
        {
            var photos = context.Set<Photo>().Where(p => p.UserId == UserId);

            if (ReferenceEquals(photos, null))
                return null;

            return photos.MapToDal();
        }

        public DalPhoto GetById(int key)
        {
            throw new NotImplementedException();
        }
    }
}
