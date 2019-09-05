using BiletiApp.API.IRepositories;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User registerUser(User user)
        {
            return _userRepository.registerUser(user);
        } 
        public User updateUser(User user)
        {
            return _userRepository.updateUser(user);
        }

        public User login(User user)
        {
            return _userRepository.login(user);
        }
    }
}
