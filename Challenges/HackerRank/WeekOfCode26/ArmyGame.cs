using System;
using System.Diagnostics;

namespace Challenges.HackerRank.WeekOfCode26
{
    public class ArmyGame
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            Console.WriteLine(CountSupplyDrops(m, n));

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        public static int CountSupplyDrops(int m, int n)
        {
            return (int)Math.Ceiling(m / 2.0) * (int)Math.Ceiling(n / 2.0);
        }
    }
}
