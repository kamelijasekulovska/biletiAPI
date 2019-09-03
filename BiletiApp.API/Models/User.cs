using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public enum UserRole {
        Admin,
        Superadmin,
        User
    }
    public class User
    {
        public Guid Id { get; set; }
        public Contact Contact { get; set; }
        public string Password { get; set; }
        public Organization Organization { get; set; }
        public UserRole UserRole { get; set; }
    }
}
