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
        public bool deleteEvent(Guid id)
        {
            BiletiEvent biletiEvent = DbContext.BiletiEvents.Where(x => x.Id == id).FirstOrDefault();
            if (biletiEvent != null)
            {
                DbContext.Remove(biletiEvent);
                DbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public BiletiEvent getEventById(Guid id)
        {
            BiletiEvent biletiEvent = DbContext.BiletiEvents.Where(x => x.Id == id).FirstOrDefault();
          
            return biletiEvent;
        }
        public List<BiletiEvent> getAll()
        {
            List<BiletiEvent> biletiEvents = DbContext.BiletiEvents.ToList();
            return biletiEvents;
        }
    }
}
