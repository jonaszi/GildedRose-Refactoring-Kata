using csharp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class ProductUpdater
    {
        private Dictionary<string, IProductHandler> handlers = new Dictionary<string, IProductHandler>();

        public ProductUpdater()
        {
            RegisterHandler(new RegularProductHandler());
            RegisterHandler(new AgedBrieHandler());
            RegisterHandler(new BackstagePassHandler());
            RegisterHandler(new SulfurasPassHandler());
            RegisterHandler(new ConjuredProductHandler());
        }

        public void Update(Item item)
        {
            if (handlers.ContainsKey(item.Name))
                handlers[item.Name].Update(item);
            else
                handlers[ProductHandlerBase.REGULAR_PRODUCT_KEY].Update(item);
        }

        private void RegisterHandler(IProductHandler handler)
        {
            handlers.Add(handler.ProductName(), handler);
        }
    }
}
