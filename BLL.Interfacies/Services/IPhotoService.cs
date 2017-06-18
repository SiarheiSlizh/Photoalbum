using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IPhotoService
    {
        void ChangeNumberOfLikes(int photoId, bool isUserLike);
        IEnumerable<BllPhoto> GetAllByUserId(int userId);
        IEnumerable<BllPhoto> GetByPaging(int pageSize, int page, int userId);
        BllPhoto GetById(int key);
        void Create(BllPhoto photo);
        void Delete(int key);
        int CountByUserId(int userId);
    }
}
