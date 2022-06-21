using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> getAllBooks();

        IEnumerable<Borrow> getBorrowBooks();

        int addBorrowBook(Borrow borrow);

        int deleteBookBorrow(int bookId, int memberId);
    }
}