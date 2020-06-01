using System;
using System.Linq;

namespace ArrayManipulation
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            var arraySize = Convert.ToInt32(input[0]);
            var operationsCount = Convert.ToInt32(input[1]);

            var queries = new int[operationsCount][];

            for (int i = 0; i < operationsCount; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            long result = ArrayManipulationOptimized(arraySize, queries);
        }

        /// <summary>
        /// 10 2
        /// 1 5 3
        /// 4 8 7
        ///  1   2   3   4   5   6   7   8   9   10
        ///[ 0   0   0   0   0   0   0   0   0   0 ]
        ///[ 3   3   3   3   3   0   0   0   0   0 ]
        ///[ 3   3   3   10  10  7   7   7   0   0 ]
        /// </summary>
        private static long ArrayManipulationBruteForce(int arraySize, int[][] queries)
        {
            var numbers = new long[arraySize];

            int firstIndex, lastIndex, valueToAdd;
            foreach (var query in queries)
            {
                firstIndex = query[0] - 1;
                lastIndex = query[1] - 1;
                valueToAdd = query[2];

                for (int i = firstIndex; i <= lastIndex; i++)
                {
                    numbers[i] += valueToAdd;
                }
            }

            return numbers.Max();
        }

        /// <summary>
        /// 10 3
        /// 1 5 3
        /// 4 8 7
        /// 5 10 4
        ///  1   2   3   4   5   6   7   8   9   10 (11)
        ///[ 0   0   0   0   0   0   0   0   0   0   0 ]
        ///[ 3   0   0   0   0  -3   0   0   0   0   0 ]
        ///[ 3   0   0   7   0  -3   0   0  -7   0   0 ]
        ///[ 3   0   0   7   4  -3   0   0  -7   0  -4 ]
        /// </summary>
        private static long ArrayManipulationOptimized(int arraySize, int[][] queries)
        {
            var numbers = new long[arraySize + 1];

            int firstIndex, lastIndex, valueToAdd;
            foreach (var query in queries)
            {
                firstIndex = query[0] - 1;
                lastIndex = query[1];
                valueToAdd = query[2];

                numbers[firstIndex] += valueToAdd;
                numbers[lastIndex] -= valueToAdd;
            }

            var maxSum = 0L;
            var currentSum = 0L;
            foreach (var number in numbers)
            {
                currentSum += number;
                maxSum = Math.Max(currentSum, maxSum);
            }

            return maxSum;
        }
    }
}
