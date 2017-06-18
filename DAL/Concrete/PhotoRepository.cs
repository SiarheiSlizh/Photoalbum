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
        private readonly DbContext context;

        public PhotoRepository(DbContext context)
        {
            this.context = context;
        }

        public int CountByUserId(int userId)
        {
            return context.Set<Photo>()
                .Where(p=>p.UserId == userId)
                .Count();
        }

        public void Create(DalPhoto dalPhoto)
        {
            context.Set<Photo>()
                .Add(dalPhoto.ToOrmPhoto());
        }
        
        public void ChangeNumberOfLikes(int photoId, bool isUserLike)
        {
            var photo = context.Set<Photo>()
                .FirstOrDefault(p => p.PhotoId == photoId);

            if (isUserLike)
                photo.NumberOfLikes--;
            else
                photo.NumberOfLikes++;
        }

        public void Delete(int key)
        {
            var photo = context.Set<Photo>()
                .FirstOrDefault(p => p.PhotoId == key);

            context.Set<Photo>().Remove(photo);
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return context.Set<Photo>()
                .ToList()
                .Select(p => p.ToDalPhoto());
        }

        public IEnumerable<DalPhoto> GetAllByUserId(int UserId)
        {
            return context.Set<Photo>()
                .Where(p => p.UserId == UserId)
                .MapToDal();
        }

        public DalPhoto GetById(int key)
        {
            return context.Set<Photo>()
                .FirstOrDefault(p => p.PhotoId == key)
                ?.ToDalPhoto();
        }

        public IEnumerable<DalPhoto> GetByPaging(int pageSize, int page, int userId)
        {
            return context.Set<Photo>()
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.PhotoId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .MapToDal();
        }
    }
}