using DataLayer.Model;
using DataLayer.Repository;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepo;
        public UserService(IUserRepository userRepo) {
            _UserRepo = userRepo;
        }
        public IEnumerable<User> getAllUser()
        {
            throw new NotImplementedException();
        }

        public User getUser(string userName) => _UserRepo.getUser(userName);

        public bool userAuthenticate(User db_user, User userEntry)
        {
            if (userEntry == null || db_user==null)
                return false;
            if ((db_user.UserName == userEntry.UserName) && (db_user.HashPassword == userEntry.HashPassword))
                return true;

            return false;
        }
        
        public Role getUserRole(int roleId) => _UserRepo.getUserRole(roleId);

        public int AddUser(User user) {
            return _UserRepo.AddUser(user);            
        }

        public User getUser(string name, string family)
        {
            return _UserRepo.getUser(name, family);
        }
    }
}
