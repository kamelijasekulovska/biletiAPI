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
        User registerUser(User user);
        User updateUser(User user);
        User login(User user);
       
    }
}
