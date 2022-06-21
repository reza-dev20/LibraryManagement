using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookContext _DbContext;

        public BookRepository(BookContext bookContext)
        {
            _DbContext = bookContext;
        }       

        public IEnumerable<Book> getAllBooks()
        {
            return _DbContext.Books;
        }

        public int addBorrowBook(Borrow borrow)
        {
            _DbContext.Borrow.Add(borrow);
            return _DbContext.SaveChanges();
        }

        public IEnumerable<Borrow> getBorrowBooks()
        {
            return _DbContext.Borrow;
        }

        public int deleteBookBorrow(int bookId,int memberId)
        {
            var result = _DbContext.Borrow.
                SingleOrDefault(m => (m.BookId == bookId) && (m.MemberId==memberId));
            if (result != null)
            {
                _DbContext.Borrow.Remove(result);
                var retval = _DbContext.SaveChanges();
                return retval;
            }
            return 0;
        }
    }
}
