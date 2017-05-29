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
    public class AssetPurchaseDetailManager : IAssetPurchaseDetailManager
    {
        private AssetPurchaseDetailRepository _purchaseDetailRepository;

        public AssetPurchaseDetailManager()
        {
            _purchaseDetailRepository= new AssetPurchaseDetailRepository();
        }
        public bool Add(AssetPurchaseDetail entity)
        {
          return  _purchaseDetailRepository.Add(entity);
        }

        public bool Update(AssetPurchaseDetail entity)
        {
            return _purchaseDetailRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _purchaseDetailRepository.Remove(GetById(id));
        }

        public AssetPurchaseDetail GetById(long id)
        {
            return _purchaseDetailRepository.GetById(id);
        }

        public ICollection<AssetPurchaseDetail> GetAll()
        {
            return _purchaseDetailRepository.GetAll();
        }
    }
}
