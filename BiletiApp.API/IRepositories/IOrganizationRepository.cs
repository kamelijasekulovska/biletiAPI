using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.IRepositories
{
    public interface IOrganizationRepository
    {
        Organization addOrganization(Organization organization);
        Organization updateOrganization(Organization organization);
    }
}
