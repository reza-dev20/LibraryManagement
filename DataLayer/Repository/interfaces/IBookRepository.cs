
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> getAllBooks();

        IEnumerable<Borrow> getBorrowBooks();

        int addBorrowBook(Borrow borrow);

        int deleteBookBorrow(int bookId,int memberId);
    }
}
