using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface ITicketService
    {
        
        Ticket addTicket(Ticket ticket);
        Ticket getTicketById(Guid id);
        bool reserveTicket(Transaction transaction);
        bool purchaseTicket(Transaction transaction);
        bool invite(Ticket ticket, string email);
        bool confirm(Ticket ticket);
    }
}
