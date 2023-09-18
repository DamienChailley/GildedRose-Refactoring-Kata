using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    internal static class ConsoleTabHelper
    {
        public static string getPadRightString(string str, int nbSpace = 42)
        {
            return str.PadRight(nbSpace, ' ');
        }
    }
}
