using System.Collections.Generic;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {

            foreach (var item in items)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }
            }

            foreach (var item in items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros") {}
                else
                {
                    if (item.Name == "Aged Brie")
                    {
                        if (item.SellIn > 0)
                        {
                            item.Quality++;
                        }
                        else
                        {
                            item.Quality += 2;
                        }
                    }
                    else
                    {
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn <= 0)
                            {
                                item.Quality = 0;
                            }
                            else if (item.SellIn <= 5 && item.SellIn > 0)
                            {
                                item.Quality += 3;
                            }
                            else if (item.SellIn <= 10 && item.SellIn > 5)
                            {
                                item.Quality += 2;
                            }
                            else
                            {
                                item.Quality++;
                            }
                        }
                        else
                        {
                            if (item.Name.Contains("Conjured") && item.SellIn > 0)
                            {
                                item.Quality -= 2;
                            }
                            else if (item.Name.Contains("Conjured") && item.SellIn <= 0)
                            {
                                item.Quality -= 4;
                            }
                            else
                            {
                                if (item.SellIn <= 0)
                                {
                                    item.Quality -= 2;
                                }
                                else
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                    }
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }

                if (item.Quality > 50 && item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = 50;
                }

            }
        }
    }
}

