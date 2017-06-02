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
    public class AssetPurchaseSerialNumberManager : IAssetPurchaseSerialNumberManager
    {
        private AssetPurchaseSerialNumberRepository _assetPurchaseSerialNumberRepository;

        public AssetPurchaseSerialNumberManager()
        {
            _assetPurchaseSerialNumberRepository = new AssetPurchaseSerialNumberRepository();
        }

        public AssetPurchaseSerialNumberManager(AssetPurchaseSerialNumberRepository assetPurchaseSerialNumberRepository)
        {
            _assetPurchaseSerialNumberRepository = assetPurchaseSerialNumberRepository;
        }
        public bool Add(AssetPurchaseSerialNumber entity)
        {
            return _assetPurchaseSerialNumberRepository.Add(entity);
        }

        public bool Update(AssetPurchaseSerialNumber entity)
        {
            return _assetPurchaseSerialNumberRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _assetPurchaseSerialNumberRepository.Remove(GetById(id));
        }

        public AssetPurchaseSerialNumber GetById(long id)
        {
            return _assetPurchaseSerialNumberRepository.GetById(id);
        }

        public ICollection<AssetPurchaseSerialNumber> GetAll()
        {
            return _assetPurchaseSerialNumberRepository.GetAll();
        }
    }
}
