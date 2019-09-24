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
        [HttpPost("registerUser")]
        public ActionResult<User> registerUser(string email, string password, [FromBody]Organization organization)
        {
            return _userService.registerUser(email, password, organization);
        }
        //User login and token issuing
        [HttpPost("login")]
        public ActionResult<User> login(string email, string password)
        {
            return _userService.login(email, password);
        }

        // Update user details
        [HttpPut("updateUser")]
        public ActionResult<bool> updateUser([FromBody]User user)
        {
            try
            {
                if(user == null)
                {
                    return BadRequest("User object is null");
                }
                return _userService.updateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal server error");
            }
            
        }

        //Delete user by id
        [HttpDelete("deleteUser/{id}")]
        public ActionResult<bool> deleteUser(Guid id)
        {
            return _userService.deleteUser(id);
        }



    }
}