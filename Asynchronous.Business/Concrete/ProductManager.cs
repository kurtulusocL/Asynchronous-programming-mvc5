using Asynchronous.Business.Abstract;
using Asynchronous.Core.DataAccess.EntityFramework;
using Asynchronous.DataAccess.Context;
using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Business.Concrete
{
    public class ProductManager : EntityRepositoryBase<Product, ApplicationDbContext>, IProductRepository
    {
        public async Task<List<Product>> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Product>().Include("Category").OrderBy(i => i.Stock).ToListAsync();
            }
        }

        public async Task<List<Category>> GetCategoryForProduct()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Category>().Include("Products").OrderBy(i => i.Products.Count()).ToListAsync();
            }
        }

        public async Task<List<Product>> GetProductByCategory(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Product>().Include("Category").Where(i => i.CategoryId == id).OrderBy(i => i.Stock).ToListAsync();
            }
        }

        public async Task SetActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Product>().Where(i => i.Id == id).FirstOrDefault();
                active.IsApproved = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Product>().Where(i => i.Id == id).FirstOrDefault();
                active.IsApproved = false;
                await context.SaveChangesAsync();
            }
        }
    }
}
