using BLL.Interfacies.Services;
using PLMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLMvc.Infrastructure.Mappers;
using System.IO;

namespace PLMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IPhotoService photoService;

        public HomeController(IUserService userService, IPhotoService photoService)
        {
            this.userService = userService;
            this.photoService = photoService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserPage");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhoto(PhotoViewModel photo, HttpPostedFileBase upload)
        {
            if(ReferenceEquals(upload,null))
            {
                ModelState.AddModelError("", "Photo haven't been loaded yet");
            }

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
                return RedirectToAction("UserPage");
            }
            return View(photo);
        }

        public ActionResult UserPage()
        {
            var user = userService.GetUserByUserName(HttpContext.User.Identity.Name).ToMvcUser();
            int age = DateTime.Now.Year - user.DateOfBirth.Year;
            if (DateTime.Now.Month < user.DateOfBirth.Month || (DateTime.Now.Month == user.DateOfBirth.Month && DateTime.Now.Day < user.DateOfBirth.Day))
                age--;

            ViewBag.Age = age;
            return View(user);
        }

        [ChildActionOnly]
        public ActionResult ShowPhotos(int Id)
        {
            var user = userService.GetUserByUserName(HttpContext.User.Identity.Name);
            var photos = photoService.GetAllByUserId(user.Id).MapToMvc();
            ViewBag.UserName = user.UserName;
            return PartialView("_Photos", photos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}