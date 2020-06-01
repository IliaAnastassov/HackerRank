using System;

namespace Kangaroo
{
    public class Program
    {
        public static void Main()
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));
            var x1 = input[0];
            var v1 = input[1];
            var x2 = input[2];
            var v2 = input[3];

            bool result = CanLandOnSameLocation(x1, v1, x2, v2);

            Console.WriteLine(result ? "YES" : "NO");
        }

        /// <summary>
        /// n*v1 + x1 = n*v2 + x2
        /// n*v1 - n*v2 = x2 - x1
        /// n(v1 - v2) = x2 - x1
        /// n = (x2 - x1) / (v1 - v2)
        /// Since "x1 < x2", if n is a whole number, then the two kangaroos can land on the same location
        /// </summary>
        /// <param name="x1">Kangaroo 1 starting position.</param>
        /// <param name="v1">Kangaroo 1 jump distance.</param>
        /// <param name="x2">Kangaroo 2 starting position.</param>
        /// <param name="v2">Kangaroo 2 jump distance.</param>
        /// <returns></returns>
        private static bool CanLandOnSameLocation(int x1, int v1, int x2, int v2)
        {
            // since x1 < x2, if v1 <= v2, they can never land on the same location
            if (v1 <= v2)
            {
                return false;
            }

            return (x2 - x1) % (v1 - v2) == 0;
        }
    }
}
