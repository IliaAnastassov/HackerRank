using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicSquare
{
    public class Program
    {
        public static void Main()
        {
            var s = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                s[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));
            }

            var result = FormMagicSquare(s);
            Console.WriteLine(result);
        }

        /// <summary>
        /// i  
        /// 0   5 3 4
        /// 1   1 5 8
        /// 2   6 4 2
        ///   j 0 1 2
        /// </summary>
        private static int FormMagicSquare(int[][] square)
        {
            var cost = 0;
            var frequencyMap = new int[10];
            var sums = new Dictionary<int, int>();

            for (int i = 0; i < 3; i++)
            {
                // store the sum of the rows as keys [1 2 3]
                sums[i + 1] = square[i].Sum();

                for (int j = 0; j < 3; j++)
                {
                    // store the sum of the cols as keys [4 5 6]
                    sums[i + 3] += square[j][i];

                    if (i == j)
                    {
                        // store the sum of the principal diagonal as key 7
                        sums[7] += square[i][j];
                    }
                    if (i + j == 2) // since (i + j) == (n - 1) and n = 3 in our case
                    {
                        // store the sum of secondary diagonal as key 8
                        sums[8] += square[i][j];
                    }

                    // store the frequency of each element
                    frequencyMap[square[i][j]]++;
                }
            }

            return cost;
        }
    }
}
