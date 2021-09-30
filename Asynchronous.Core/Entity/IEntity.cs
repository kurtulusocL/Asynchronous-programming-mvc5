using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.Core.Entity
{
    public interface IEntity
    {
        void SetCreatedDate();
        void SetApproved();
    }
}
