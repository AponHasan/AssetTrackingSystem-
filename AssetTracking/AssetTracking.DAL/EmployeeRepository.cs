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
    public class EmployeeRepository : CommonRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository() 
            : base(new AssetTrackDbContext())
        {
        }
    }
}
