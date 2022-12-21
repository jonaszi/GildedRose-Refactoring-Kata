using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class AgedBrieHandler : ProductHandlerBase, IProductHandler
    {
        public string ProductName()
        {
            return PRODUCT_AGED_BRIE;
        }

        public void Update(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality++;
            }

            item.SellIn--;

            item.Quality = Constrain(item.Quality, MIN_QUALITY, MAX_QUALITY);
        }
    }
}
