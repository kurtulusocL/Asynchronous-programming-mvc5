using Asynchronous.Core.DataAccess;
using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Business.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<List<Product>> GetAllIncluding();
        Task<List<Product>> GetProductByCategory(int id);
        Task<List<Category>> GetCategoryForProduct();
        Task SetActive(int id);
        Task SetDeActive(int id);
    }
}
