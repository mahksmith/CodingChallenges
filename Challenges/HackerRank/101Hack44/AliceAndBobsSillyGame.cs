namespace Challenges.HackerRank.WeekOfCode26._101Hack44
{
    using System;
    using System.Collections;

    class Game
    {

        static void Main(String[] args)
        {
            int g = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < g; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                BitArray arr = new BitArray(n+1, true);
                arr[0] = false;
                arr[1] = false; 
                
                // get list of prime numbers
                for( int i = 4; i < n+1; i++)
                {
                    if (i % 2 == 0)
                        arr[i] = false;

                    // kill all multiples..
                    for (int m = i * 2; m < n+1; m += i)
                    {
                        arr[m] = false;
                    }
                }

                int primeCount = 0;
                // should have list of primes...
                for (int num = 0; num < n + 1; num++)
                {
                    if (arr[num] == true)
                        primeCount++;
                }


                //Fake Minimax:
                if (primeCount % 2 == 0)
                    Console.WriteLine("Bob");
                else
                    Console.WriteLine("Alice");
                
            }
        }
    }

}
