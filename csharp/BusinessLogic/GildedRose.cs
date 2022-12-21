using csharp.BusinessLogic;
using csharp.Entity;
using System.Collections.Generic;

namespace csharp.BusinessLogic
{
    public class GildedRose
    {
        IList<Item> Items;
        ProductUpdater productUpdater;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            productUpdater = new ProductUpdater();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                productUpdater.Update(item);
            }
            
        }
    }
}
