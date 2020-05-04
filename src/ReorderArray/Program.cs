using System;
using System.Linq;

namespace ReorderArray
{
    public class Program
    {
        /// <summary>
        /// Reorder a given array of integers:
        /// place all even numbers at the beginning
        /// place all odd numbers at the end
        /// </summary>
        public static void Main()
        {
            var numbers = new int[] { 3, 5, 1, 4, 6, 7, 9, 12, 8, 13 };
            ReorderInPlace(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static int[] Reorder(int[] numbers)
        {
            var even = numbers.Where(n => n % 2 == 0).ToArray();
            var odd = numbers.Where(n => n % 2 != 0).ToArray();

            var resultingArray = new int[numbers.Length];
            Array.Copy(even, 0, resultingArray, 0, even.Length);
            Array.Copy(odd, 0, resultingArray, even.Length, odd.Length);

            return resultingArray;
        }

        // TODO: Review logic -> not working properly
        private static void ReorderInPlace(int[] numbers)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                if (numbers[left] % 2 != 0 && numbers[right] % 2 == 0)
                {
                    numbers[left] ^= numbers[right];
                    numbers[right] ^= numbers[left];
                    numbers[left] ^= numbers[right];
                }

                left++;
                right--;
            }
        }
    }
}
