using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class RegularProductHandler : ProductHandlerBase, IProductHandler
    {
        public string ProductName()
        {
            return REGULAR_PRODUCT_KEY;
        }

        public void Update(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality--;
            }

            item.Quality = Constrain(item.Quality, MIN_QUALITY, MAX_QUALITY);
        }
    }
}
