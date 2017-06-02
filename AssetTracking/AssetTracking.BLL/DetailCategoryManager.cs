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
    public class DetailCategoryManager : IDetailCategoryManager
    {
        private IDetailCategoryRepository _detailCategoryRepository;

        public DetailCategoryManager()
        {
            _detailCategoryRepository = new DetailCategoryRepository();
        }

        public DetailCategoryManager(DetailCategoryRepository detailCategoryRepository)
        {
            _detailCategoryRepository = detailCategoryRepository;
        }

        public bool Add(DetailCategory entity)
        {
            return _detailCategoryRepository.Add(entity);
        }

        public bool Update(DetailCategory entity)
        {
            return _detailCategoryRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _detailCategoryRepository.Remove(GetById(id));
        }

        public DetailCategory GetById(long id)
        {
            return _detailCategoryRepository.GetById(id);   
        }

        public ICollection<DetailCategory> GetAll()
        {
            return _detailCategoryRepository.GetAll();
        }
    }
}
