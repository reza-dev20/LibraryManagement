
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Repository
{
    public interface IUserRepository
    {
        User getUser(string userName);
        IEnumerable<User> getAllUsers();

        Role getUserRole(int roleId);

        int AddUser(User user);

        User getUser(string name, string family);
    }
}