using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.BusinessLogic
{
    class ProductHandlerBase
    {
        public const string PRODUCT_AGED_BRIE = "Aged Brie";
        public const string PRODUCT_BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
        public const string PRODUCT_SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string PRODUCT_CONJURED = "Conjured Mana Cake";

        public const string REGULAR_PRODUCT_KEY = "";

        public const int MIN_QUALITY = 0;
        public const int MAX_QUALITY = 50;

        public const int BACKSTAGE_DAYS_PLUS2 = 10;
        public const int BACKSTAGE_DAYS_PLUS3 = 5;

        protected static int Constrain(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
