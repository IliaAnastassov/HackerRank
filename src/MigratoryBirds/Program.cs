using System;

namespace MigratoryBirds
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            var birds = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));

            var result = FindMostCommonBirdType(birds);
            Console.WriteLine(result);
        }

        private static int FindMostCommonBirdType(int[] birds)
        {
            // there are only 5 types of birds: 1 to 5, but the array is 0 based
            var frequencyMap = new int[6];
            foreach (var bird in birds)
            {
                frequencyMap[bird]++;
            }

            var mostCommonType = 1;
            for (int i = 1; i < 6; i++)
            {
                if (frequencyMap[i] > frequencyMap[mostCommonType])
                {
                    mostCommonType = i;
                }
            }

            return mostCommonType;
        }
    }
}
