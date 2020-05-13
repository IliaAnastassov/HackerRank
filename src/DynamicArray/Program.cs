using System;
using System.Collections.Generic;

namespace DynamicArray
{
    public class Program
    {
        public static void Main()
        {
            var queries = new List<List<int>>
            {
                new List<int> { 1, 0, 5 },
                new List<int> { 1, 1, 7 },
                new List<int> { 1, 0, 3 },
                new List<int> { 2, 1, 0 },
                new List<int> { 2, 1, 1 }
            };

            var result = DynamicArray(2, queries);

            Console.WriteLine(string.Join("\n", result));
        }

        /// <summary>
        /// Query: 1 x y
        /// Query: 2 x y
        /// </summary>
        /// <param name="sequenceCount"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static List<int> DynamicArray(int sequenceCount, List<List<int>> queries)
        {
            var sequences = new List<List<int>>();
            for (int i = 0; i < sequenceCount; i++)
            {
                sequences.Add(new List<int>(sequenceCount));
            }

            var answers = new List<int>();
            var lastAnswer = 0;

            foreach (var query in queries)
            {
                var queryType = query[0];
                var x = query[1];
                var y = query[2];

                var sequenceIndex = (x ^ lastAnswer) % sequenceCount;

                if (queryType == 1)
                {
                    sequences[sequenceIndex].Add(y);
                }
                else
                {
                    lastAnswer = sequences[sequenceIndex][y % sequences[sequenceIndex].Count];
                    answers.Add(lastAnswer);
                }
            }

            return answers;
        }
    }
}
