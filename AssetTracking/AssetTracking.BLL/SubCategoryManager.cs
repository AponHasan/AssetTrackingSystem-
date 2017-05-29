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
    public class SubCategoryManager : ISubCategoryManager
    {
        private SubCategoryRepository _subCategoryRepository;

        public SubCategoryManager()
        {
            _subCategoryRepository = new SubCategoryRepository();
        }

        public SubCategoryManager(SubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public bool Add(SubCategory entity)
        {
           return _subCategoryRepository.Add(entity);
        }

        public bool Update(SubCategory entity)
        {
            return _subCategoryRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _subCategoryRepository.Remove(GetById(id));
        }

        public SubCategory GetById(long id)
        {
           return _subCategoryRepository.GetById(id);
        }

        public ICollection<SubCategory> GetAll()
        {
            return _subCategoryRepository.GetAll();
        }
    }
}
