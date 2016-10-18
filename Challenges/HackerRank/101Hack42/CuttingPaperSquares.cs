using System;

namespace Challenges.HackerRank._101Hack42
{
    class P1PaperCutting
    {
        public static void Main(String[] args)
        {
            UInt64 n, m;

            UInt64[] ints = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToUInt64);
            n = ints[0];
            m = ints[1];

            Console.WriteLine(MakeCuts(n, m));
        }

        private static UInt64 MakeCuts(UInt64 n, UInt64 m)
        {
            return n * m - 1;
        }
    }
}