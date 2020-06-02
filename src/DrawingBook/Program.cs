using System;

namespace DrawingBook
{
    public class Program
    {
        public static void Main()
        {
            var numberOfPages = int.Parse(Console.ReadLine().Trim());
            var page = int.Parse(Console.ReadLine().Trim());

            var result = GetTurnsCount(numberOfPages, page);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Sample book:
        /// 1
        /// 2  3
        /// 4  5
        /// 6  7
        /// 8  9
        /// 10
        /// -----
        /// When starting from the first page, the number of pages turned is always page / 2
        /// When starting from the last page, there are two possibilities:
        ///  - numberOfPages is odd  =>  (numberOfPages - page) / 2     = numberOfPages/2 - page/2
        ///  - numberOfPages is even =>  (numberOfPages - page + 1) / 2 = numberOfPages/2 - page/2 + 1/2 = numberOfPages/2 - page/2 (since 1/2 = 0)
        /// </summary>
        private static int GetTurnsCount(int numberOfPages, int page)
        {
            return Math.Min(page / 2, numberOfPages / 2 - page / 2);
        }
    }
}
