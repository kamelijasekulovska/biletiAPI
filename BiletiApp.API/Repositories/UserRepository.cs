using BiletiApp.API.IRepositories;
using BiletiApp.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BiletiApp.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly BiletiDbContext DbContext;
        private readonly TokenManagement _tokenManagement;

        public UserRepository(BiletiDbContext dbContext, IOptions<TokenManagement> tokenManagement)
        {
            DbContext = dbContext;
            _tokenManagement = tokenManagement.Value;
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
            //User user = DbContext.Users.Where(x => x.Contact.Email == email).FirstOrDefault();

            var user = DbContext.Users.SingleOrDefault(x => x.Username == email && x.Password == password);

            if(user == null)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _tokenManagement.Issuer,
                audience: _tokenManagement.Audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            user.Token = tokenString;

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
