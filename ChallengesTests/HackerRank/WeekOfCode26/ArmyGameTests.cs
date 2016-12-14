using System;
using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode26;

namespace ChallengesTests.HackerRank.WeekOfCode26
{
    [TestFixture]
    public class ArmyGameTests
    {
        [Test]
        public void TestSupplied()
        {
            Assert.AreEqual(1, ArmyGame.CountSupplyDrops(2, 2));

            //Some other things
            Assert.AreEqual(6, ArmyGame.CountSupplyDrops(6, 3));

            //Check zeros...
            Assert.AreEqual(0, ArmyGame.CountSupplyDrops(0, 0));
            Assert.AreEqual(0, ArmyGame.CountSupplyDrops(0, 1));
            Assert.AreEqual(0, ArmyGame.CountSupplyDrops(1, 0));
            Assert.AreEqual(250000, ArmyGame.CountSupplyDrops(1000, 1000));
        }
    }
}
