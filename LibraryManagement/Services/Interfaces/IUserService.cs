using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    public interface IUserService
    {
        User getUser(string userName);
        
        User getUser(string name,string family);

        IEnumerable<User> getAllUser();

        bool userAuthenticate(User db_user, User userEntry);

        Role getUserRole(int roleId);

        int AddUser(User user);
    }
}
