using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public string Password { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}
