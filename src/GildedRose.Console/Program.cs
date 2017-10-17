using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            app.UpdateQuality();


            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var UpdFactory = new UpdateFactory().Create(item);
                UpdFactory.UpdateItem(item);
            }
        }

    }

    public class UpdateFactory
    {
        public IUpdate Create(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new UpdateAgedBrie();
                case "Sulfuras, Hand of Ragnaros":
                    return new UpdateSulfuras();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new UpdateBackstage();
                case "Conjured Mana Cake":
                    return new UpdateConjured();
                default:
                    return new UpdateNormal();
            }
        }
    }

    public interface IUpdate
    {
        void UpdateItem(Item itm);
    }

    public class BaseUpdate : IUpdate
    {
        public virtual void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }

    public class UpdateNormal: BaseUpdate
    {
        public override void UpdateItem(Item itm)
        {
            if (itm.Quality > 0)
            {
                itm.Quality--;
                if (itm.SellIn < 0)
                    itm.Quality--;
            }
            base.UpdateItem(itm);
        }
    }

    public class UpdateAgedBrie : BaseUpdate
    {
        public override void UpdateItem(Item itm)
        {
            if (itm.Quality <50)
            {
                itm.Quality++;
            }

            base.UpdateItem(itm);

            if (itm.Quality < 50 && itm.SellIn < 0)
                itm.Quality++;
        }
    }

    public class UpdateSulfuras : BaseUpdate
    {
        public override void UpdateItem(Item itm)
        {
        }
    }

    public class UpdateBackstage : BaseUpdate
    {
        public override void UpdateItem(Item item)
        {
            item.Quality++;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            base.UpdateItem(item);

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }
    }

    public class UpdateConjured : BaseUpdate
    {
        public override void UpdateItem(Item itm)
        {
            if (itm.Quality < 50)
            {
                itm.Quality = itm.Quality - 2;
                if (itm.SellIn < 0)
                    itm.Quality = itm.Quality - 2;
            }
            base.UpdateItem(itm);
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
