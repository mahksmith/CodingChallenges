using System;
using System.Collections.Generic;

namespace Challenges.HackerRank.WeekOfCode26._101Hack44
{
    class Solution
    {

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            Dictionary<int, int> dict = new Dictionary<int, int>(n);
            foreach (int i in a)
            {
                if (dict.ContainsKey(i))
                    dict[i] = dict[i] + 1;
                else
                    dict.Add(i, 1);
            }
            int max = 0;
            foreach (int x in dict.Keys)
            {
                foreach (int y in dict.Keys)
                {
                    if (Math.Abs(y-x) == 1)
                    {
                        max = Math.Max(max, dict[y] + dict[x]);
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
