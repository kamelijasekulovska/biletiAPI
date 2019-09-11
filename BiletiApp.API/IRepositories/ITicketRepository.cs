using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IRepositories
{
    public interface ITicketRepository
    {
        Ticket getTicketById(Guid id);
        Ticket addTicket(Ticket ticket);        
    }
}
