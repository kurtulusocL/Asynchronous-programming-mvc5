using Asynchronous.Business.Abstract;
using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task Create(Product entity)
        {
            await _productRepository.Add(entity);
        }

        public async Task Delete(Product entity)
        {
            await _productRepository.Delete(entity);
        }

        public async Task<List<Product>> GetAllIncluding()
        {
            return await _productRepository.GetAllIncluding();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.Get(i => i.Id == id);
        }

        public async Task<List<Category>> GetCategoryForProduct()
        {
            return await _categoryRepository.GetAllIncluding();
        }

        public async Task<List<Product>> GetProductByCategory(int id)
        {
            return await _productRepository.GetProductByCategory(id);
        }

        public async Task SetActive(int id)
        {
            await _productRepository.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _productRepository.SetDeActive(id);
        }

        public async Task Update(Product entity)
        {
            await _productRepository.Update(entity);
        }
    }
}
