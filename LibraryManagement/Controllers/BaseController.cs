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
    public class BaseController : Controller
    {
        protected IUserRepository _UserRepo;
        protected IUserService _UserService;

        protected IMemberRepository memberRepo;
        public IMemberService memberService;

        protected IBookRepository bookRepo;
        public IBookService bookService;

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
           return RedirectToAction("Login", "Login");
        }
    }
}