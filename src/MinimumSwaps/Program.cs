using System;

namespace MinimumSwaps
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            var result = GetMinimumSwapsOptimized(numbers);
        }

        /// <summary>
        /// 7 1 3 2 4 5 6
        /// </summary>
        private static int GetMinimumSwaps(int[] numbers)
        {
            var swapsCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var localMin = numbers[i];
                var localMinIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < localMin)
                    {
                        localMin = numbers[j];
                        localMinIndex = j;
                    }
                }

                if (localMinIndex != i)
                {
                    Swap(numbers, i, localMinIndex);
                    swapsCount++;
                }
            }

            return swapsCount;
        }

        /// <summary>
        /// 7 1 3 2 4 5 6
        /// </summary>
        private static int GetMinimumSwapsOptimized(int[] numbers)
        {
            var swapsCount = 0;

            var i = 0;
            while (i < numbers.Length - 1)
            {
                while (numbers[i] == i + 1 && i < numbers.Length - 1)
                {
                    i++;
                }

                if (i < numbers.Length - 1)
                {
                    Swap(numbers, i, numbers[i] - 1);
                    swapsCount++;
                }
            }

            return swapsCount;
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            array[index1] ^= array[index2];
            array[index2] ^= array[index1];
            array[index1] ^= array[index2];
        }
    }
}
