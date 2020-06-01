using System;
using System.Collections.Generic;
using System.Linq;

namespace BetweenTwoSets
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();

            var a = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
            var b = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));

            var result = GetBetweenTwoSets(a, b);
            Console.WriteLine(result.Count()); ;
        }

        /// <summary>
        /// The elements of the first array are all factors of the integer being considered.
        /// The integer being considered is a factor of all elements of the second array.
        /// </summary>
        /// <param name="a">First set.</param>
        /// <param name="b">Second set.</param>
        /// <returns></returns>
        private static IEnumerable<int> GetBetweenTwoSets(int[] a, int[] b)
        {
            var betweenTwoSets = new List<int>();

            var factor = 1;
            foreach (var number in a)
            {
                factor = GetLCM(factor, number);
            }

            var multiple = 0;
            foreach (var number in b)
            {
                multiple = GetGCD(multiple, number);
            }

            if (multiple % factor == 0)
            {
                for (int i = factor; i <= multiple; i++)
                {
                    if (i % factor == 0 && multiple % i == 0)
                    {
                        betweenTwoSets.Add(i);
                    }
                }
            }

            return betweenTwoSets;
        }

        public static int GetLCM(int a, int b)
        {
            return a / GetGCD(a, b) * b;
        }

        private static int GetGCD(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a >= b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }
    }
}
