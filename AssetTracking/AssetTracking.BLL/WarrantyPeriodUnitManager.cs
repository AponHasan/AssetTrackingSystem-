using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class WarrantyPeriodUnitManager : IWarrantyPeriodUnitManager
    {
        private WarrantyPeriodUnitRepository _warrantyPeriodUnitRepository;

        public WarrantyPeriodUnitManager()
        {
            _warrantyPeriodUnitRepository = new WarrantyPeriodUnitRepository();
        }

        public WarrantyPeriodUnitManager(WarrantyPeriodUnitRepository warrantyPeriodUnitRepository)
        {
            _warrantyPeriodUnitRepository = warrantyPeriodUnitRepository;
        }
        public bool Add(WarrantyPeriodUnit entity)
        {
            return _warrantyPeriodUnitRepository.Add(entity);
        }

        public bool Update(WarrantyPeriodUnit entity)
        {
            return _warrantyPeriodUnitRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _warrantyPeriodUnitRepository.Remove(GetById(id));
        }

        public WarrantyPeriodUnit GetById(long id)
        {
            return _warrantyPeriodUnitRepository.GetById(id);
        }

        public ICollection<WarrantyPeriodUnit> GetAll()
        {
            return _warrantyPeriodUnitRepository.GetAll();
        }
    }
}
