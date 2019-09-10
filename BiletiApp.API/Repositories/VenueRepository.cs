using BiletiApp.API.IRepositories;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        protected readonly BiletiDbContext DbContext;
        public VenueRepository(BiletiDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Venue addVenue(Venue venue)
        {
            DbContext.Add(venue);
            DbContext.SaveChanges();

            return venue;
        }

        public Venue updateVenue(Venue venue)
        {
            DbContext.Update(venue);
            DbContext.SaveChanges();

            return venue;
        }

        public bool deleteVenue(Guid id)
        {
            Venue venue = DbContext.Venues.Where(x => x.Id == id).FirstOrDefault();
            if (venue != null)
            {
                DbContext.Remove(venue);
                DbContext.SaveChanges();

                return true;
            }

            return false;
        }
        public Venue getVenueById(Guid id)
        {
            Venue venue = DbContext.Venues.Where(x => x.Id == id).FirstOrDefault();

            return venue;
        }

        public List<Venue> getAll()
        {
            List<Venue> venues = DbContext.Venues.ToList();
            return venues;
        }

        /*public List<BiletiEvent> getAllEventsByVenue(Guid id)
        {
            List<BiletiEvent> bEvents = DbContext.
        }*/
    }
}
