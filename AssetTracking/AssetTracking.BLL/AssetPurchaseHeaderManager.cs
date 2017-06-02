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
    public class AssetPurchaseHeaderManager : IAssetPurchaseHeaderManager
    {
        private AssetPurchaseHeaderRepository _purchaseHeaderRepository;

        public AssetPurchaseHeaderManager()
        {
            _purchaseHeaderRepository = new AssetPurchaseHeaderRepository();
        }

        public AssetPurchaseHeaderManager(AssetPurchaseHeaderRepository assetPurchaseHeaderRepository)
        {
            _purchaseHeaderRepository = assetPurchaseHeaderRepository;
        }
        public bool Add(AssetPurchaseHeader entity)
        {
            
            return _purchaseHeaderRepository.Add(entity);
        }


        public bool Update(AssetPurchaseHeader entity)
        {
            return _purchaseHeaderRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _purchaseHeaderRepository.Remove(GetById(id));
        }

        public AssetPurchaseHeader GetById(long id)
        {
            return _purchaseHeaderRepository.GetById(id);
        }

        public ICollection<AssetPurchaseHeader> GetAll()
        {
            return _purchaseHeaderRepository.GetAll();
        }
    }
}
