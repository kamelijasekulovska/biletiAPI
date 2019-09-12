using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface IUserService
    {
        User registerUser(string email, string password, Organization organization);
        User login(string email, string password);
        bool updateUser(User user);
        bool deleteUser(Guid id);



    }
}
