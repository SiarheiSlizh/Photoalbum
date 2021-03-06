﻿using BLL.Interfacies.Services;
using PLMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLMvc.Infrastructure.Mappers;
using System.IO;
using PagedList;
using PLMvc.Models.PagingModels;

namespace PLMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private const int searchPageSize = 10;
        private const int photoPageSize = 3;
        private readonly IAccountService accountService;
        private readonly IPhotoService photoService;

        public HomeController(IAccountService accountService, IPhotoService photoService)
        {
            this.accountService = accountService;
            this.photoService = photoService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("UserPage");
            else
                return View();
        }

        public ActionResult UserPage()
        {
            var user = accountService.GetUserByUserName(HttpContext.User.Identity.Name).ToMvcUser();
            var paging = photoService.GetPhotosPaging(user.Id, photoPageSize, 1).ToMvcPhotosPaging();

            var mainPage = new UserPhotoViewModel
            {
                User = user,
                Photos = paging
            };
            
            return View(mainPage);
        }

        #region Search
        public ActionResult Search(string searchText)
        {
            var users = accountService.GetUsersBySubsrting(searchPageSize, 1, searchText).MapToMvc();
            var countUsers = accountService.CountBySubstring(searchText);
            var userPageInfo = new PageInfo { PageNumber = 1, PageSize = searchPageSize, TotalItems = countUsers };

            var usersList = new UsersPaging
            {
                Users = users,
                PageInfo = userPageInfo,
                SearchText = searchText
            };

            return View("SearchAuxillary", usersList);
        }
        
        [HttpGet]
        public ActionResult PagingUsers(string searchText, int page = 1)
        {
            var users = accountService.GetUsersBySubsrting(searchPageSize, page, searchText).MapToMvc();
            var countUsers = accountService.CountBySubstring(searchText);
            var userPageInfo = new PageInfo { PageNumber = page, PageSize = searchPageSize, TotalItems = countUsers };

            var usersList = new UsersPaging
            {
                Users = users,
                PageInfo = userPageInfo,
                SearchText = searchText
            };

            if (Request.IsAjaxRequest())
                return PartialView("_Search", usersList);

            return View("SearchAuxillary", usersList);
        }

        public ActionResult ShowUser(int userId)
        {
            var user = accountService.GetByUserId(userId)?.ToMvcUser();

            if (user == null)
                return HttpNotFound();
            
            var paging = photoService.GetPhotosPaging(user.Id, photoPageSize, 1).ToMvcPhotosPaging();

            var mainPage = new UserPhotoViewModel
            {
                User = user,
                Photos = paging
            };

            return View("UserPage", mainPage);
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var users = accountService.GetUserBySubstring(term)
                .MapToMvc()
                .Select(u => new { value = u.UserName });
            
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}