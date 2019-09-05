using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using BiletiApp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiletiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // User registration / organizations user registration
        [HttpPost]
        public ActionResult<User> registerUser([FromBody]User user)
        {
            return _userService.registerUser(user);
        }

        // Update user details
        [HttpPut]
        public ActionResult<User> updateUser([FromBody]User user)
        {
            return _userService.updateUser(user);
        }

        //User login and token issuing
        [HttpPost]
        public ActionResult<User> login([FromBody]User user)
        {
            return _userService.login(user);
        }

    }
}