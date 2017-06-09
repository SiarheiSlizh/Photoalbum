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
        IEnumerable<BllPhoto> GetAllByUserId(int userId);
        void Create(BllPhoto photo);
        void Delete(BllPhoto photo);
    }
}
