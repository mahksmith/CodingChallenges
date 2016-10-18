using System;
using System.Diagnostics;

namespace Challenges.HackerRank._101Hack42
{
    class JohnsSubwayCommute
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(BestSeat(input));

            if (Debugger.IsAttached)
                Console.ReadLine();
        }

        private static int BestSeat(string input)
        {
            // check ends of string, sit in the left 1 first then right.
            if (input[input.Length - 1].Equals('E'))
                return input.Length - 1;
            if (input[0].Equals('E'))
                return 0;

            // choose a good seat, starting from the left. If a string has EEE, sit in the middle of it.
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i].Equals('E') && input[i - 1].Equals('E') && input[i + 1].Equals('E'))
                    return i;
            }

            // else choose a seat, starting from left that has a free space on right..
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i].Equals('E') && input[i + 1].Equals('E'))
                {
                    return i;
                }
            }

            // no good seats, so choose right most empty seat.
            return input.IndexOf('E');
        }
    }
}