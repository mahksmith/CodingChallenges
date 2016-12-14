using System;
using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode26;
using System.Collections.Generic;
using System.Collections;

namespace ChallengesTests.HackerRank.WeekOfCode26
{
    [TestFixture]
    public class TwinsTests
    {
        [Test]
        public void TestSupplied()
        {
            Assert.AreEqual(3, Twins.Calculate(3, 13));

            //Some other things
            Assert.AreEqual(3063, Twins.Calculate(999000000, 1000000000));
        }

        [Test]
        public void TestPrimeGeneration()
        {
            BitArray result = Twins.GetPrimes(1, 100);

            int count = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == true)
                    count += 1;
            }

            Assert.AreEqual(25, count);
            Assert.IsTrue(result[2]);
            Assert.IsTrue(result[3]);
            Assert.IsTrue(result[5]);
            Assert.IsTrue(result[7]);
            Assert.IsTrue(result[11]);
            Assert.IsTrue(result[13]);
        }
    }
}
