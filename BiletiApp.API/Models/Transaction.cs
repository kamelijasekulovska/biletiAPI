using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
