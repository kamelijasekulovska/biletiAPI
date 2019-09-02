using BiletiApp.API.IRepositories;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Repositories
{
    public class EventRepository : IEventRepository
    {
        protected readonly BiletiDbContext DbContext;

        public EventRepository(BiletiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BiletiEvent addEvent(BiletiEvent biletiEvent)
        {
            DbContext.Add(biletiEvent);
            DbContext.SaveChanges();

            return biletiEvent;
        }

        public BiletiEvent updateEvent(BiletiEvent biletiEvent)
        {
            DbContext.Update(biletiEvent);
            DbContext.SaveChanges();

            return biletiEvent; 
        }
    }
}
