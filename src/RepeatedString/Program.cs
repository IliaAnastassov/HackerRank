using System;
using System.Linq;

namespace RepeatedString
{
    class Program
    {
        static void Main()
        {
            string s = Console.ReadLine();
            long n = Convert.ToInt64(Console.ReadLine());

            long result = RepeatedString(s, n);

            Console.WriteLine(result);
        }

        private static long RepeatedString(string s, long n)
        {
            long totalCount = 0;

            var countInWord = s.Where(c => c.Equals('a')).Count();
            var wordLength = s.Count();

            if (n < wordLength)
            {
                totalCount = s.Substring(0, (int)n).Where(c => c.Equals('a')).Count();
            }
            else if (n > wordLength)
            {
                var repetitionCount = n / wordLength;
                totalCount = repetitionCount * countInWord;

                if (n % wordLength != 0)
                {
                    var lastSubstring = s.Substring(0, (int)(n % wordLength));
                    totalCount += lastSubstring.Where(c => c.Equals('a')).Count();
                }
            }
            else
            {
                totalCount = countInWord;
            }

            return totalCount;
        }
    }
}
