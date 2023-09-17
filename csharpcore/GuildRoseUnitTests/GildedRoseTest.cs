using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void TestEmptyListOfItem()
    {
        List<Item> items = new();
        GildedRose app = new(items);

        Assert.Pass();
    }

    [Test]
    public void TestListOfOneItem()
    {
        List<Item> items = new()
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
        };
        GildedRose app = new(items);

        Assert.That(items.Count == 1);
        Assert.That(items[0].Name == "+5 Dexterity Vest");
        Assert.That(10, Is.EqualTo(items[0].SellIn));
        Assert.That(20, Is.EqualTo(items[0].Quality));
    }

    [Test]
    public void TestListOfOneItemOneDay()
    {
        List<Item> items = new()
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
        };
        GildedRose app = new(items);
        app.UpdateQuality();

        Assert.That("+5 Dexterity Vest" == items[0].Name);
        Assert.That(9, Is.EqualTo(items[0].SellIn));
        Assert.That(19, Is.EqualTo(items[0].Quality));
    }
}