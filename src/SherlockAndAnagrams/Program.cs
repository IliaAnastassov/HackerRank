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
            var anagramCount = 0;

            var substringSet = new HashSet<string>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int length = 1; length <= input.Length - i; length++)
                {
                    var substring = string.Concat(input.Substring(i, length).OrderBy(c => c));

                    if (!substringSet.Contains(substring))
                    {
                        substringSet.Add(substring);
                    }
                    else
                    {
                        anagramCount++;
                    }
                }
            }

            return anagramCount;
        }
    }
}
