using System;
using System.IO;
using System.Text;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Test]
    public void TestThirtyDaysPlus5DexterityVest()
    {
        // Arranges
        List<Item> items = new()
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
        };
        GildedRose app = new(items);

        // Actions
        for (int i = 0; i < 30; i++)
        {
            app.UpdateQuality();
        }

        // Asserts
        Assert.That("+5 Dexterity Vest" == items[0].Name);
        Assert.That(-20, Is.EqualTo(items[0].SellIn));
        Assert.That(0, Is.EqualTo(items[0].Quality));
    }

    [Test]
    public void TestThirtyDaysAgedBrie()
    {
        // Arranges
        List<Item> items = new()
        {
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }
        };
        GildedRose app = new(items);

        // Actions
        for (int i = 0; i < 30; i++)
        {
            app.UpdateQuality();
        }

        // Asserts
        Assert.That("Aged Brie" == items[0].Name);
        Assert.That(-28, Is.EqualTo(items[0].SellIn));
        Assert.That(50, Is.EqualTo(items[0].Quality));
    }
    
    [TestCase(itemsConstants.PLUS_5_DEXTERITY_VEST, 10, 20, -20, 0)]
    [TestCase(itemsConstants.AGED_BRIE, 2, 0, -28, 50)]
    [TestCase(itemsConstants.ELIXIR_OF_MONGOOSE, 5, 7, -25, 0)]
    [TestCase(itemsConstants.SULFURAS, 0, 80, 0, 80)]
    [TestCase(itemsConstants.SULFURAS, -1, 80, -1, 80)]
    [TestCase(itemsConstants.BACKSTAGE_PASSES, 15, 20, -15, 0)]
    [TestCase(itemsConstants.BACKSTAGE_PASSES, 10, 49, -20, 0)]
    [TestCase(itemsConstants.BACKSTAGE_PASSES, 5, 49, -25, 0)]
    public void TestThirtyDaysForAllItem(string itemName, int initialSellIn, int initialQuality,
        int endSellin, int endQuality)
    {
        // Arranges
        List<Item> items = new()
        {
            new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality }
        };
        GildedRose app = new(items);

        // Actions
        for (int i = 0; i < 30; i++)
        {
            app.UpdateQuality();
        }

        // Asserts
        Assert.That(itemName == items[0].Name);
        Assert.That(endSellin, Is.EqualTo(items[0].SellIn));
        Assert.That(endQuality, Is.EqualTo(items[0].Quality));
    }
}