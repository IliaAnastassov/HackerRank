using System;

namespace ElectronicsShop
{
    public class Program
    {
        public static void Main()
        {
            var budget = int.Parse(Console.ReadLine().Trim().Split()[0]);
            var keyboards = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));
            var drives = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));

            var result = GetMoneySpent(budget, keyboards, drives);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Time Complexity: O(n + m log(n + m))
        /// If we sort one array in descending an the other in ascending order,
        /// we could iterate through each element of both arrays only once, 
        /// starting from the beggining or end of both arrays:
        /// b: 100
        /// k: 90 89 85 80 70 60 40 10
        /// d: 4 5 6 8 12 19
        /// </summary>
        private static int GetMoneySpent(int budget, int[] keyboards, int[] drives)
        {
            var moneySpent = -1;

            // sort one in descending an the other in ascending order
            Array.Sort(keyboards, (x, y) => y.CompareTo(x));
            Array.Sort(drives);

            // start at the beggining of both arrays
            int k = 0, d = 0;
            while (k < keyboards.Length)
            {
                while (d < drives.Length)
                {
                    if (keyboards[k] + drives[d] > budget)
                    {
                        // if we exceed the budget, there is no point of iterating further
                        // so stop and keep the current value of d for the next value of k
                        break;
                    }

                    moneySpent = Math.Max(moneySpent, keyboards[k] + drives[d]);

                    if (moneySpent == budget)
                    {
                        // we found the maximum possible money spent, no point to continue
                        return moneySpent;
                    }

                    // only iterate d if the sum of keyboards[k] + drives[d] is <= budget
                    d++;
                }

                k++;
            }

            return moneySpent;
        }
    }
}
