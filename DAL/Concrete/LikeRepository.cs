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
    public class LikeRepository : ILikeRepository
    {
        private readonly DbContext context;

        public LikeRepository(DbContext context)
        {
            this.context = context;
        }
        
        public void Create(DalLike dalLike)
        {
            context.Set<Like>()
                .Add(dalLike.ToOrmLike());
        }

        public void Delete(int key)
        {
            var like = context.Set<Like>()
                .FirstOrDefault(l => l.LikeId == key);

            context.Set<Like>().Remove(like);
        }

        public IEnumerable<DalLike> GetAll()
        {
            return context.Set<Like>()
                .ToList()
                .Select(l => l.ToDalLike());
        }

        public DalLike GetById(int key)
        {
            return context.Set<Like>()
                .FirstOrDefault(l => l.LikeId == key)
                ?.ToDalLike();
        }

        public IEnumerable<DalLike> GetByPhotoId(int photoId)
        {
            return context.Set<Like>()
                .Where(l => l.PhotoId == photoId)
                .MapToDal();
        }

        public DalLike GetUserLike(int photoId, int userId)
        {
            return context.Set<Like>()
                .FirstOrDefault(l => l.PhotoId == photoId && l.UserId == userId)
                ?.ToDalLike();
        }
    }
}