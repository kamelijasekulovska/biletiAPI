using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface IVenueService
    {
        Venue addVenue(Venue venue);
        Venue updateVenue(Venue venue);
        bool deleteVenue(Guid id);
    }
}
