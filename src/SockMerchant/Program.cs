using System;
using System.Collections.Generic;

namespace SockMerchant
{
    class Program
    {
        static void Main()
        {
            var socks = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            var pairsCount = GetPairCount(socks);

            Console.WriteLine(pairsCount);
        }

        private static int GetPairCount(int[] socks)
        {
            var pairCount = 0;
            var colorMap = new Dictionary<int, int>();

            foreach (var sock in socks)
            {
                if (colorMap.ContainsKey(sock))
                {
                    colorMap[sock]++;

                    if (colorMap[sock] == 2)
                    {
                        pairCount++;
                        colorMap[sock] = 0;
                    }
                }
                else
                {
                    colorMap.Add(sock, 1);
                }
            }

            return pairCount;
        }
    }
}
