using System;
using System.Collections.Generic;

namespace CountTriplets
{
    public class Program
    {
        public static void Main()
        {
            var commonRatio = int.Parse(Console.ReadLine());
            var numbers = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));

            var tripletsCount = CountTriplets(numbers, commonRatio);
            Console.WriteLine(tripletsCount);
        }

        /// <summary>
        /// 1 2 2 4         -> 2
        /// 1 5 5 25 125    -> 4
        /// 1 3 9 9 27 81   -> 6
        /// 1 2 1 2 4       -> 3
        /// </summary>
        private static int CountTriplets(int[] numbers, int ratio)
        {
            var duplets = new Dictionary<int, int>();
            var triplets = new Dictionary<int, int>();
            var tripletsCount = 0;

            foreach (var number in numbers)
            {
                if (triplets.ContainsKey(number))
                {
                    tripletsCount += triplets[number];
                }

                if (duplets.ContainsKey(number))
                {
                    if (!triplets.ContainsKey(number * ratio))
                    {
                        triplets.Add(number * ratio, duplets[number]);
                    }
                    else
                    {
                        triplets[number * ratio] += duplets[number];
                    }
                }

                if (!duplets.ContainsKey(number * ratio))
                {
                    duplets.Add(number * ratio, 1);
                }
                else
                {
                    duplets[number * ratio]++;
                }
            }

            return tripletsCount;
        }
    }
}
