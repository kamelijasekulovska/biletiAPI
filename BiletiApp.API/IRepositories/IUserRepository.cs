using BiletiApp.API.Models;
using BiletiApp.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IRepositories
{
   public interface IUserRepository
    {
        User registerUser(string email, string password, Organization organization);
        User login(string email, string password);
        bool updateUser(User user);
        bool deleteUser(Guid id);


    }
}
