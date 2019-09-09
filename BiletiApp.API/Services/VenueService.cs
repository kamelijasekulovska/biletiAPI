using BiletiApp.API.IRepositories;
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
        private IVenueRepository _venueRepository;
        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public Venue addVenue(Venue venue)
        {
            return _venueRepository.addVenue(venue);
        }

        public bool deleteVenue(Guid id)
        {
            return _venueRepository.deleteVenue(id);
        }

        public Venue updateVenue(Venue venue)
        {
            return _venueRepository.updateVenue(venue);
        }
    }
}
