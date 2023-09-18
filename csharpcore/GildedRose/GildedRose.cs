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
            UpdateQuality(item);
        }
    }

    private void UpdateQuality(Item item)
    {
        if (item.Name == itemsConstants.SULFURAS)
        {
            return;
        }

        if (item.Name == itemsConstants.AGED_BRIE)
        {
            IncreaseQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
        else if (item.Name == itemsConstants.BACKSTAGE_PASSES)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
                if (item.SellIn < 11)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncreaseQuality(item);
                }
            }
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
        else if (item.Name == "Conjured")
        {
            DecreaseQuality(item);
            DecreaseQuality(item);
            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
                DecreaseQuality(item);
            }
        }
        else // default items.
        {
            DecreaseQuality(item);
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }
    }

    private void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }
}
