using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface ICommentService
    {
        void Create(BllComment bllComment);
        void Delete(int key);
        int CountByPhotoId(int photoId);
        BllComment GetById(int key);
        IEnumerable<BllComment> GetAllByPhotoId(int photoId);
        IEnumerable<BllComment> GetByPaging(int pageSize, int page, int photoId);
    }
}
