using DataLayer.Model;
using DataLayer.Repository;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManagement.Controllers
{
   [Authorize]
    public class LoginController : BaseController
    {
        private IUserRepository  userRepo;
        private IUserService     userService;

        public LoginController(IUserRepository _UserRepo ,IUserService _UserService)
        {
            userRepo     = _UserRepo;
            userService  = _UserService;
        }
        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(User userEntry) {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid) {
                //get user info from DB
                var db_User = userService.getUser(userEntry.UserName);
                if (userService.userAuthenticate(db_User, userEntry))
                {
                    FormsAuthentication.SetAuthCookie(db_User.UserName, false);
                    Session["UserRole"] = userService.getUserRole(db_User.RoleId);
                    return RedirectToAction("Index", "Main", new { fullName = db_User.FullName });
                }
                else
                    ViewBag.LoginError = "نام کاربری یا رمز عبور اشتباه است";
            }            
            return View();
        }
    }
}