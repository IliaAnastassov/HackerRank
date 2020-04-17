using System;
using System.Collections.Generic;

namespace TwoStrings
{
    public class Program
    {
        public static void Main()
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            var result = s1.HasCommonSubstring(s2);
            Console.WriteLine(result);
        }
    }

    public static class StringExtensions
    {
        public static bool HasCommonSubstring(this string value1, string value2)
        {
            var set1 = new HashSet<char>(value1);
            var set2 = new HashSet<char>(value2);
            
            set1.IntersectWith(set2);

            return set1.Count > 0 ? true : false;
        }
    }
}
