using System;

namespace NewYearChaos
{
    class Program
    {
        static void Main()
        {
            int[] queue = Array.ConvertAll(Console.ReadLine().Split(), n => Convert.ToInt32(n));

            GetMinimumBribes(queue);
        }

        private static void GetMinimumBribes(int[] queue)
        {
            var bribesCount = 0;
            bool isChaotic = false;

            for (int i = 0; i < queue.Length; i++)
            {
                if (queue[i] > i + 3)
                {
                    isChaotic = true;
                    break;
                }
                for (int j = Math.Max(0, queue[i] - 2); j < i; j++) // it's impossible for any number greater than {queue[i]} reach position {queue[i] - 2} as only two bribes are allowed.
                {
                    if (queue[j] > queue[i])
                    {
                        bribesCount++;
                    }
                }
            }
            if (isChaotic)
            {
                Console.WriteLine("Too chaotic");
            }
            else
            {
                Console.WriteLine(bribesCount);
            }
        }
    }
}
