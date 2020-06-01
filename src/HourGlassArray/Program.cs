using System;
using System.Collections.Generic;
using System.Linq;

namespace HourglassSum
{
    public class Program
    {
        static void Main()
        {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(), s => Convert.ToInt32(s));
            }

            int result = HourglassSum(arr);
        }

        private static int HourglassSum(int[][] arr)
        {
            var hourglassSums = new List<int>();
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j < arr.Length - 2; j++)
                {
                    var sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                            + arr[i + 1][j + 1]
                            + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

                    hourglassSums.Add(sum);
                }
            }

            return hourglassSums.Max();
        }
    }
}
