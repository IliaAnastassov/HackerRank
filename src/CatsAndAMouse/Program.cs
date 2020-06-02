using System;

namespace CatsAndAMouse
{
    public class Program
    {
        public static void Main()
        {
            var queryCount = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < queryCount; i++)
            {
                var input = Array.ConvertAll(Console.ReadLine().Trim().Split(), s => int.Parse(s));

                var catA = input[0];
                var catB = input[1];
                var mouse = input[2];

                string result = GetWinner(catA, catB, mouse);
                Console.WriteLine(result);
            }
        }

        private static string GetWinner(int catA, int catB, int mouse)
        {
            string winner;

            var distanceA = Math.Abs(catA - mouse);
            var distanceB = Math.Abs(catB - mouse);

            if (distanceA < distanceB)
            {
                winner = "Cat A";
            }
            else if (distanceB < distanceA)
            {
                winner = "Cat B";
            }
            else
            {
                winner = "Mouse C";
            }

            return winner;
        }
    }
}
