using BiletiApp.API.IRepositories;
using BiletiApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        protected readonly BiletiDbContext DbContext;

        public OrganizationRepository(BiletiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Organization getOrganizationById(Guid id) {
            Organization organization = DbContext.Organizations.Where(x => x.Id == id).FirstOrDefault();

            return organization;
        }
        public Organization addOrganization(Organization organization)
        {
            DbContext.Add(organization);
            DbContext.SaveChanges();

            return organization;
        }

        public Organization updateOrganization(Organization organization) {

            DbContext.Update(organization);
            DbContext.SaveChanges();

            return organization;
        }

        public bool deleteOrganization(Guid id)
        {
            Organization organization = DbContext.Organizations.Where(x => x.Id == id).FirstOrDefault();
            if (organization != null)
            {
                DbContext.Remove(organization);
                DbContext.SaveChanges();

                return true;
            }

            return false;
        }
        public List<Organization> getAll()
        {
            List<Organization> organizations = DbContext.Organizations.ToList();
            return organizations;
        }

        public List<BiletiEvent> getAllEventsForSpecificOrganization(Guid id)
        {
            List<BiletiEvent> events = DbContext.BiletiEvents.Where(x => x.Organization.Id == id).ToList();
            return events;
        }

    }
}
