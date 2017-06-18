using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface ILikeRepository : IRepository<DalLike>
    {
        IEnumerable<DalLike> GetByPhotoId(int photoId);
        DalLike GetUserLike(int photoId, int userId);
    }
}
