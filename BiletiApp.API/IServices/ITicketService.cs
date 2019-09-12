using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface ITicketService
    {
        Ticket getTicketById(Guid id);
        Ticket addTicket(Ticket ticket);
        bool reserveTicket(Transaction transaction);
    }
}
