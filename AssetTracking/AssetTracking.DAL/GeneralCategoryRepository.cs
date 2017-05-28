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
    public class GeneralCategoryRepository : CommonRepository<GeneralCategory>
    {
        public GeneralCategoryRepository() 
            : base(new AssetTrackDbContext())
        {
        }
    }
}
