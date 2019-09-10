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
    public class OrganizationController : ControllerBase
    {
        private IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService) {
            _organizationService = organizationService;
        }

        [HttpGet("getOrganizationById")]
        public ActionResult<Organization> getOrganizationById(Guid id) {
            return _organizationService.getOrganizationById(id);
        }

        //Create organization with necessary details
        [HttpPost("addOrganization")]
        public ActionResult<Organization> addOrganization([FromBody]Organization organization) {
            return _organizationService.addOrganization(organization);
        }

        //Update details for specific organization
        [HttpPut("updateOrganization")]
        public ActionResult<Organization> updateOrganization([FromBody]Organization organization) {
            return _organizationService.updateOrganization(organization);
        }

        //Delete organization by id
        [HttpDelete("deleteOrganization")]
        public ActionResult<bool> deleteOrganization(Guid id)
        {
            return _organizationService.deleteOrganization(id);
        }
    }
}