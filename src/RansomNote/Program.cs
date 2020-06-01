using System;
using System.Collections.Generic;

namespace RansomNote
{
    public class Program
    {
        public static void Main()
        {
            var magazine = Console.ReadLine().Split();
            var note = Console.ReadLine().Split();

            var containsNote = ContainsNote(magazine, note);
            Console.WriteLine(containsNote);
        }

        /// <summary>
        /// ive got a lovely bunch of coconuts 
        /// ive got some coconuts
        /// </summary>
        private static bool ContainsNote(string[] magazine, string[] note)
        {
            var magazineMap = new Dictionary<string, int>();
            foreach (var word in magazine)
            {
                if (magazineMap.ContainsKey(word))
                {
                    magazineMap[word]++;
                }
                else
                {
                    magazineMap.Add(word, 1);
                }
            }

            var containsNote = true;
            foreach (var word in note)
            {
                if (magazineMap.ContainsKey(word) && magazineMap[word] > 0)
                {
                    magazineMap[word]--;
                }
                else
                {
                    containsNote = false;
                    break;
                }
            }

            return containsNote;
        }
    }
}
