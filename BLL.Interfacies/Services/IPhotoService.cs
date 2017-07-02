using BLL.Interfacies.Entities;
using BLL.Interfacies.PagingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IPhotoService
    {
        #region photo
        BllPhoto GetById(int key);
        void Create(BllPhoto photo);
        void Delete(int key);
        #endregion
        
        #region comment
        void CreateComment(BllComment bllComment);
        void DeleteComment(int key);
        #endregion

        #region like
        void ChangeNumberOfLikes(int photoId, int userId);
        #endregion

        #region paging
        BllCommentsPaging GetCommentsPaging(int photoId, int pageSize, int page, bool? definePage);
        BllPhotosPaging GetPhotosPaging(int userId, int pageSize, int page);
        #endregion
    }
}