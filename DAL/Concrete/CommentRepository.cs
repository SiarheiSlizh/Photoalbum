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
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext context;

        public CommentRepository(DbContext context)
        {
            this.context = context;
        }

        public int CountByPhotoId(int photoId)
        {
            return context.Set<Comment>()
                .Where(c => c.PhotoId == photoId)
                .Count();
        }

        public void Create(DalComment dalComment)
        {
            context.Set<Comment>()
                .Add(dalComment.ToOrmComment());
        }

        public void Delete(int key)
        {
            var comm = context.Set<Comment>()
                .FirstOrDefault(c => c.CommentId == key);

            context.Set<Comment>().Remove(comm);
        }

        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>()
                .ToList()
                .Select(c => c.ToDalComment());
        }

        public IEnumerable<DalComment> GetAllByPhotoId(int photoId)
        {
            return context.Set<Comment>()
                .Where(c => c.PhotoId == photoId)
                .MapToDal();
        }

        public DalComment GetById(int key)
        {
            return context.Set<Comment>()
                .FirstOrDefault(c => c.CommentId == key)
                ?.ToDalComment();
        }

        public IEnumerable<DalComment> GetByPaging(int pageSize, int page, int photoId)
        {
            return context.Set<Comment>()
                .Where(c => c.PhotoId == photoId)
                .OrderBy(p => p.PhotoId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .MapToDal();
        }
    }
}