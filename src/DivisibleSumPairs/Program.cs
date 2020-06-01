using System;

namespace DivisibleSumPairs
{
    public class Program
    {
        public static void Main()
        {
            var k = int.Parse(Console.ReadLine().Trim().Split()[1]);
            var numbers = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));

            var result = GetNumberOfPairs(numbers, k);
            Console.WriteLine(result);
        }

        private static int GetNumberOfPairs(int[] numbers, int k)
        {
            var count = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if ((numbers[i] + numbers[j]) % k == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
