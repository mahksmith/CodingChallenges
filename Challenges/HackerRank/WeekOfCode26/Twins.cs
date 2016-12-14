using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenges.HackerRank.WeekOfCode26
{
    public class Twins
    {
        public static void Main(string[] args)
        {
            int[] ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(Calculate(ints[0], ints[1]));
        }

        public static int Calculate(int n, int m)
        {
            BitArray allBits = GetPrimes(n, m);

            int count = 0;
            int start = n;

            if (start % 2 == 0)
                start = start + 1;

           

            for (int i = start; i < m; i+=2)
            {
                if (allBits[i] == true && allBits[i + 2] == true)
                    count += 1;
            }

            return count;
        }

        public static BitArray GetPrimes(int n, int m)
        {
            BitArray allBits = new BitArray(m + 1, true);
            allBits[0] = false;
            allBits[1] = false;

            for (int i = 2; i < m; i++)
            {
                if (allBits[i] == false)
                    continue;

                for (int j = i + i; j < m; j+=i)
                {
                    allBits[j] = false;
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i < m; i++)
            {
                if (primes.Equals(true))
                    primes.Add(i);
            }
            return allBits;       
        }
    }
}
