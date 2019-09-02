using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface IEventService
    {
        BiletiEvent addEvent(BiletiEvent biletiEvent);
        BiletiEvent updateEvent(BiletiEvent biletiEvent);
    }
}
