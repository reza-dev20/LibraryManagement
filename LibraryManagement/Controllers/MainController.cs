using DataLayer.Model;
using DataLayer.Repository;
using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles= UserRole.ADMIN+","+UserRole.UserAdmin)]
    public class MainController : BaseController
    {        

        public MainController(IMemberRepository _MemberRepo, IMemberService _MemberService)
        {
            memberRepo = _MemberRepo;
            memberService = _MemberService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
       public ActionResult Index(string fullName)
       {
            ViewBag.FullName = fullName;   
            
            return View();
       }
       [HttpGet]
       public ActionResult NewMember()
       {
            return PartialView();
       }

        [HttpPost]
        public ActionResult NewMember(Member member)
        {        
            Session.Remove(Sessions.USEREXIST.ToString());
            Session.Remove(Sessions.OPERATION_RESULT.ToString());            
            if (ModelState.IsValid) {
                if (memberService.getMember(member.NationalCode) != null)
                {
                    Session[Sessions.USEREXIST.ToString()] = "کاربر از قبل عضو میباشد.";
                   // return redirecttoaction("newmember");
                }
                else
                {                   
                   memberService.memberRegister(member);
                   Session[Sessions.OPERATION_RESULT.ToString()] = "اطلاعات  با موفقیت افزوده شد.";
                    // return redirecttoaction("index");
                }               
            }
            TempData["TargetDir"] = TargetDirection.NewMember;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MemberList() {
            var members= memberService.getAllMembers().ToList();
            return PartialView(members);
        }

        [HttpGet]
        public ActionResult EditMember(int id)
        {
            var model =memberService.getMember(id);
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditMember(Member member)
        {
            if (ModelState.IsValid) {
                memberService.memberUpdate(member);
                Session[Sessions.OPERATION_RESULT.ToString()] = "بروزرسانی اطلاعات انجام شد.";
                TempData["TargetDir"] = TargetDirection.MemberList;
            }            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMember(int id)
        {
            Session[Sessions.OPERATION_RESULT.ToString()] = "اطلاعات کاربر حذف شد!";
            memberService.deleteMember(id);
            TempData["TargetDir"] = TargetDirection.MemberList;
            return RedirectToAction("Index");
        }

        
    }    
}