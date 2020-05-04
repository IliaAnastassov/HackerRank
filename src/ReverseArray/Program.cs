using System;
using System.Collections.Generic;

namespace ReverseArray
{
    public class Program
    {
        public static void Main()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            ReverseInPlace(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        public static void ReverseInPlace(int[] numbers)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                numbers[left] ^= numbers[right];
                numbers[right] ^= numbers[left];
                numbers[left] ^= numbers[right];

                left++;
                right--;
            }
        }

        public static IEnumerable<int> Reverse(int[] numbers)
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                yield return numbers[i];
            }
        }
    }
}
