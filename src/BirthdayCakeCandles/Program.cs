using System;
using System.Linq;

namespace BirthdayCakeCandles
{
    public class Program
    {
        public static void Main()
        {
            var candles = new int[] { 4, 4, 1, 3 };
            var result = BirthdayCakeCandles(candles);

            Console.WriteLine(result);
        }

        private static int BirthdayCakeCandles(int[] candles)
        {
            var count = 1;

            if (candles.Length > 1)
            {
                // sort the array (O(n log n)
                Array.Sort(candles);

                for (int i = candles.Length - 2; i >= 0; i--)
                {
                    // compare value with last (greatest) element
                    if (candles[i] == candles[^1])
                    {
                        count++;
                    }
                    else
                    {
                        // no point of going further since the array is sorted
                        break;
                    }
                }
            }

            return count;
        }

        private static int BirthdayCakeCandlesV2(int[] candles)
        {
            var max = candles.Max();
            return candles.Count(c => c == max);
        }

    }
}
