using System;
using System.Collections.Generic;

namespace Challenges.HackerRank._101Hack42
{
    class PointsOnRectangle
    {

        public static void Main(string[] args)
        {
            int rounds = Convert.ToInt32(Console.ReadLine());

            for (int r = 0; r < rounds; r++)
            {
                int points = Convert.ToInt32(Console.ReadLine());

                List<Tuple<int, int>> list = new List<Tuple<int, int>>();
                for (int p = 0; p < points; p++)
                {

                    int[] point = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                    list.Add(new Tuple<int, int>(point[0], point[1]));
                }

                Console.WriteLine(ArePointsOnRectangle(list));
            }
        }

        public static string ArePointsOnRectangle(List<Tuple<int, int>> points)
        {
            int min_x = 10000, max_x = -10000;
            int min_y = 10000, max_y = -10000;

            foreach (Tuple<int, int> point in points)
            {
                if (point.Item1 < min_x)
                    min_x = point.Item1;
                if (point.Item1 > max_x)
                    max_x = point.Item1;

                if (point.Item2 < min_y)
                    min_y = point.Item2;
                if (point.Item2 > max_y)
                    max_y = point.Item2;
            }

            // Should be non-degenerate..
            if (min_x.Equals(max_x))
                return "NO";
            if (min_y.Equals(max_y))
                return "NO";


            // Check if each point sits on the x or y axis..
            foreach (Tuple<int, int> point in points)
            {
                if (!(point.Item1.Equals(min_x) || point.Item1.Equals(max_x)))
                    return "NO";

                if (!(point.Item2.Equals(min_y) || point.Item2.Equals(max_y)))
                    return "NO";
            }

            return "YES";
        }
    }
}