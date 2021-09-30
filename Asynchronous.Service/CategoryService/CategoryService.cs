using Asynchronous.Business.Abstract;
using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Create(Category entity)
        {
            await _categoryRepository.Add(entity);
        }

        public async Task Delete(Category entity)
        {
            await _categoryRepository.Delete(entity);
        }

        public async Task<List<Category>> GetAllIncluding()
        {
            return await _categoryRepository.GetAllIncluding();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.Get(i => i.Id == id);
        }

        public async Task SetActive(int id)
        {
            await _categoryRepository.SetActive(id);
        }

        public async Task SetDeActive(int id)
        {
            await _categoryRepository.SetDeActive(id);
        }

        public async Task Update(Category entity)
        {
            await _categoryRepository.Update(entity);
        }
    }
}
