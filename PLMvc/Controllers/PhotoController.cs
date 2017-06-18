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
        private readonly IUserService userService;
        private readonly IPhotoService photoService;
        private readonly ICommentService commentService;
        private readonly ILikeService likeService;

        public PhotoController(IUserService userService, IPhotoService photoService, ICommentService commentService, ILikeService likeService)
        {
            this.userService = userService;
            this.photoService = photoService;
            this.commentService = commentService;
            this.likeService = likeService;
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
            if (ReferenceEquals(upload, null))
                ModelState.AddModelError("", "Photo haven't been loaded yet");
    
            if (ModelState.IsValid)
            {
                using (var binaryreader = new BinaryReader(upload.InputStream))
                {
                    photo.Image = binaryreader.ReadBytes(upload.ContentLength);
                }
                var user = userService.GetUserByUserName(HttpContext.User.Identity.Name);
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
            var user = userService.GetUserByUserName(User.Identity.Name)?.ToMvcUser();
            photoService.Delete(photoId);
            var photos = photoService.GetByPaging(photoPageSize, 1, user.Id)?.MapToMvc();
            var count = photoService.CountByUserId(user.Id);
            var pageInfo = new PageInfo { PageNumber = 1, PageSize = photoPageSize, TotalItems = count };
            var paging = new PhotosPaging { PageInfo = pageInfo, Photos = photos };

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
            var user = userService.GetById(userId).ToMvcUser();
            var photos = photoService.GetByPaging(photoPageSize, page, userId).MapToMvc();
            var count = photoService.CountByUserId(userId);
            var pageInfo = new PageInfo { PageNumber = page, PageSize = photoPageSize, TotalItems = count };
            var paging = new PhotosPaging { PageInfo = pageInfo, Photos = photos };

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
            var user = userService.GetById(photo.UserId)?.ToMvcUser();
            var comments = commentService.GetByPaging(commentPageSize, 1, photoId)?.MapToMvc();
            var count = commentService.CountByPhotoId(photoId);
            var pageInfo = new PageInfo { PageNumber = 1, PageSize = commentPageSize, TotalItems = count };
            var paging = new CommentsPaging { PageInfo = pageInfo, Comments = comments };

            var photoDetail = new PhotoCommentViewModel
            {
                User = user,
                Photo = photo,
                CommentPaging = paging
            }; 
            
            return View(photoDetail);
        }
        #endregion

        #region comments
        public ActionResult CreateComment(int photoId, string comment, int page)
        {
            var user = userService.GetUserByUserName(User.Identity.Name).ToMvcUser();

            if (!string.IsNullOrEmpty(comment))
            {
                var comm = new CommentViewModel() { PhotoId = photoId, Description = comment, UserId = user.Id, DateOfSending = DateTime.Now };
                commentService.Create(comm.ToBllComment());
            }
            
            var count = commentService.CountByPhotoId(photoId);
            page = (int)Math.Ceiling((double)count / commentPageSize);//define page
            var comments = commentService.GetByPaging(commentPageSize, page, photoId)?.MapToMvc();

            var pageInfo = new PageInfo { PageNumber = page, PageSize = commentPageSize, TotalItems = count };
            var paging = new CommentsPaging { PageInfo = pageInfo, Comments = comments };

            if (Request.IsAjaxRequest())
                return PartialView("_Comments", paging);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            user = userService.GetById(photo.UserId)?.ToMvcUser();

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
            commentService.Delete(commentId);
            var count = commentService.CountByPhotoId(photoId);

            if (count % commentPageSize == 0 && commentPageSize * page > count && page != 1)//define page
                page--;

            var comments = commentService.GetByPaging(commentPageSize, page, photoId)?.MapToMvc();
            var pageInfo = new PageInfo { PageNumber = page, PageSize = commentPageSize, TotalItems = count };
            var paging = new CommentsPaging { PageInfo = pageInfo, Comments = comments };

            if (Request.IsAjaxRequest())
                return PartialView("_Comments", paging);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            var user = userService.GetById(photo.UserId)?.ToMvcUser();

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
            var user = userService.GetById(comm.UserId)?.ToMvcUser();

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
            var comments = commentService.GetByPaging(commentPageSize, page, photoId)?.MapToMvc();
            var count = commentService.CountByPhotoId(photoId);
            var pageInfo = new PageInfo { PageNumber = page, PageSize = commentPageSize, TotalItems = count };
            var paging = new CommentsPaging { PageInfo = pageInfo, Comments = comments };

            if (Request.IsAjaxRequest())
                return PartialView("_Comments", paging);

            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            var user = userService.GetById(photo.UserId).ToMvcUser();

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
            var photo = photoService.GetById(photoId)?.ToMvcPhoto();
            var user = userService.GetUserByUserName(User.Identity.Name)?.ToMvcUser();
            var like = likeService.GetUserLike(photoId, user.Id);

            if (ReferenceEquals(like, null)) 
            {
                photoService.ChangeNumberOfLikes(photoId, false);
                var newLike = new LikeViewModel() { PhotoId = photoId, UserId = user.Id };
                likeService.Create(newLike.ToBllLike());
            }
            else
            {
                photoService.ChangeNumberOfLikes(photoId, true);
                likeService.Delete(like.Id);
            }

            photo = photoService.GetById(photoId)?.ToMvcPhoto();

            if (Request.IsAjaxRequest())
                return PartialView("_likes", photo);
            
            user = userService.GetById(photo.UserId)?.ToMvcUser();
            var comments = commentService.GetByPaging(commentPageSize, 1, photoId)?.MapToMvc();
            var count = commentService.CountByPhotoId(photoId);
            var pageInfo = new PageInfo { PageNumber = 1, PageSize = commentPageSize, TotalItems = count };
            var paging = new CommentsPaging { PageInfo = pageInfo, Comments = comments };

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