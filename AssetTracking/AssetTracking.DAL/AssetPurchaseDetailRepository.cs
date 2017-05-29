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
    public class AssetPurchaseDetailRepository : CommonRepository<AssetPurchaseDetail>
    {
        public AssetPurchaseDetailRepository() 
            : base(new AssetTrackDbContext())
        {
        }
    }
}
