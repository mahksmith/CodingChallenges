using System;

namespace Challenges.HackerRank.WeekOfCode26
{
    public class MusicOnTheStreet
    {
        public static void Main(string[] args)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = line[0]; //Border Points

            int[] borderPoints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(borderPoints);

            line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int m = line[0];
            int hMin = line[1];
            int hMax = line[2];

            Console.WriteLine(Calculate(m, hMin, hMax, borderPoints));
        }

        public static int Calculate(int m, int hMin, int hMax, int[] borders)
        {
            //Start Search from earliest border crossing - hMax
            //End Search at latest border crossing + hMax + 1

            //Looping over start points
            for (int i = borders[0] - hMax - 1; i < borders[borders.Length-1] + hMax + 1; i++)
            {
                bool traverse_ok = true;

                int currentPoint = i;

                //Looping over borders for each startpoint
                for (int j = 0; j < borders.Length; j++)
                {
                    // Need to check:
                    //   Is the distance to the next crossing within hMin and hMax
                    int distToNext = borders[j] - currentPoint;
                    if (!(distToNext >= hMin && distToNext <= hMax))
                    {
                        traverse_ok = false;
                        break;
                    }
                    currentPoint = borders[j];
                      
                }

                if (traverse_ok)
                    return i;
            }

            //shouldn't hit!
            return 0;
        }

    }
}
