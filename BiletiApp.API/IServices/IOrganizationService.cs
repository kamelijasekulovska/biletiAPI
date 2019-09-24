using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IServices
{
    public interface IOrganizationService
    {
        Organization addOrganization(Organization organization);
        Organization getOrganizationById(Guid id);
        List<Organization> getAllOrganizations();
        Organization updateOrganization(Organization organization);
        bool deleteOrganization(Guid id);  
        List<BiletiEvent> getAllEventsForSpecificOrganization(Guid id);
    }
}
