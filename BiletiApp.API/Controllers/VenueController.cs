using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiletiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        //Create venue with necessary details
        [HttpPost("addVenue")]
        public ActionResult<Venue> addVenue([FromBody]Venue venue)
        {
            return _venueService.addVenue(venue);
        }

        //Update venue details
        [HttpPut("updateVenue")]
        public ActionResult<Venue> updateVenue([FromBody]Venue venue)
        {
            return _venueService.updateVenue(venue);
        }

        //Delete venue by id
        [HttpDelete("deleteVenue/{id}")]
        public ActionResult<bool> deleteVenue(Guid id)
        {
            return _venueService.deleteVenue(id);
        }

        //Get venue by id
        [HttpGet("getVenueById/{id}")]
        public ActionResult<Venue> getVenueById(Guid id)
        {
            return _venueService.getVenueById(id);
        }

        //List all available venues
        [HttpGet("getAll")]
        public ActionResult<List<Venue>> getAll()
        {
            return _venueService.getAll();
        }

        //Get list of events by venue
        [HttpGet("getAllEventsForSpecificVenue/{id}")]
        public ActionResult<List<BiletiEvent>> getAllEventsForSpecificVenue(Guid id) {

            return _venueService.getAllEventsForSpecificVenue(id);
        }
    }
}