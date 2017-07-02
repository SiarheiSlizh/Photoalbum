using BLL.Interfacies.Services;
using PagedList;
using PLMvc.Infrastructure;
using PLMvc.Infrastructure.Mappers;
using PLMvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMvc.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        private const int commentPageSize = 5;
        private const int photoPageSize = 3;
        private readonly IAccountService accountService;
        private readonly IPhotoService photoService;

        public PhotoController(IAccountService accountService, IPhotoService photoService)
        {
            this.accountService = accountService;
            this.photoService = photoService;
        }

        #region photos
        [HttpGet]
        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhoto(PhotoViewModel photo, HttpPostedFileBase upload)
        {
            if (upload == null)
                ModelState.AddModelError("", "Photo haven't been loaded yet");

            if (ModelState.IsValid)
            {
                using (var binaryreader = new BinaryReader(upload.InputStream))
                {
                    photo.Image = binaryreader.ReadBytes(upload.ContentLength);
                }
                var user = accountService.GetUserByUserName(HttpContext.User.Identity.Name);
                photo.UserId = user.Id;
                photo.DateOfLoading = DateTime.Now;
                photoService.Create(photo.ToBllPhoto());
                return RedirectToAction("UserPage", "Home");
            }
            return View(photo);
        }

        [HttpPost]
        public ActionResult DeletePhoto(int photoId)
        {
            var user = accountService.GetUserByUserName(User.Identity.Name)?.ToMvcUser();
            photoService.Delete(photoId);
            var paging = photoService.GetPhotosPaging(user.Id, photoPageSize, 1).ToMvcPhotosPaging();

            var userPage = new UserPhotoViewModel
            {
                User = user,
                Photos = paging
            };

            return View("UserPage", userPage);
        }

        [HttpGet]
        public ActionResult PagingPhotos(int userId, int page = 1)
        {
            var user = accountService.GetByUserId(userId)?.ToMvcUser();
            var paging = photoService.GetPhotosPaging(user.Id, photoPageSize, page).ToMvcPhotosPaging();

            if (Request.IsAjaxRequest())
                return PartialView("_Photos", paging);

            var mainPage = new UserPhotoViewModel
            {
                User = user,
                Photos = paging
            };

            return View("UserPage", mainPage);
        }

        public ActionResult PhotoDetails(int photoId)
        {
            var photo = photoService.GetById(photoId)?.ToMvcPhoto();

            if (photo == null)
                return HttpNotFound();

            var user = accountService.GetByUserId(photo.UserId)?.ToMvcUser();
            var paging = photoService.GetCommentsPaging(photoId, commentPageSize, 1, null).ToMvcCommentsPaging();
           
            var photoDetail = new PhotoCommentViewModel
            {
                User = user,
                Photo = photo,
                CommentPaging = paging
            }; 
            
            return View(photoDetail);
        }

        public ActionResult GetAvatar(int id)
        {
            var user = accountService.GetByUserId(id);
            return File(user.Avatar, "image/*");
        }

        public ActionResult GetImage(int id)
        {
            var photo = photoService.GetById(id);
            return File(photo.Image, "image/*");
        }
        #endregion

        #region comments
        public ActionResult CreateComment(int photoId, string comment, int page)
        {
            var user = accountService.GetUserByUserName(User.Identity.Name)?.ToMvcUser();
            var comm = new CommentViewModel() { PhotoId = photoId, Description = comment, UserId = user.Id, DateOfSending = DateTime.Now };
            photoService.CreateComment(comm.ToBllComment());
            var paging = photoService.GetCommentsPaging(photoId, commentPageSize, page, true).ToMvcCommentsPaging();

            if (Request.IsAjaxRequest())
                return PartialView("_Comments", paging);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            user = accountService.GetByUserId(photo.UserId)?.ToMvcUser();

            var photoDetail = new PhotoCommentViewModel
            {
                User = user,
                Photo = photo,
                CommentPaging = paging
            };

            return View("PhotoDetails", photoDetail);
        }
        
        public ActionResult DeleteComment(int commentId, int photoId, int page = 1)
        {
            photoService.DeleteComment(commentId);
            var paging = photoService.GetCommentsPaging(photoId, commentPageSize, page, false).ToMvcCommentsPaging();

            if (Request.IsAjaxRequest())
                return PartialView("_Comments", paging);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            var user = accountService.GetByUserId(photo.UserId)?.ToMvcUser();

            var photoDetail = new PhotoCommentViewModel
            {
                User = user,
                Photo = photo,
                CommentPaging = paging
            };

            return View("PhotoDetails", photoDetail);
        }

        [ChildActionOnly]
        public ActionResult GetUserByComment(CommentViewModel comm, int page)
        {
            var user = accountService.GetByUserId(comm.UserId)?.ToMvcUser();

            var commentUser = new CommentUserViewModel
            {
                Comment = comm,
                User = user,
                Page = page
            };

            return PartialView("_Users", commentUser);
        }

        [HttpGet]
        public ActionResult PagingComments(int photoId, int page = 1)
        {
            var paging = photoService.GetCommentsPaging(photoId, commentPageSize, page, null).ToMvcCommentsPaging();

            if (Request.IsAjaxRequest())
                return PartialView("_Comments", paging);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            var user = accountService.GetByUserId(photo.UserId)?.ToMvcUser();

            var photoDetail = new PhotoCommentViewModel
            {
                User = user,
                Photo = photo,
                CommentPaging = paging
            };

            return View("PhotoDetails", photoDetail);
        }
        #endregion

        #region Likes
        public ActionResult ChangeLikes(int photoId)
        {
            var user = accountService.GetUserByUserName(User.Identity.Name)?.ToMvcUser();
            photoService.ChangeNumberOfLikes(photoId, user.Id);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();

            if (Request.IsAjaxRequest())
                return PartialView("_likes", photo);
            
            user = accountService.GetByUserId(photo.UserId)?.ToMvcUser();
            var paging = photoService.GetCommentsPaging(photoId, commentPageSize, 1, null).ToMvcCommentsPaging();

            var photoDetail = new PhotoCommentViewModel
            {
                User = user,
                Photo = photo,
                CommentPaging = paging
            };

            return View("PhotoDetails", photoDetail);
        }
        #endregion
    }
}