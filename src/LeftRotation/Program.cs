using System;
using System.Linq;

namespace LeftRotation
{
    class Program
    {
        static void Main()
        {
            var rotationsCount = Convert.ToInt32(Console.ReadLine());

            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), n => Convert.ToInt32(n));
            RotateLeftOptimized(numbers, rotationsCount);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void RotateLeft(int[] numbers, int rotationsCount)
        {
            for (int i = 0; i < rotationsCount; i++)
            {
                numbers = numbers.Skip(1).Append(numbers[0]).ToArray();
            }
        }

        private static void RotateLeftOptimized(int[] numbers, int rotationsCount)
        {
            if (rotationsCount % numbers.Length == 0)
            {
                return;
            }
            else if (rotationsCount > numbers.Length)
            {
                rotationsCount %= numbers.Length;
            }

            var rotated = new int[numbers.Length];

            Array.Copy(numbers, 0, rotated, numbers.Length - rotationsCount, rotationsCount);
            Array.Copy(numbers, rotationsCount, rotated, 0, numbers.Length - rotationsCount);

            rotated.CopyTo(numbers, 0);
        }
    }
}
