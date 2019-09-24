using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; } 
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Cover { get; set; }
        public ICollection<Image> Gallery { get; set; }
        public Boolean Enabled { get; set; }
    }
}
