using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class BackstagePassHandler : ProductHandlerBase, IProductHandler
    {
        public string ProductName()
        {
            return PRODUCT_BACKSTAGE_PASS;
        }

        public void Update(Item item)
        {
            if (item.SellIn <= BACKSTAGE_DAYS_PLUS3)
            {
                item.Quality += 3;
            }
            else if (item.SellIn <= BACKSTAGE_DAYS_PLUS2)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality++;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }

            item.SellIn--;
            item.Quality = Constrain(item.Quality, MIN_QUALITY, MAX_QUALITY);
        }
    }
}
