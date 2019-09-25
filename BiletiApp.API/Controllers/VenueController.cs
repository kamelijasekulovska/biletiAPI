using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiletiApp.API.Controllers
{
    [Authorize]
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

        //Get venue by id
        [HttpGet("getVenueById/{id}")]
        public ActionResult<Venue> getVenueById(Guid id)
        {
            try
            {
                var venue = _venueService.getVenueById(id);
                if(venue == null)
                {
                    return NotFound();
                }
                return _venueService.getVenueById(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        //List all available venues
        [HttpGet("getAllVenues")]
        public ActionResult<List<Venue>> getAllVenues()
        {
            try
            {
                var venues = _venueService.getAllVenues();
                if(venues.Count == 0)
                {
                    return NotFound();
                }
                return _venueService.getAllVenues();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }
        //Update venue details
        [HttpPut("updateVenue")]
        public ActionResult<Venue> updateVenue([FromBody]Venue venue)
        {
            try
            {
                if(venue == null)
                {
                    return BadRequest("Venue object is null");
                }
                return _venueService.updateVenue(venue);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        //Delete venue by id
        [HttpDelete("deleteVenue/{id}")]
        public ActionResult<bool> deleteVenue(Guid id)
        {
            try
            {
                var venue = _venueService.getVenueById(id);
               if (venue == null)
                {
                    return NotFound();
                }
                return _venueService.deleteVenue(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }


        //Get list of events by venue
        [HttpGet("getAllEventsForSpecificVenue/{id}")]
        public ActionResult<List<BiletiEvent>> getAllEventsForSpecificVenue(Guid id) {
            try
            {
                var venue = _venueService.getVenueById(id);
                var venueEvents = _venueService.getAllEventsForSpecificVenue(id);
                if(venue == null)
                {
                    return BadRequest("Invalid venue id");
                }
                if(venueEvents.Count == 0)
                {
                    return BadRequest("This venue doesn't have any events");
                }
                return _venueService.getAllEventsForSpecificVenue(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }
    }
}