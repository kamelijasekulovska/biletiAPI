﻿using System;
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
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        
    }
} 