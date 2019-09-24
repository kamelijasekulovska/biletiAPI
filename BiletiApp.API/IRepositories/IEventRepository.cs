using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IRepositories
{
    public interface IEventRepository
    {
        BiletiEvent addEvent(BiletiEvent biletiEvent);
        BiletiEvent getEventById(Guid id);
        List<BiletiEvent> getAllEvents();
        BiletiEvent updateEvent(BiletiEvent biletiEvent);
        bool deleteEvent(Guid id);
        List<Ticket> getAllTicketsForSpecificEvent(Guid id);
    }
}
