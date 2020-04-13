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
            var gcd = GetGcd(numbers.Length, rotationsCount);

            int i, j, k, temp;
            for (i = 0; i < gcd; i++)
            {
                temp = numbers[i];
                j = i;
                while (true)
                {
                    k = j + rotationsCount;
                    if (k >= numbers.Length)
                    {
                        k -= numbers.Length;
                    }
                    if (k == i)
                    {
                        break;
                    }
                    numbers[j] = numbers[k];
                    j = k;
                }

                numbers[j] = temp;
            }
        }

        private static int GetGcd(int val1, int val2)
        {
            if (val2 == 0)
            {
                return val1;
            }

            return GetGcd(val2, val1 % val2);
        }
    }
}
