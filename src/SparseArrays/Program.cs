using System;
using System.Collections.Generic;

namespace SparseArrays
{
    public class Program
    {
        public static void Main()
        {
            var inputStringsSize = int.Parse(Console.ReadLine());
            var inputStrings = new string[inputStringsSize];

            for (int i = 0; i < inputStringsSize; i++)
            {
                inputStrings[i] = Console.ReadLine();
            }

            var queriesSize = int.Parse(Console.ReadLine());
            var queryStrings = new string[queriesSize];

            for (int i = 0; i < queriesSize; i++)
            {
                queryStrings[i] = Console.ReadLine();
            }

            var matchingStrings = GetMatchingStrings(inputStrings, queryStrings);

            Console.WriteLine(string.Join("\n", matchingStrings));
        }

        private static int[] GetMatchingStrings(string[] inputStrings, string[] queryStrings)
        {
            var frequencyMap = new Dictionary<string, int>();

            foreach (var inputString in inputStrings)
            {
                if (frequencyMap.ContainsKey(inputString))
                {
                    frequencyMap[inputString]++;
                }
                else
                {
                    frequencyMap.Add(inputString, 1);
                }
            }

            var matchingStrings = new int[queryStrings.Length];

            for (int i = 0; i < queryStrings.Length; i++)
            {
                if (frequencyMap.ContainsKey(queryStrings[i]))
                {
                    matchingStrings[i] = frequencyMap[queryStrings[i]];
                }
                else
                {
                    matchingStrings[i] = 0;
                }
            }

            return matchingStrings;
        }
    }
}
