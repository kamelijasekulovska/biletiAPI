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
            DbContext.SaveChanges();

            return ticket;
        }

        public bool reserveTicket(Transaction transaction)
        {
            transaction.TransactionStatus = TransactionStatus.Pending;
            DbContext.Transactions.Add(transaction);
            DbContext.SaveChanges();

            return true;
        }
    }
}
