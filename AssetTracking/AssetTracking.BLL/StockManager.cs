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
    public class StockManager:IStockManager
    {
        private IStockRepository _stockRepository;

        public StockManager()
        {
            _stockRepository = new StockRepository();
        }

        public StockManager(IStockRepository repository)
        {
            _stockRepository = repository;
        }
        public bool Add(AssetPurchaseHeader entity)
        {
           return _stockRepository.Add(entity);
        }

        public bool Update(AssetPurchaseHeader entity)
        {
            return _stockRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }
            return _stockRepository.Remove(entity);
        }

        public AssetPurchaseHeader GetById(long id)
        {
            return _stockRepository.GetById(id);
        }

        public ICollection<AssetPurchaseHeader> GetAll()
        {
            return _stockRepository.GetAll();
        }
    }
}
