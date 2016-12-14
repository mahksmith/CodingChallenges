using System;
using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode26;
using System.Collections.Generic;

namespace ChallengesTests.HackerRank.WeekOfCode26
{
    [TestFixture]
    public class BestDivisorTests
    {
        [Test]
        public void TestSupplied()
        {
            Assert.AreEqual(6, BestDivisor.CalcBestDivisor(12));

            //Some other things
            Assert.AreEqual(0, BestDivisor.CalcBestDivisor(0));
            Assert.AreEqual(1, BestDivisor.CalcBestDivisor(1));
            Assert.AreEqual(2, BestDivisor.CalcBestDivisor(2));

            Assert.AreEqual(625, BestDivisor.CalcBestDivisor(100000));
        }

        [Test]
        public void TestDivisorGeneration()
        {
            List<int> divisors = BestDivisor.GenerateDivisors(12);
            divisors.Sort();

            CollectionAssert.AreEqual(
                new List<int> { 1, 2, 3, 4, 6, 12 }, divisors);
        }

        [Test]
        public void RandomTests()
        {
            for (int i = 0; i < 10000; i++)
            {
                Random rand = new Random();
                int n = rand.Next(10000);
                Assert.Positive(BestDivisor.CalcBestDivisor(n));
            }
        }
    }
}
