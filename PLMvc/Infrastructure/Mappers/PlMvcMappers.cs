using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using PLMvc.Models;

namespace PLMvc.Infrastructure.Mappers
{
    public static class PlMvcMappers
    {
        public static BllUser ToBllUser(this UserViewModel userViewModel)
        {
            return new BllUser()
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                Password = userViewModel.Password,
                Email = userViewModel.Email,
                Surname = userViewModel.Surname,
                Name = userViewModel.Name,
                DateOfBirth = userViewModel.DateOfBirth,
                Avatar = userViewModel.Avatar,
                Description = userViewModel.Description
            };
        }

        public static UserViewModel ToMvcUser(this BllUser bllUser)
        {
            return new UserViewModel()
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

        public static BllRole ToBllRole(this RoleViewModel roleViewModel)
        {
            return new BllRole
            {
                Id = roleViewModel.Id,
                Name = roleViewModel.Name
            };
        }

        public static RoleViewModel ToMvcRole(this BllRole bllRole)
        {
            return new RoleViewModel
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }

        public static IEnumerable<RoleViewModel> MapToMvc(this IEnumerable<BllRole> bllRoles)
        {
            var roleViewModel = new List<RoleViewModel>();

            foreach (var bllRole in bllRoles)
                roleViewModel.Add(bllRole.ToMvcRole());

            return roleViewModel;
        }

        public static BllAlbum ToBllAlbum(this AlbumViewModel albumViewModel)
        {
            return new BllAlbum
            {
                Id = albumViewModel.Id,
                Name = albumViewModel.Name,
                Image = albumViewModel.Image,
                DateOfCreation = albumViewModel.DateOfCreation
            };
        }

        public static AlbumViewModel ToMvcAlbum(this BllAlbum bllAlbum)
        {
            return new AlbumViewModel
            {
                Id = bllAlbum.Id,
                Name = bllAlbum.Name,
                Image = bllAlbum.Image,
                DateOfCreation = bllAlbum.DateOfCreation
            };
        }

        public static BllPhoto ToBllPhoto(this PhotoViewModel photoViewModel)
        {
            return new BllPhoto
            {
                Id = photoViewModel.Id,
                Image = photoViewModel.Image,
                Description = photoViewModel.Description,
                NumberOfComments = photoViewModel.NumberOfComments,
                NumberOfLikes = photoViewModel.NumberOfLikes,
                DateOfLoading = photoViewModel.DateOfLoading,
                UserId = photoViewModel.UserId
            };
        }

        public static PhotoViewModel ToMvcPhoto(this BllPhoto bllPhoto)
        {
            return new PhotoViewModel()
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

        public static IEnumerable<PhotoViewModel> MapToMvc(this IEnumerable<BllPhoto> bllPhotos)
        {
            var photosViewModel = new List<PhotoViewModel>();

            foreach (var bllPhoto in bllPhotos)
                photosViewModel.Add(bllPhoto.ToMvcPhoto());

            return photosViewModel;
        }

        public static BllLike ToBllLike(this LikeViewModel likeViewModel)
        {
            return new BllLike()
            {
                Id = likeViewModel.Id,
                PhotoId = likeViewModel.PhotoId,
                UserId = likeViewModel.UserId
            };
        }

        public static LikeViewModel ToMvcLike(this BllLike bllLike)
        {
            return new LikeViewModel()
            {
                Id = bllLike.Id,
                PhotoId = bllLike.PhotoId,
                UserId = bllLike.UserId
            };
        }

        public static BllComment ToBllComment(this CommentViewModel commentViewModel)
        {
            return new BllComment()
            {
                Id = commentViewModel.Id,
                Description = commentViewModel.Description,
                DateOfSending = commentViewModel.DateOfSending,
                PhotoId = commentViewModel.PhotoId,
                UserId = commentViewModel.UserId
            };
        }

        public static CommentViewModel ToMvcComment(this BllComment bllComment)
        {
            return new CommentViewModel()
            {
                Id = bllComment.Id,
                Description = bllComment.Description,
                DateOfSending = bllComment.DateOfSending,
                PhotoId = bllComment.PhotoId,
                UserId = bllComment.UserId
            };
        }

        public static BllUser ToBllUser(this ProfileViewModel profile)
        {
            return new BllUser()
            {
                Id = profile.Id,
                UserName = profile.UserName,
                Password = profile.Password,
                Email = profile.Email,
                Surname = profile.Surname,
                Name = profile.Name,
                DateOfBirth = profile.DateOfBirth,
                Avatar = profile.Avatar,
                Description = profile.Description
            };
        }

        public static ProfileViewModel ToMvcProfile(this BllUser bllUser)
        {
            return new ProfileViewModel()
            {
                Id = bllUser.Id,
                UserName = bllUser.UserName,
                Email = bllUser.Email,
                Surname = bllUser.Surname,
                Name = bllUser.Name,
                DateOfBirth = bllUser.DateOfBirth,
                Avatar = bllUser.Avatar,
                Description = bllUser.Description
            };
        }
    }
}