using System;
using System.Linq;

namespace RepeatedString
{
    class Program
    {
        static void Main()
        {
            string s = "abcac";
            long n = 10;

            long result = RepeatedString(s, n);

            Console.WriteLine(result);
        }

        private static long RepeatedString(string repeatedString, long length)
        {
            var countInRepeatedString = 0;
            var repetitionsCount = length / repeatedString.Length;
            var countInRemaining = 0;
            var remainingLenght = length % repeatedString.Length;

            for (int i = 0; i < repeatedString.Length; i++)
            {
                if (repeatedString[i] == 'a')
                {
                    countInRepeatedString++;

                    if (i < remainingLenght)
                    {
                        countInRemaining++;
                    }
                }
            }

            var totalCount = countInRepeatedString * repetitionsCount + countInRemaining;

            return totalCount;
        }

        private static long RepeatedStringOptimized(string repeatedString, long length)
        {
            var countInRepeatedString = repeatedString.Count(c => c == 'a');
            var repetitionsCount = length / repeatedString.Length;
            var totalCount = countInRepeatedString * repetitionsCount;

            var remainingLenght = length % repeatedString.Length;
            if (remainingLenght > 0)
            {
                totalCount += repeatedString.Substring(0, (int)remainingLenght).Count(c => c == 'a');
            }

            return totalCount;
        }

    }
}
