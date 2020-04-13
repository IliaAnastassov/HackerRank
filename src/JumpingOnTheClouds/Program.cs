using System;

namespace JumpingOnTheClouds
{
    class Program
    {
        static void Main()
        {
            int[] clouds = Array.ConvertAll(Console.ReadLine().Split(' '), c => Convert.ToInt32(c));

            int result = JumpingOnClouds(clouds);

            Console.WriteLine(result);
        }

        private static int JumpingOnClouds(int[] clouds)
        {
            var jumpCount = 0;

            var i = 0;
            while (i < clouds.Length - 1)
            {
                if (i < clouds.Length - 2 && clouds[i + 2] == 0)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }

                jumpCount++;
            }

            return jumpCount;
        }
    }
}
