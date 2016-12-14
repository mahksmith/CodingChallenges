using System;
using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode26;
using System.Collections.Generic;
using System.Collections;

namespace ChallengesTests.HackerRank.WeekOfCode26
{
    [TestFixture]
    public class MusicOnTheStreetTests
    {
        [Test]
        public void TestSupplied()
        {
            Assert.AreEqual(-2, MusicOnTheStreet.Calculate(7, 2, 3, new int[] { 1, 3 }));

            //Base Cases...
            Assert.AreEqual(0, MusicOnTheStreet.Calculate(1, 1, 1, new int[] { 1 }));
            Assert.AreEqual(1, MusicOnTheStreet.Calculate(2, 1, 1, new int[] { 1 }));

            //Some Random Tests?


            Random random = new Random();
            for (int i = 0; i < 100000; i++)
            {
                int m = random.Next(1, (int)Math.Pow(10, 9));
                int hMin = random.Next(1, (int)Math.Pow(10, 9));
                int hMax = random.Next(hMin, (int)Math.Pow(10, 9));

                int[] borders = new int[(int)Math.Pow(10, 6)];

                //ints have to be pairwise different and in increasing order
                //one solution will always exist
                int current = 0 - random.Next(1, hMax);
                int lastInt = 0;

                try
                {
                    for (int n = 0; n < borders.Length; n++)
                    {
                        borders[n] = random.Next(Math.Max(current + 1, current + hMin + 1), current + hMax + 1);
                        current = borders[n];
                        lastInt = n;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                int[] bordersNew = new int[lastInt + 1];
                for (int x = 0; x < lastInt + 1; x++)
                {
                    bordersNew[x] = borders[x];
                }

                int result = MusicOnTheStreet.Calculate(m, hMin, hMax, bordersNew);
                Assert.NotZero(result);
            }
        }
    }
}
