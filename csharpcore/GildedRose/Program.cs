// See https://aka.ms/new-console-template for more information
using GildedRoseKata;
using System.Collections.Generic;
using System;

Console.WriteLine("OMGHAI!");

IList<Item> items = new List<Item> {
    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
    new Item
    {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 15,
        Quality = 20
    },
    new Item
    {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 10,
        Quality = 49
    },
    new Item
    {
        Name = "Backstage passes to a TAFKAL80ETC concert",
        SellIn = 5,
        Quality = 49
    },
    // this conjured item does not work properly yet
    // new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
    // };
};

GildedRose app = new GildedRose(items);

int days = 31;
if (args.Length > 0)
{
    days = int.Parse(args[0]) + 1;
}

for (var i = 0; i < days; i++)
{
    Console.WriteLine("\t-------- day " + i + " --------");
    Console.WriteLine("name\t\t\t\t\t  | sellIn | quality");
    for (var j = 0; j < items.Count; j++)
    {
        Console.WriteLine(ConsoleTabHelper.getPadRightString(items[j].Name) + ", "
            + ConsoleTabHelper.getPadRightString(items[j].SellIn.ToString(),8)   + ", "
            + ConsoleTabHelper.getPadRightString(items[j].Quality.ToString(),8));
    }
    Console.WriteLine("");
    app.UpdateQuality();
}
