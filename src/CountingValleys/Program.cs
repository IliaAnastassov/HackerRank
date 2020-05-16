using System;
using System.IO;

namespace CountingValleys
{
    public class Program
    {
        public static void Main()
        {
            using var textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();

            int result = CountingValleys(s);

            textWriter.WriteLine(result);
        }

        private static int CountingValleys(string path)
        {
            var valleyCount = 0;
            var altitude = 0;

            foreach (var direction in path)
            {
                if (direction == 'D')
                {
                    altitude--;
                }
                else if (direction == 'U')
                {
                    altitude++;

                    if (altitude == 0)
                    {
                        valleyCount++;
                    }
                }
            }

            return valleyCount;
        }
    }
}
