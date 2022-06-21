
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name=BookContext") { 
        
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<Borrow> Borrow { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
