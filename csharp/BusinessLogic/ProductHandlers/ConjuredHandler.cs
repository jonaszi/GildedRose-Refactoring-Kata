using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class ConjuredProductHandler : ProductHandlerBase, IProductHandler
    {
        public string ProductName()
        {
            return PRODUCT_CONJURED;
        }

        public void Update(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality -= 4;
            }
            else
            {
                item.Quality -= 2;
            }

            item.Quality = Constrain(item.Quality, MIN_QUALITY, MAX_QUALITY);
        }
    }
}
