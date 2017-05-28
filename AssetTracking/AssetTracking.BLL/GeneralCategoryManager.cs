using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class GeneralCategoryManager :IGeneralCategoryManager
    {
        private GeneralCategoryRepository _generalCategoryRepository;
        public GeneralCategoryManager()
        {
            _generalCategoryRepository = new GeneralCategoryRepository();
        }

        public GeneralCategoryManager(GeneralCategoryRepository generalCategory)
        {
            _generalCategoryRepository = generalCategory;
        }
        public bool Add(GeneralCategory entity)
        {
           return _generalCategoryRepository.Add(entity);
        }

        public bool Update(GeneralCategory entity)
        {
            return _generalCategoryRepository.Update(entity);

        }

        public bool Remove(long id)
        {
            return _generalCategoryRepository.Remove(GetById(id));
        }

        public GeneralCategory GetById(long id)
        {
            return _generalCategoryRepository.GetById(id);
        }

        public ICollection<GeneralCategory> GetAll()
        {
           return _generalCategoryRepository.GetAll();
        }
    }
}
