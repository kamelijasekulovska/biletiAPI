using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IRepositories
{
    public interface IOrganizationRepository
    {
        Organization getOrganizationById(Guid id);
        Organization addOrganization(Organization organization);
        Organization updateOrganization(Organization organization);
        bool deleteOrganization(Guid id);
        List<Organization> getAll();
        List<BiletiEvent> getAllEventsForSpecificOrganization(Guid id);
    }
}
