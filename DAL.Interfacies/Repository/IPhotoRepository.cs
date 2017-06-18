using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IPhotoRepository : IRepository<DalPhoto>
    {
        void ChangeNumberOfLikes(int photoId, bool isUserLike);
        IEnumerable<DalPhoto> GetAllByUserId(int UserId);
        IEnumerable<DalPhoto> GetByPaging(int pageSize, int page, int userId);
        int CountByUserId(int userId);
    }
}
