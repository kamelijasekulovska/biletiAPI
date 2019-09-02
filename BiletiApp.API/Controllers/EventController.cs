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

        [HttpPost]
        public ActionResult<BiletiEvent> addEvent([FromBody]BiletiEvent biletiEvent) {
            return _eventService.addEvent(biletiEvent);
        }

        [HttpPut]
        public ActionResult<BiletiEvent> updateEvent([FromBody]BiletiEvent biletiEvent) {
            return _eventService.updateEvent(biletiEvent);
        }
    }
}