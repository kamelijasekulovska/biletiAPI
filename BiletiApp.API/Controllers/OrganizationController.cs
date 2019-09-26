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
    public class OrganizationController : ControllerBase
    {
        private IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService) {
            _organizationService = organizationService;
        }

        //Create organization with necessary details
        [HttpPost("addOrganization")]
        public ActionResult<Organization> addOrganization([FromBody]Organization organization)
        {
            return _organizationService.addOrganization(organization);
        }

        //Get organization by Id
        [HttpGet("getOrganizationById/{id}")]
        public ActionResult<Organization> getOrganizationById(Guid id) {
            try
            {
                var organization = _organizationService.getOrganizationById(id);
                if (organization == null)
                {
                    return NotFound();
                }
                return _organizationService.getOrganizationById(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

         //List all available organizations
        [HttpGet("getAllOrganizations")]
        public ActionResult<List<Organization>> getAllOrganizations()
        {
            try
            {
                var organizations = _organizationService.getAllOrganizations();
                if (organizations.Count == 0)
                {
                    return NotFound();
                }
                return _organizationService.getAllOrganizations();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }
       

        //Update details for specific organization
        [HttpPut("updateOrganization")]
        public ActionResult<Organization> updateOrganization([FromBody]Organization organization) {
            try
            {
                if (organization == null)
                {
                    return BadRequest("Organization object is null");
                }
                return _organizationService.updateOrganization(organization);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        //Delete organization by id
        [HttpDelete("deleteOrganization/{id}")]
        public ActionResult<bool> deleteOrganization(Guid id)
        {
            try
            {
                var organization = _organizationService.getOrganizationById(id);
                if (organization == null)
                {
                    return NotFound();
                }
                return _organizationService.deleteOrganization(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }


        //Get all events by orgaization
        [HttpGet("getAllEventsForSpecificOrganization/{id}")]
        public ActionResult<List<BiletiEvent>> getAllEventsForSpecificOrganization(Guid id)
        {
            try
            {
                var organization = _organizationService.getOrganizationById(id);
                var organizationEvents = _organizationService.getAllEventsForSpecificOrganization(id);
                if (organization == null)
                {
                    return BadRequest("Invalid organization id");
                }
                if (organizationEvents.Count == 0)
                {
                    return BadRequest("The organization doesn't have any events");
                }
                return _organizationService.getAllEventsForSpecificOrganization(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}