using BiletiApp.API.IRepositories;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Services
{
    public class TicketService : ITicketService
    {

        private ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket getTicketById(Guid id)
        {
            return _ticketRepository.getTicketById(id);
        }

        public Ticket addTicket(Ticket ticket)
        {
            return _ticketRepository.addTicket(ticket);
        }
    }
}
