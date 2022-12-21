using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class SulfurasPassHandler : ProductHandlerBase, IProductHandler
    {
        public string ProductName()
        {
            return PRODUCT_SULFURAS;
        }

        public void Update(Item item)
        {
            /* Do nothing */
        }
    }
}
