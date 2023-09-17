using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            if (item.Name != itemsConstants.AGED_BRIE && item.Name != itemsConstants.BACKSTAGE_PASSES)
            {
                if (item.Quality > 0 && item.Name != itemsConstants.SULFURAS)
                {
                    DecreaseQuality(item, 1);
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;

                    if (item.Name == itemsConstants.BACKSTAGE_PASSES && item.Quality < 50)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality += 1;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }

            UpdateSellin(item);

            if (item.SellIn < 0)
            {
                if (item.Name != itemsConstants.AGED_BRIE)
                {
                    if (item.Name != itemsConstants.BACKSTAGE_PASSES)
                    {
                        if (item.Quality > 0 && item.Name != itemsConstants.SULFURAS)
                        {
                            DecreaseQuality(item,1);
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }

    private void UpdateSellin(Item item)
    {
        if (item.Name != itemsConstants.SULFURAS)
        {
            item.SellIn -= 1;
        }
    }

    private void DecreaseQuality(Item item, int nbToRemove)
    {
        int multiply = item.Name.Contains("Conjured") ? 2 : 1;
        item.Quality -= nbToRemove * multiply;
    }
}