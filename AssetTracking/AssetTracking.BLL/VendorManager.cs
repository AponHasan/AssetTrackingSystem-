using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Interfaces.IModelRepository;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class VendorManager : IVendorManager
    {
        private VendorRepository _vendorRepository;

        public VendorManager()
        {
            _vendorRepository= new VendorRepository();
        }
        public bool Add(Vendor entity)
        {
            return _vendorRepository.Add(entity);
        }

        public bool Update(Vendor entity)
        {
            return _vendorRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _vendorRepository.Remove(GetById(id));
        }

        public Vendor GetById(long id)
        {
            return _vendorRepository.GetById(id);
        }

        public ICollection<Vendor> GetAll()
        {
            return _vendorRepository.GetAll();
        }
    }
}
