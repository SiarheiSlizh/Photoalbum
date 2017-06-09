using DAL.Interfacies.DTO;
using ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DalMappers
    {
        public static User ToOrmUser(this DalUser dalUser)
        {
            return new User()
            {
                UserId = dalUser.Id,
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

        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Surname = user.Surname,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Avatar = user.Avatar,
                Description = user.Description
            };
        }

        public static Role ToOrmRole(this DalRole dalRole)
        {
            return new Role
            {
                RoleId = dalRole.Id,
                Name = dalRole.Name
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole
            {
                Id = role.RoleId,
                Name = role.Name
            };
        }

        public static IEnumerable<DalRole> MapToDal(this IQueryable<Role> roles)
        {
            var dalRoles = new List<DalRole>();

            foreach (var role in roles)
                dalRoles.Add(role.ToDalRole());

            return dalRoles;
        }

        public static Album ToOrmAlbum(this DalAlbum dalAlbum)
        {
            return new Album
            {
                AlbumId = dalAlbum.Id,
                Name = dalAlbum.Name,
                Image = dalAlbum.Image,
                DateOfCreation = dalAlbum.DateOfCreation
            };
        }

        public static DalAlbum ToDalAlbum(this Album album)
        {
            return new DalAlbum
            {
                Id = album.AlbumId,
                Name = album.Name,
                Image = album.Image,
                DateOfCreation = album.DateOfCreation
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto dalPhoto)
        {
            return new Photo
            {
                PhotoId = dalPhoto.Id,
                Image = dalPhoto.Image,
                Description = dalPhoto.Description,
                NumberOfComments = dalPhoto.NumberOfComments,
                NumberOfLikes = dalPhoto.NumberOfLikes,
                DateOfLoading = dalPhoto.DateOfLoading,
                UserId = dalPhoto.UserId
            };
        }

        public static DalPhoto ToDalPhoto(this Photo photo)
        {
            return new DalPhoto()
            {
                Id = photo.PhotoId,
                Image = photo.Image,
                Description = photo.Description,
                NumberOfComments = photo.NumberOfComments,
                NumberOfLikes = photo.NumberOfLikes,
                DateOfLoading = photo.DateOfLoading,
                UserId = photo.UserId
            };
        }

        public static IEnumerable<DalPhoto> MapToDal(this IQueryable<Photo> photos)
        {
            var dalPhotos = new List<DalPhoto>();

            foreach (var photo in photos)
                dalPhotos.Add(photo.ToDalPhoto());

            return dalPhotos;
        }

        public static Like ToOrmLike(this DalLike dalLike)
        {
            return new Like()
            {
                LikeId = dalLike.Id,
                PhotoId = dalLike.PhotoId,
                UserId = dalLike.UserId
            };
        }

        public static DalLike ToDalLike(this Like like)
        {
            return new DalLike()
            {
                Id = like.LikeId,
                PhotoId = like.PhotoId,
                UserId = like.UserId
            };
        }

        public static Comment ToOrmComment(this DalComment dalComment)
        {
            return new Comment()
            {
                CommentId = dalComment.Id,
                Description = dalComment.Description,
                DateOfSending = dalComment.DateOfSending,
                PhotoId = dalComment.PhotoId,
                UserId = dalComment.UserId
            };
        }

        public static DalComment ToDalComment(this Comment comment)
        {
            return new DalComment()
            {
                Id = comment.CommentId,
                Description = comment.Description,
                DateOfSending = comment.DateOfSending,
                PhotoId = comment.PhotoId,
                UserId = comment.UserId
            };
        }
    }
}
