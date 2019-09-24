using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Venue
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public int Capacity { get; set; }
        public ICollection<Sector> Sectors { get; set; }
    }
}
