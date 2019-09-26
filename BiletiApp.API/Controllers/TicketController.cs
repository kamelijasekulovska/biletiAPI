using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BiletiApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

       

        [HttpPost("addTicket")]
        public ActionResult<Ticket> addTicket(Ticket ticket)
        {
            return _ticketService.addTicket(ticket);
        }

        [HttpPost("reserveTicket")]
        public ActionResult<bool> reserveTicket(Transaction transaction)
        {
            return _ticketService.reserveTicket(transaction);
        }

        [HttpPost("purchaseTicket")]
        public ActionResult<bool> purchaseTicket(Transaction transaction)
        {
            return _ticketService.purchaseTicket(transaction);
        }

        [HttpPost("invite")]
        public ActionResult<bool> invite(Ticket ticket, string email)
        {
           
            void Main()
            {
                Execute().Wait();
            }
                async Task Execute()
            {
                var apiKey = Environment.GetEnvironmentVariable("ticket");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("test@example.com", "Example User");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("test@example.com", "Example User");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }

            return _ticketService.invite(ticket, email);
        }

        [HttpPost("confirm")]
        public ActionResult<bool> confirm(Ticket ticket)
        {
            return _ticketService.confirm(ticket);
        }

        //Get ticket by id with necessary details
        [HttpGet("getTicketById/{id}")]
        public ActionResult<Ticket> getTicketById(Guid id)
        {
            try
            {
                var ticket = _ticketService.getTicketById(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return _ticketService.getTicketById(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
          
        }
    }
} 