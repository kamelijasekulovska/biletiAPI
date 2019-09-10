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

        public Organization getOrganizationById(Guid id)
        {
            return _organizationRepository.getOrganizationById(id);
        }
        public Organization addOrganization(Organization organization)
        {
            return _organizationRepository.addOrganization(organization);
        }

        public Organization updateOrganization(Organization organization)
        {
            return _organizationRepository.updateOrganization(organization);
        }

        public bool deleteOrganization(Guid id)
        {
            return _organizationRepository.deleteOrganization(id);
        }
        public List<Organization> getAll()
        {
            return _organizationRepository.getAll();
        }
    }
}
