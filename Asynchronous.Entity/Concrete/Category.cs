using Asynchronous.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Entity.Concrete
{
    public class Category : BaseEntity
    {
        [Required] //If you want you can fluent validation in BusinessLayer thenit wont need this validation.
       public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
