using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface ICommentRepository : IRepository<DalComment>
    {
        IEnumerable<DalComment> GetAllByPhotoId(int photoId);
        IEnumerable<DalComment> GetByPaging(int pageSize, int page, int photoId);
        int CountByPhotoId(int photoId);
    }
}
