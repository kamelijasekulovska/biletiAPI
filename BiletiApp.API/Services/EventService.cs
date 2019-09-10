using BiletiApp.API.IRepositories;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Services
{
    public class EventService : IEventService
    {
        private IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository) {
            _eventRepository = eventRepository;
        }

        public BiletiEvent addEvent(BiletiEvent biletiEvent)
        {
            return _eventRepository.addEvent(biletiEvent);
        }

        public BiletiEvent updateEvent(BiletiEvent biletiEvent)
        {
            return _eventRepository.updateEvent(biletiEvent);
        }

        public bool deleteEvent(Guid id)
        {
            return _eventRepository.deleteEvent(id);
        }


    }
}
