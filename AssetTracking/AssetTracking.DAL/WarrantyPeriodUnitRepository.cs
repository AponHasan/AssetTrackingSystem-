using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models.Database;
using AssetTracking.Models.Models;

namespace AssetTracking.DAL
{
    public class WarrantyPeriodUnitRepository : CommonRepository<WarrantyPeriodUnit>
    {
        public WarrantyPeriodUnitRepository() 
            : base(new AssetTrackDbContext())
        {
        }
    }
}
