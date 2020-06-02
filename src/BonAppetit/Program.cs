using System;
using System.Linq;

namespace BonAppetit
{
    public class Program
    {
        public static void Main()
        {
            var itemToExclude = int.Parse(Console.ReadLine().Trim().Split()[1]);
            var bill = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));
            var charged = int.Parse(Console.ReadLine());

            CheckBill(bill, itemToExclude, charged);
        }

        private static void CheckBill(int[] bill, int itemToExclude, int charged)
        {
            var expected = (bill.Sum() - bill[itemToExclude]) / 2;

            if (expected == charged)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(charged - expected);
            }
        }
    }
}
