using System;

namespace BirthdayChocolate
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();

            var chocolate = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));
            var dm = Console.ReadLine().Trim().Split();
            var day = int.Parse(dm[0]);
            var month = int.Parse(dm[1]);

            var result = GetWaysCount(chocolate, day, month);
            Console.WriteLine(result);
        }

        private static int GetWaysCount(int[] chocolate, int day, int month)
        {
            var count = 0;
            var sum = 0;

            for (int i = 0; i < chocolate.Length; i++)
            {
                sum += chocolate[i];

                if (i >= month)
                {
                    // we keep only the sum of the last "month" elements
                    sum -= chocolate[i - month];
                }

                if (sum == day && i >= month - 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
