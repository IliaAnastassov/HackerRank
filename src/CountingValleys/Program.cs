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

            int result = CountingValleys(n, s);

            textWriter.WriteLine(result);
        }

        private static int CountingValleys(int number, string path)
        {
            var valleyCount = 0;

            if (number > 0)
            {
                var currentAltitude = 0;

                foreach (var direction in path)
                {
                    var previousAltitude = currentAltitude;
                    if (direction == 'U')
                    {
                        currentAltitude++;
                    }
                    else if (direction == 'D')
                    {
                        currentAltitude--;
                    }

                    if (currentAltitude == 0 && previousAltitude < currentAltitude)
                    {
                        valleyCount++;
                    }
                }
            }

            return valleyCount;
        }
    }
}
