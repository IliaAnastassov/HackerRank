using System;
using System.Collections.Generic;
using System.Linq;

namespace SherlockAndAnagrams
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = CountAnagrams(input);

            Console.WriteLine(result);
        }

        /// <summary>
        /// ifailuhkqq  -> 3
        /// kkkk        -> 10
        /// </summary>
        private static int CountAnagrams(string input)
        {
            var substringDictionary = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                for (int length = 1; length <= input.Length - i; length++)
                {
                    var orderedSubstring = string.Concat(input.Substring(i, length).OrderBy(c => c));

                    if (substringDictionary.ContainsKey(orderedSubstring))
                    {
                        substringDictionary[orderedSubstring]++;
                    }
                    else
                    {
                        substringDictionary.Add(orderedSubstring, 1);
                    }
                }
            }

            var anagramCount = 0;

            foreach (var value in substringDictionary.Values.Where(v => v > 1))
            {
                anagramCount += value * (value - 1) / 2;
            }

            return anagramCount;
        }
    }
}
