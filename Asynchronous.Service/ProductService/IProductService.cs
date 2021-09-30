using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Service.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllIncluding();
        Task<List<Product>> GetProductByCategory(int id);
        Task<List<Category>> GetCategoryForProduct();
        Task<Product> GetById(int id);
        Task Create(Product entity);
        Task Update(Product entity);
        Task Delete(Product entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
    }
}
