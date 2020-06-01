using System;

namespace BreakingTheRecords
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();

            var scores = Array.ConvertAll(Console.ReadLine().Split(), s => int.Parse(s));

            var records = GetBreakingRecords(scores);
            Console.WriteLine(string.Join(" ", records));
        }

        private static int[] GetBreakingRecords(int[] scores)
        {
            var min = scores[0];
            var max = scores[0];
            var minRecordCount = 0;
            var maxRecordCount = 0;

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < min)
                {
                    minRecordCount++;
                    min = scores[i];
                }
                else if (scores[i] > max)
                {
                    maxRecordCount++;
                    max = scores[i];
                }
            }

            return new int[] { maxRecordCount, minRecordCount };
        }
    }
}
