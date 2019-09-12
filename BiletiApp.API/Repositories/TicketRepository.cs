using BiletiApp.API.IRepositories;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        protected readonly BiletiDbContext DbContext;

        public TicketRepository(BiletiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Ticket getTicketById(Guid id)
        {
            Ticket ticket = DbContext.Tickets.Where(x => x.Id == id).FirstOrDefault();

            return ticket;
        }

        public Ticket addTicket(Ticket ticket)
        {
            DbContext.Add(ticket);

            Transaction transaction = new Transaction();
            transaction.Ticket = ticket;
            transaction.TransactionStatus = TransactionStatus.Available;
            DbContext.Transactions.Add(transaction);

            DbContext.SaveChanges();

            return ticket;
        }

        public bool reserveTicket(Transaction transaction)
        {
            transaction = DbContext.Transactions.Where(x => x.Id == transaction.Id).FirstOrDefault();
            transaction.TransactionStatus = TransactionStatus.Pending;
            DbContext.SaveChanges();

            return true;
        }

        public bool purchaseTicket(Transaction transaction)
        {
            transaction = DbContext.Transactions.Where(x => x.Id == transaction.Id).FirstOrDefault();
            transaction.TransactionStatus = TransactionStatus.Confirmed;
            DbContext.SaveChanges();

            return true;
        }

        public bool invite(Ticket ticket, string email)
        {
            //prashalnici?????
            return true;
        }

        public bool confirm(Ticket ticket) 
        {
            Guid id = ticket.Id;
            Transaction transaction = DbContext.Transactions.Where(x => x.Ticket.Id == id).FirstOrDefault();
            transaction.TransactionStatus = TransactionStatus.Confirmed;

            DbContext.SaveChanges();

            return true;
        }
    }
}
