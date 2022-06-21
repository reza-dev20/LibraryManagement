using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private BookContext _DbContext;

        public UserRepository(BookContext bookContext) {
            _DbContext = bookContext;
        }

        public int AddUser(User user)
        {
            _DbContext.Users.Add(user);
            return _DbContext.SaveChanges();
        }

        public IEnumerable<User> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public User getUser(string userName)
        {
            return _DbContext.Users.
                    Where(user => user.UserName == userName).
                    FirstOrDefault();
        }

        public User getUser(string name, string family)
        {
            return _DbContext.Users.
                Where(x => x.Name == name && x.Family == family).FirstOrDefault();
        }

        public Role getUserRole(int roleId) 
        {
            return _DbContext.
                Role.
                Where(role => role.Id == roleId).FirstOrDefault();
         }

        /* public void UserRegister(Member member) {
             _DbContext.Members.Add(member);
             _DbContext.SaveChanges();
         }*/

        
    }
}
