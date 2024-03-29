﻿using BiletiApp.API.IRepositories;
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
            var organization = DbContext.Organizations.Where(x => x.Id == biletiEvent.Organization.Id).FirstOrDefault();
            biletiEvent.Organization = organization;
            var venue = DbContext.Venues.Where(x => x.Id == biletiEvent.Venue.Id).FirstOrDefault();
            biletiEvent.Venue = venue;
            DbContext.Add(biletiEvent);
            DbContext.SaveChanges();

            return biletiEvent;
        }
        public BiletiEvent getEventById(Guid id)
        {
            BiletiEvent biletiEvent = DbContext.BiletiEvents.Where(x => x.Id == id).FirstOrDefault();

            return biletiEvent;
        }
        public List<BiletiEvent> getAllEvents()
        {
            List<BiletiEvent> biletiEvents = DbContext.BiletiEvents.ToList();
            return biletiEvents;
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

       

        public List<Ticket> getAllTicketsForSpecificEvent(Guid id) {
            //List<Transaction> transactions = DbContext.Transactions.Where(x => x.TransactionStatus == TransactionStatus.Available && ...).ToList();

            List<Ticket> tickets = DbContext.Tickets.Where(x => x.Event.Id == id).ToList();

            return tickets;

        }
    }
}
