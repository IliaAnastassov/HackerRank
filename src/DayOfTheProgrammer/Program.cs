using System;

namespace DayOfTheProgrammer
{
    public class Program
    {
        public static void Main()
        {
            var year = int.Parse(Console.ReadLine().Trim());
            string date = GetDayOfProgrammerDate(year);

            Console.WriteLine(date);
        }

        private static string GetDayOfProgrammerDate(int year)
        {
            int day;
            bool isLeapYear;

            if (year < 1918)
            {
                // Julian calendar
                isLeapYear = year % 4 == 0;
            }
            else if (year > 1918)
            {
                // Gregorian calendar
                isLeapYear = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
            }
            else
            {
                // Year 1918
                return $"26.09.{year}";
            }

            if (isLeapYear)
            {
                day = 12;
            }
            else
            {
                day = 13;
            }

            return $"{day}.09.{year}";
        }
    }
}
