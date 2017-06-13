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
    public class AssetPurchaseManager:IAssetPurchaseManager
    {

        private IAssetPurchaseRepository _assetPurchaseRepository;

        public AssetPurchaseManager()
        {
            _assetPurchaseRepository = new AssetPurchaseRepository();
        }
        public AssetPurchaseManager(IAssetPurchaseRepository assetPurchaseRepository)
        {
            _assetPurchaseRepository = assetPurchaseRepository;
        }
        public bool Add(AssetPurchaseHeader entity)
        {
            return _assetPurchaseRepository.Add(entity);
        }

        public bool Update(AssetPurchaseHeader entity)
        {
            return _assetPurchaseRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }
            return _assetPurchaseRepository.Remove(entity);
        }

        public AssetPurchaseHeader GetById(long id)
        {
            return _assetPurchaseRepository.GetById(id);
        }

        public ICollection<AssetPurchaseHeader> GetAll()
        {
            return _assetPurchaseRepository.GetAll();
        }
    }
}
