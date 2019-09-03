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

        //Create organization with necessary details
        [HttpPost]
        public ActionResult<Organization> addOrganization([FromBody]Organization organization) {
            return _organizationService.addOrganization(organization);
        }

        //Update details for specific organization
        [HttpPut]
        public ActionResult<Organization> updateOrganization([FromBody]Organization organization) {
            return _organizationService.updateOrganization(organization);
        }
    }
}