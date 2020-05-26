using System;

namespace GradingStudents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var grades = new int[] { 73, 67, 38, 33 };
            var rounded = RoundGrades(grades);

            Console.WriteLine(string.Join(" ", rounded));
        }

        private static int[] RoundGrades(int[] grades)
        {
            var rounded = new int[grades.Length];

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] >= 38 && (grades[i] % 5 >= 3))
                {
                    rounded[i] = grades[i] + (5 - grades[i] % 5);
                }
                else
                {
                    rounded[i] = grades[i];
                }
            }

            return rounded;
        }
    }
}
