using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IRepositories
{
    public interface IVenueRepository
    {
        Venue addVenue(Venue venue);
        Venue updateVenue(Venue venue);
        bool deleteVenue(Guid id);
        Venue getVenueById(Guid id);
    }
}
