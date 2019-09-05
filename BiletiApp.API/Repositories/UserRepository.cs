using BiletiApp.API.IRepositories;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly BiletiDbContext DbContext;

        public UserRepository(BiletiDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public User registerUser(User user)
        {
            DbContext.Add(user);
            DbContext.SaveChanges();

            return user;
        }

        public User updateUser(User user)
        {

            DbContext.Update(user);
            DbContext.SaveChanges();

            return user;
        }

        public User login(User user)
        {
            DbContext.Add(user);
            DbContext.SaveChanges();

            return user;
        }
    }
}
