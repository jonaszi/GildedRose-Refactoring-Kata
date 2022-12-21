using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    interface IProductHandler
    {
        void Update(Item item);
        string ProductName();
    }
}
