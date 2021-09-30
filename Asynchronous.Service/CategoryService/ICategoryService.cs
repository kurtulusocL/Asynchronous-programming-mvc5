using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllIncluding();
        Task<Category> GetById(int id);
        Task Create(Category entity);
        Task Update(Category entity);
        Task Delete(Category entity);
        Task SetActive(int id);
        Task SetDeActive(int id);
    }
}
