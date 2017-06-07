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
    public class ProductManager : IProductManager
    {
        private ProductRepository _productRepository;

        public ProductManager()
        {
            _productRepository = new ProductRepository();
        }

        public ProductManager(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool Add(Product entity)
        {
            return _productRepository.Add(entity);
        }

        public bool Update(Product entity)
        {
            return _productRepository.Update(entity);
        }

        public bool Remove(long id)
        {
            return _productRepository.Remove(GetById(id));
        }

        public Product GetById(long id)
        {
            return _productRepository.GetById(id);
        }

        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ICollection<Product> GetProductBySubCategory(long subcategoryId)
        {
            var product = GetAll().AsQueryable().Where(s => s.SubCategoryID == subcategoryId);
            return product.ToList();
        }
    }
}
