using BiletiApp.API.IRepositories;
using BiletiApp.API.IServices;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Services
{
    public class OrganizationService : IOrganizationService
    {
        private IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository) {
            _organizationRepository = organizationRepository;
        }
        public Organization addOrganization(Organization organization)
        {
            return _organizationRepository.addOrganization(organization);
        }
    }
}
