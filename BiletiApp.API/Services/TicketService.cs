﻿using BiletiApp.API.IRepositories;
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

        public bool reserveTicket(Transaction transaction)
        {
            return _ticketRepository.reserveTicket(transaction);
        }

        public bool purchaseTicket(Transaction transaction)
        {
            return _ticketRepository.purchaseTicket(transaction);
        }

        public bool invite(Ticket ticket, string email)
        {
            return _ticketRepository.invite(ticket, email);
        }

        public bool confirm(Ticket ticket)
        {
            return _ticketRepository.confirm(ticket);
        }
    }
}
