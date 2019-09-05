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

        

    }
}
