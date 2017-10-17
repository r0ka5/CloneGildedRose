using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void TestBasicQuality()
        {
            var _program = new Program();
            _program.Items = new List<Item>() {new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 19);
        }

        [Fact]
        public void TestBasicQualityNegativeSellIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 18);
        }

        [Fact]
        public void TestBasicSellIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].SellIn, 9);
        }

        [Fact]
        public void TestAgedBrieQuality()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 1);
        }

        [Fact]
        public void TestAgedBrieSellIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].SellIn, 1);
        }

        [Fact]
        public void TestSulfurasQuality()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 80);
        }

        [Fact]
        public void TestSulfurasSellIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].SellIn, 0);
        }

        [Fact]
        public void TestBackstageQuality()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 21);
        }

        [Fact]
        public void TestBackstageQualityNegativeSelIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = -1,
                                                      Quality = 20
                                                  } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 0);
        }

        [Fact]
        public void TestBackstageSellIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].SellIn, 14);
        }

        [Fact]
        public void TestConjuredSellIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].SellIn, 2);
        }

        [Fact]
        public void TestConjuredQuality()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 4);
        }

        [Fact]
        public void TestConjuredQualityWithNegativeSelIn()
        {
            var _program = new Program();
            _program.Items = new List<Item>() { new Item { Name = "Conjured Mana Cake", SellIn = -2, Quality = 6 } };
            _program.UpdateQuality();
            Assert.Equal(_program.Items[0].Quality, 2);
        }

    }
}