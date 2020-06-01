using System;
using System.Linq;

namespace AppleAndOrange
{
    public class Program
    {
        /// <summary>
        /// 7 11
        /// 5 15
        /// 3 2
        /// -2 2 1
        /// 5 -6
        /// </summary>
        public static void Main()
        {
            var houseDimensions = Console.ReadLine().Split();
            var houseStart = Convert.ToInt32(houseDimensions[0]);
            var houseEnd = Convert.ToInt32(houseDimensions[1]);

            var treePositions = Console.ReadLine().Split();
            var appleTree = Convert.ToInt32(treePositions[0]);
            var orangeTree = Convert.ToInt32(treePositions[1]);

            var applesOrangesCount = Console.ReadLine();

            var apples = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
            var oranges = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));

            var result = CountApplesAndOranges(houseStart, houseEnd, appleTree, orangeTree, apples, oranges);

            Console.WriteLine(result.Item1);
            Console.WriteLine(result.Item2);
        }

        private static (int, int) CountApplesAndOranges(int houseStart, int houseEnd, int appleTree, int orangeTree, int[] apples, int[] oranges)
        {
            var applesCount = apples.Count(a => houseStart <= appleTree + a && appleTree + a <= houseEnd);
            var orangesCount = oranges.Count(o => houseStart <= orangeTree + o && orangeTree + o <= houseEnd);

            return (applesCount, orangesCount);
        }
    }
}
