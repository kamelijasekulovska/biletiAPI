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
        public User registerUser(string email, string password, Organization organization)
        {
            return _userRepository.registerUser(email, password, organization);
        } 
        public bool updateUser(User user)
        {
            return _userRepository.updateUser(user);
        }

        public User login(string email, string password)
        {
            return _userRepository.login(email, password);
        }

        public bool deleteUser(Guid id)
        {
            return _userRepository.deleteUser(id);
        }
    }
}
