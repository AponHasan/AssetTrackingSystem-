using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.DAL;
using AssetTracking.Models.Interfaces.IModelManager;
using AssetTracking.Models.Models;

namespace AssetTracking.BLL
{
    public class CategoryManager : ICategoryManager
    {
        private CategoryRepository _categoryRepository;

        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }

        public CategoryManager(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public bool Add(Category entity)
        {
            return _categoryRepository.Add(entity);
        }

        public bool Update(Category entity)
        {
            return _categoryRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _categoryRepository.Remove(GetById(id));
        }

        public Category GetById(long id)
        {
            return _categoryRepository.GetById(id);
        }

        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public ICollection<Category> GetCategorysByGeneralCateogry(long gcategoryId)
        {
            var category = GetAll().AsQueryable().Where(c => c.GeneralCategoryID == gcategoryId);
            return category.ToList();
        }
    }
}
