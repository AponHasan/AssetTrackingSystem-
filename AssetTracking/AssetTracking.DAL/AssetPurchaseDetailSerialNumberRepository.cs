using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models.Database;
using AssetTracking.Models.Interfaces.IModelRepository;
using AssetTracking.Models.Models;

namespace AssetTracking.DAL
{
    public class AssetPurchaseDetailSerialNumberRepository : CommonRepository<AssetPurchaseDetailSerialNumber>, IAssetPurchaseDetailSerialNumberRepository
    {
        public AssetPurchaseDetailSerialNumberRepository() 
            : base(new AssetTrackDbContext())
        {
        }
    }
}
