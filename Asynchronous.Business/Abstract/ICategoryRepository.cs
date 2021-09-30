using Asynchronous.Core.DataAccess;
using Asynchronous.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Business.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        Task<List<Category>> GetAllIncluding();
        Task SetActive(int id);
        Task SetDeActive(int id);
    }
}
