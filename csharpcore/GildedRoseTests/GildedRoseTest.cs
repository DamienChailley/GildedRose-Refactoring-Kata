using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void TestEmptyListOfItem()
    {
        List<Item> items = new();
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Pass();
    }
}