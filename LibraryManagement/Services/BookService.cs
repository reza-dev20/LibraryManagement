using DataLayer.Model;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Services.Interfaces
{
    public class BookService : IBookService
    {
        private IBookRepository _BookRepo;
        public BookService(IBookRepository bookRepo)
        {
            _BookRepo = bookRepo;
        }

        public int addBorrowBook(Borrow borrow)
        {
            return _BookRepo.addBorrowBook(borrow);
        }
   

        public IEnumerable<Book> getAllBooks()
        {
            return _BookRepo.getAllBooks();
        }

        public IEnumerable<Borrow> getBorrowBooks()
        {
            return _BookRepo.getBorrowBooks();
        }

        public int deleteBookBorrow(int bookId, int memberId)
        {
            return _BookRepo.deleteBookBorrow(bookId, memberId);
        }
    }
}