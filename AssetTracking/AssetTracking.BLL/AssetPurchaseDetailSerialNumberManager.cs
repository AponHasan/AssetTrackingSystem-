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
    public class AssetPurchaseDetailSerialNumberManager : IAssetPurchaseDetailSerialNumberManager
    {
        private AssetPurchaseDetailSerialNumberRepository _assetPurchaseDetailSerialNumberRepository;

        public AssetPurchaseDetailSerialNumberManager()
        {
            _assetPurchaseDetailSerialNumberRepository = new AssetPurchaseDetailSerialNumberRepository();
        }

        public AssetPurchaseDetailSerialNumberManager(AssetPurchaseDetailSerialNumberRepository assetPurchaseDetailSerialNumberRepository)
        {
            _assetPurchaseDetailSerialNumberRepository = assetPurchaseDetailSerialNumberRepository;
        }
        public bool Add(AssetPurchaseDetailSerialNumber entity)
        {
           return _assetPurchaseDetailSerialNumberRepository.Add(entity);
        }

        public bool Update(AssetPurchaseDetailSerialNumber entity)
        {
            return _assetPurchaseDetailSerialNumberRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _assetPurchaseDetailSerialNumberRepository.Remove(GetById(id));
        }

        public AssetPurchaseDetailSerialNumber GetById(long id)
        {
            return _assetPurchaseDetailSerialNumberRepository.GetById(id);
        }
        public ICollection<AssetPurchaseDetailSerialNumber> GetAll()
        {
           return _assetPurchaseDetailSerialNumberRepository.GetAll();
        }
    }
}
