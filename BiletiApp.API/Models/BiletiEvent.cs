using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class BiletiEvent
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Tag[] Tags { get; set; }
        public Image[] Images { get; set; }
        public string Cover { get; set; }
        public int Max_tickets_per_account { get; set; }
        public Organization Organization { get; set; }
        public Venue Venue { get; set; }

    }
}
