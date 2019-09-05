using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface IUserService
    {
        User registerUser(User user);
        User updateUser(User user);

        User login(User user);

    }
}
