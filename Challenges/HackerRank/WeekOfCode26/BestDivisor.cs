using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Challenges.HackerRank.WeekOfCode26
{
    public class BestDivisor
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CalcBestDivisor(n));
        }

        public static int CalcBestDivisor(int n)
        {
            List<int> divisors = GenerateDivisors(n);

            int bestSum = 0;
            int bestDivisor = 0;
            foreach (int i in divisors)
            {
                string[] chars = Array.ConvertAll(i.ToString().ToCharArray(), char.ToString);
                int[] ints = Array.ConvertAll(chars, Int32.Parse);

                int sum = ints.Aggregate(0, (x, y) => x + y);
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestDivisor = i;
                }
                else if (sum == bestSum)
                    bestDivisor = Math.Min(bestDivisor, i);
            }

            return bestDivisor;
        }

        public static List<int> GenerateDivisors(int n)
        {
            HashSet<int> divisors = new HashSet<int>();
            //Calculate Divisors
            for (int i = 1; i < Math.Sqrt(n) + 1; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }

            return divisors.ToList();
        }
    }
}
