using DataLayer.Model;
using DataLayer.Repository;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        public BookController(IBookRepository _BookRepo, IBookService _BookService)
        {
            bookRepo = _BookRepo;
            bookService = _BookService;
        }
        // GET: Book
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult BookList() {
            var result = bookService.getAllBooks();
            return PartialView(result);
        }
        
        //ketab amanat dade shode
        public ActionResult BorrowBookList() {
            var result = bookService.getBorrowBooks();
            return PartialView(result);
        }

        //hazfe ketabe amanat dade shode
        public ActionResult DeleteBookBorrow(int bookId,int memberId) {

            bookService.deleteBookBorrow(bookId, memberId);
            return RedirectToAction("BorrowBookList");
        }

        public ActionResult AddBorrowBook(Borrow borrow) {
            if (ModelState.IsValid) {
                bookService.addBorrowBook(borrow);
            }
            return RedirectToAction("BorrowBookList");
        }
    }
}