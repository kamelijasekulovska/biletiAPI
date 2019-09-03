using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public BiletiEvent Event { get; set; }
        public int EventId { get; set; }
        public Seat Seat { get; set; }
        public int Price { get; set; }
        public string Barcode { get; set; }
     }
}
