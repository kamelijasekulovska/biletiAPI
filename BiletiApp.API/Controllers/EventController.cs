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
    public class EventController : ControllerBase
    {
        private IEventService _eventService;

        public EventController(IEventService eventService) {
            _eventService = eventService;
        }

        //Create event with initial details
        [HttpPost("addEvent")]
        public ActionResult<BiletiEvent> addEvent([FromBody]BiletiEvent biletiEvent) {
            return _eventService.addEvent(biletiEvent);
        }

        //Update event data, tickets, and seats details
        [HttpPut("updateEvent")]
        public ActionResult<BiletiEvent> updateEvent([FromBody]BiletiEvent biletiEvent) {
            return _eventService.updateEvent(biletiEvent);
        }
        //Delete event by id
        [HttpDelete("deleteEvent")]
        public ActionResult<bool> deleteEvent(Guid id)
        {
            return _eventService.deleteEvent(id);
        }
        //Get event by id
        [HttpGet("getEventById")]
        public ActionResult<BiletiEvent> getEventById(Guid id)
        {
            return _eventService.getEventById(id);
        }
    }
}