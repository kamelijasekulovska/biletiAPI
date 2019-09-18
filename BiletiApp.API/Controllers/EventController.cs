using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                try
                {
                    if (biletiEvent == null)
                    {
                        return BadRequest("Event object is null");
                    }

                    return _eventService.updateEvent(biletiEvent);
                  
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal server error");
                }
            }



        //Delete event by id
        [HttpDelete("deleteEvent/{id}")]
        public ActionResult<bool> deleteEvent(Guid id)
        {
            try
            {
                var biletiEvent = _eventService.getEventById(id);

                if (biletiEvent == null)
                {
                    return NotFound();
                }

                return _eventService.deleteEvent(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        
            
        
        //Get event by id
        [HttpGet("getEventById/{id}")]
        public ActionResult<BiletiEvent> getEventById(Guid id)
        {
            try
            {
                var biletiEvent = _eventService.getEventById(id);
                
                if (biletiEvent == null)
                {
                    return NotFound();
                }

                return _eventService.getEventById(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }

        //List all available events
        [HttpGet("getAll")]
        public ActionResult<List<BiletiEvent>> getAll()
        {
            try
            {
                var biletiEvents = _eventService.getAll();

                if (biletiEvents == null)
                {
                    return NotFound();
                }

                return _eventService.getAll();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        

        //List all ticket per event
        [HttpGet("getAllTicketsForSpecificEvent/{id}")]
        public ActionResult<List<Ticket>> getAllTicketsForSpecificEvent(Guid id)
        {
            try
            {
                var eventTickets = _eventService.getAllTicketsForSpecificEvent(id);
               var biletiEvent = _eventService.getEventById(id);

                if (biletiEvent == null)
                {
                    return BadRequest("Invalid event id");
                }

                if (eventTickets.Count==0)
                {
                    return BadRequest("The event doesn't have any tickets");
                }

                return _eventService.getAllTicketsForSpecificEvent(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }
    }
}