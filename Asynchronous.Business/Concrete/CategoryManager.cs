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
    public class CategoryManager : EntityRepositoryBase<Category, ApplicationDbContext>, ICategoryRepository
    {
        public async Task<List<Category>> GetAllIncluding()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Category>().Include("Products").OrderByDescending(i => i.Products.Count()).ToListAsync();
            }
        }

        public async Task SetActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Category>().Where(i => i.Id == id).FirstOrDefault();
                active.IsApproved = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var active = context.Set<Category>().Where(i => i.Id == id).FirstOrDefault();
                active.IsApproved = false;
                await context.SaveChangesAsync();
            }
        }
    }
}
