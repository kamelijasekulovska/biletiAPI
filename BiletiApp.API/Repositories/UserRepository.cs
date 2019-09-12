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


        public User registerUser(string email, string password, Organization organization)
        {
            User user = new User();
            user.Contact.Email = email;
            user.Password = password;
            user.Organization = organization;

            DbContext.Add(user);
            DbContext.SaveChanges();

            return user;
        }

        public bool updateUser(User user)
        {

            DbContext.Update(user);
            DbContext.SaveChanges();

            return true;
        }

        public User login(string email, string password)
        {
            //ova ne e dobro treba da se napravi
            User user = DbContext.Users.Where(x => x.Contact.Email == email).FirstOrDefault();

            return user;
        }

        public bool deleteUser(Guid id)
        {
            User user = DbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                DbContext.Remove(user);
                DbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
