using System;

namespace TimeConversion
{
    public class Program
    {
        public static void Main()
        {
            var twelveHourFormat = "01:30:00PM";
            var twentyFourHourFormat = ConvertTo24HourFormat(twelveHourFormat);

            Console.WriteLine(twentyFourHourFormat);
        }

        /// <summary>
        /// Note: Midnight is 12:00:00AM on a 12-hour clock, and 00:00:00 on a 24-hour clock. 
        /// Noon is 12:00:00PM on a 12-hour clock, and 12:00:00 on a 24-hour clock.
        /// </summary>
        private static string ConvertTo24HourFormat(string twelveHourFormat)
        {
            var hh = int.Parse(twelveHourFormat.Substring(0, 2));
            var mm = int.Parse(twelveHourFormat.Substring(3, 2));
            var ss = int.Parse(twelveHourFormat.Substring(6, 2));
            var period = twelveHourFormat.Substring(8, 2);

            if (period == "AM" && hh == 12)
            {
                hh = 0;
            }
            else if (period == "PM" && hh != 12)
            {
                hh += 12;
            }

            return $"{hh:00}:{mm:00}:{ss:00}";
        }
    }
}
