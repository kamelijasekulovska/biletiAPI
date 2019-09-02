using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Services
{
    public class VenueService : IVenueService
    {
        private IVenueService _venueRepository;
        public VenueService(IVenueService venueRepository)
        {
            _venueRepository = venueRepository;
        }
        
        public Venue addVenue(Venue venue)
        {
            return _venueRepository.addVenue(venue);
        }
        public Venue updateVenue(Venue venue)
        {
            return _venueRepository.updateVenue(venue);
        }
    }
}
