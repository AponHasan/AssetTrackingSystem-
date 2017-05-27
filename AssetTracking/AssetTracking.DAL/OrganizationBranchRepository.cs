using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models.Database;
using AssetTracking.Models.Interfaces;
using AssetTracking.Models.Models;

namespace AssetTracking.DAL
{
    public class OrganizationBranchRepository:CommonRepository<OrganizationBranch>,IOrganizationBranchRepository
    {
        public OrganizationBranchRepository()
            : base(new AssetTrackDbContext())
        {
        }
        //public OrganizationBranchRepository(DbContext dbContext) : base(dbContext)
        //{
        //}
    }
}
