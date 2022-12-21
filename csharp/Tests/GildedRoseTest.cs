using csharp.BusinessLogic;
using csharp.Entity;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        const string REGULAR_PRODUCT = "product with default handling";

        [Test]
        public void GR_Test_RegularProduct_LowerBothValuesEachDay()
        {
            IList<Item> Items = CreateProduct(REGULAR_PRODUCT, 10, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void GR_Test_Conjured_LowerQualityBy2()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_CONJURED, 10, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void GR_Test_AgedBrie_IncreaseQualityDecreaseSellInEachDay()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_AGED_BRIE, 10, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void GR_Test_BackstagePass_IncreaseQualityDecreaseSellInEachDay()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_BACKSTAGE_PASS, 20, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
            Assert.AreEqual(19, Items[0].SellIn);
        }

        [Test]
        public void GR_Test_BackstagePass_IncreaseQualityBy2If10daysEachDay()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_BACKSTAGE_PASS, 10, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(12, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void GR_Test_BackstagePass_IncreaseQualityBy3If5daysEachDay()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_BACKSTAGE_PASS, 5, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(13, Items[0].Quality);
            Assert.AreEqual(4, Items[0].SellIn);
        }

        [Test]
        public void GR_Test_Sulfuras_QualityAlways80SellInUnchanged()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_SULFURAS, 10, 80);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            Assert.AreEqual(10, Items[0].SellIn);
        }

        [Test]
        public void GR_Test_RegularProduct_QualityDegradesTwiceFasterAfterSellDate()
        {
            IList<Item> Items = CreateProduct(REGULAR_PRODUCT, 0, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void GR_Test_Conjured_QualityDegradesTwiceFasterAfterSellDate()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_CONJURED, 0, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test]
        public void GR_Test_AgedBrie_QualityIncreasesTwiceFasterAfterSellDate()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_AGED_BRIE, 0, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void GR_Test_BackstagePass_Quality0AfterConcert()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_BACKSTAGE_PASS, 0, 10);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void GR_Test_RegularProduct_QualityNeverNegative()
        {
            IList<Item> Items = CreateProduct(REGULAR_PRODUCT, 0, 0);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.LessOrEqual(0, Items[0].Quality);
        }

        [Test]
        public void GR_Test_BackstagePass_QualityNeverNegative()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_BACKSTAGE_PASS, 0, 0);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.LessOrEqual(0, Items[0].Quality);
        }

        [Test]
        public void GR_Test_AgedBrie_QualityNeverAbove50()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_AGED_BRIE, 10, 50);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.LessOrEqual(50, Items[0].Quality);
        }

        [Test]
        public void GR_Test_BackstagePass_QualityNeverAbove50()
        {
            IList<Item> Items = CreateProduct(ProductHandlerBase.PRODUCT_BACKSTAGE_PASS, 10, 50);
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.LessOrEqual(50, Items[0].Quality);
        }

        IList<Item> CreateProduct(string name, int sellIn, int quality)
        {
            return new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        }
    }
}
