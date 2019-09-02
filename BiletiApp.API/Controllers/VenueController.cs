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

        [HttpPost]
        public ActionResult<Venue> addVenue([FromBody]Venue venue)
        {
            return _venueService.addVenue(venue);
        }

        [HttpPut("{id}")]
        public ActionResult<Venue> updateVenue([FromBody]Venue venue)
        {
            return _venueService.updateVenue(venue);
        }
    }
}