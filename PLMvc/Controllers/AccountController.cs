using BLL.Interfacies.Services;
using PLMvc.Infrastructure;
using PLMvc.Infrastructure.Mappers;
using PLMvc.Models;
using PLMvc.Providers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace PLMvc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login or password.");
            }
            return View(login);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (register.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
                {
                    ModelState.AddModelError("Captcha", "Incorrect input");
                    return View(register);
                }

                bool anyUsername = userService.CheckUserWithUserName(register.UserName);
                if (anyUsername)
                {
                    ModelState.AddModelError("UserName", "User with this UserName has already registered");
                    return View(register);
                }

                bool anyEmail = userService.CheckUserWithEmail(register.Email);
                if(anyEmail)
                {
                    ModelState.AddModelError("Email", "User with this email address has already registered.");
                    return View(register);
                }

                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(register.UserName, register.Password, register.Email, register.Surname, register.Name, register.DateOfBirth);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(register.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Error registration.");
            }

            return View(register);
        }

        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            ProfileViewModel profile = userService.GetUserByUserName(User.Identity.Name).ToMvcProfile();
            
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(ProfileViewModel profile, HttpPostedFileBase upload)
        {
            profile.UserName = HttpContext.User.Identity.Name;
            var user = userService.GetUserByUserName(User.Identity.Name);
            if (!ReferenceEquals(upload, null))
            {
                if (upload.ContentLength > 4000)
                    ModelState.AddModelError("", "The size of the picture exceeds 4000 bytes");
                else {
                    using (var binaryreader = new BinaryReader(upload.InputStream))
                    {
                        profile.Avatar = binaryreader.ReadBytes(upload.ContentLength);
                    }
                }
            }
            else
                profile.Avatar = user.Avatar;

            if (ModelState.IsValid)
            {
                bool anyEmail = userService.CheckUserWithEmail(profile.Email);
                if (string.Compare(profile.Email, user.Email, true) != 0)
                {
                    if (anyEmail)
                    {
                        ModelState.AddModelError("Email", "User with this email address has already registered.");
                        return View(profile);
                    }
                }
                if (string.IsNullOrEmpty(profile.Password))
                    profile.Password = user.Password;
                else profile.Password = Crypto.HashPassword(profile.Password);
                
                userService.Update(profile.ToBllUser());
            }
            else
                return View(profile);
            
            return RedirectToAction("Index", "Home");
        }
    }
}