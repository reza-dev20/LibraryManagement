using DataLayer.Model;
using DataLayer.Repository;
using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = UserRole.ADMIN)]
    public class AdminController : BaseController
    {
        private IUserRepository userRepo;
        private IUserService userService;
        public AdminController(IUserRepository _UserRepo, IUserService _UserService) {
            userRepo = _UserRepo;
            userService = _UserService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddUser() {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            Session.Remove(Sessions.USEREXIST.ToString());
            Session.Remove(Sessions.OPERATION_RESULT.ToString());
            if (ModelState.IsValid) {
                if (userService.getUser(user.Name,user.Family) != null)
                {
                    Session[Sessions.USEREXIST.ToString()] = "کاربر از قبل وجود دارد!.";
                }
                else
                {
                    userService.AddUser(user);
                    Session[Sessions.OPERATION_RESULT.ToString()] = "اطلاعات  با موفقیت افزوده شد.";                   
                }
            }           

            return RedirectToAction("AddUser");
        }

    }
}