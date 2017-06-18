using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface ILikeService
    {
        void Create(BllLike bllLike);
        IEnumerable<BllLike> GetByPhotoId(int photoId);
        void Delete(int key);
        BllLike GetUserLike(int photoId, int userId);
    }
}
