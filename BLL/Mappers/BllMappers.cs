using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using BLL.Interfacies.Entities;

namespace BLL.Mappers
{
    public static class BllMappers
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            return new BllUser()
            {
                Id = dalUser.Id,
                UserName = dalUser.UserName,
                Password = dalUser.Password,
                Email = dalUser.Email,
                Surname = dalUser.Surname,
                Name = dalUser.Name,
                DateOfBirth = dalUser.DateOfBirth,
                Avatar = dalUser.Avatar,
                Description = dalUser.Description
            };
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            return new DalUser()
            {
                Id = bllUser.Id,
                UserName = bllUser.UserName,
                Password = bllUser.Password,
                Email = bllUser.Email,
                Surname = bllUser.Surname,
                Name = bllUser.Name,
                DateOfBirth = bllUser.DateOfBirth,
                Avatar = bllUser.Avatar,
                Description = bllUser.Description
            };
        }

        public static IEnumerable<BllUser> MapToBll(this IEnumerable<DalUser> dalUsers)
        {
            var bllUsers = new List<BllUser>();

            foreach (var dalUser in dalUsers)
                bllUsers.Add(dalUser.ToBllUser());

            return bllUsers;
        }

        public static BllRole ToBllRole(this DalRole dalRole)
        {
            return new BllRole
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalRole ToDalRole(this BllRole bllRole)
        {
            return new DalRole
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }

        public static IEnumerable<BllRole> MapToBll(this IEnumerable<DalRole> dalRoles)
        {
            var bllRoles = new List<BllRole>();

            foreach (var dalRole in dalRoles)
                bllRoles.Add(dalRole.ToBllRole());

            return bllRoles;
        }

        public static BllAlbum ToBllAlbum(this DalAlbum dalAlbum)
        {
            return new BllAlbum
            {
                Id = dalAlbum.Id,
                Name = dalAlbum.Name,
                Image = dalAlbum.Image,
                DateOfCreation = dalAlbum.DateOfCreation
            };
        }

        public static DalAlbum ToDalAlbum(this BllAlbum bllAlbum)
        {
            return new DalAlbum
            {
                Id = bllAlbum.Id,
                Name = bllAlbum.Name,
                Image = bllAlbum.Image,
                DateOfCreation = bllAlbum.DateOfCreation
            };
        }

        public static BllPhoto ToBllPhoto(this DalPhoto dalPhoto)
        {
            return new BllPhoto
            {
                Id = dalPhoto.Id,
                Image = dalPhoto.Image,
                Description = dalPhoto.Description,
                NumberOfComments = dalPhoto.NumberOfComments,
                NumberOfLikes = dalPhoto.NumberOfLikes,
                DateOfLoading = dalPhoto.DateOfLoading,
                UserId = dalPhoto.UserId
            };
        }

        public static DalPhoto ToDalPhoto(this BllPhoto bllPhoto)
        {
            return new DalPhoto()
            {
                Id = bllPhoto.Id,
                Image = bllPhoto.Image,
                Description = bllPhoto.Description,
                NumberOfComments = bllPhoto.NumberOfComments,
                NumberOfLikes = bllPhoto.NumberOfLikes,
                DateOfLoading = bllPhoto.DateOfLoading,
                UserId = bllPhoto.UserId
            };
        }

        public static IEnumerable<BllPhoto> MapToBll(this IEnumerable<DalPhoto> dalPhotos)
        {
            var bllPhotos = new List<BllPhoto>();

            foreach (var dalPhoto in dalPhotos)
                bllPhotos.Add(dalPhoto.ToBllPhoto());

            return bllPhotos;
        }

        public static BllLike ToBllLike(this DalLike dalLike)
        {
            return new BllLike()
            {
                Id = dalLike.Id,
                PhotoId = dalLike.PhotoId,
                UserId = dalLike.UserId
            };
        }

        public static DalLike ToDalLike(this BllLike bllLike)
        {
            return new DalLike()
            {
                Id = bllLike.Id,
                PhotoId = bllLike.PhotoId,
                UserId = bllLike.UserId
            };
        }

        public static IEnumerable<BllLike> MapToBll(this IEnumerable<DalLike> dalLikes)
        {
            var bllLikes = new List<BllLike>();

            foreach (var dalLike in dalLikes)
                bllLikes.Add(dalLike.ToBllLike());

            return bllLikes;
        }

        public static BllComment ToBllComment(this DalComment dalComment)
        {
            return new BllComment()
            {
                Id = dalComment.Id,
                Description = dalComment.Description,
                DateOfSending = dalComment.DateOfSending,
                PhotoId = dalComment.PhotoId,
                UserId = dalComment.UserId
            };
        }

        public static DalComment ToDalComment(this BllComment bllComment)
        {
            return new DalComment()
            {
                Id = bllComment.Id,
                Description = bllComment.Description,
                DateOfSending = bllComment.DateOfSending,
                PhotoId = bllComment.PhotoId,
                UserId = bllComment.UserId
            };
        }

        public static IEnumerable<BllComment> MapToBll(this IEnumerable<DalComment> dalComments)
        {
            var bllComments = new List<BllComment>();

            foreach (var dalComment in dalComments)
                bllComments.Add(dalComment.ToBllComment());

            return bllComments;
        }
    }
}