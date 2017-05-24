using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models.Interfaces;
using AssetTracking.Models.Models;
using AssetTracking.Models.Database;

namespace AssetTracking.DAL
{
    public class OrganizationRepository:CommonRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository() : base(new AssetTrackDbContext())
        {
        }
    }
}
