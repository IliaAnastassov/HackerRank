using System;
using System.Collections.Generic;

namespace ReverseArray
{
    public class Program
    {
        public static void Main()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            ReverseInPlaceV2(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        public static IEnumerable<int> Reverse(int[] numbers)
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                yield return numbers[i];
            }
        }

        public static void ReverseInPlaceV1(int[] numbers)
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

        public static void ReverseInPlaceV2(int[] numbers)
        {
            ReverseInPlaceRecursive(numbers, 0, numbers.Length - 1);
        }

        private static void ReverseInPlaceRecursive(int[] numbers, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            numbers[left] ^= numbers[right];
            numbers[right] ^= numbers[left];
            numbers[left] ^= numbers[right];

            ReverseInPlaceRecursive(numbers, ++left, --right);
        }
    }
}
