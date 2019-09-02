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

        public Organization addOrganization(Organization organization)
        {
            DbContext.Add(organization);
            DbContext.SaveChanges();

            return organization;
        }

        public Organization updateOrganization(Organization organization)
        {
            DbContext.Update(organization);
            DbContext.SaveChanges();

            return organization;
        } 
    }
}
