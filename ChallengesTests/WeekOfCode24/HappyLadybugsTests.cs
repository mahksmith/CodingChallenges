using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode24;

namespace Tests
{
    [TestFixture()]
    public class HappyLadybugsTests
    {
        [Test()]
        public void SuppliedTest()
        {
            /*
             * 4
             * 7
             * RBY_YBR
             * 6
             * X_Y__X
             * 2
             * __
             * 6
             * B_RRBR
             */

            Assert.AreEqual("YES", HappyLadybugs.IsHappy("RBY_YBR"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("X_Y__X"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("__"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("B_RRBR"));
        }

        [Test]
        public void NoBlankTest()
        {
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("RRBBYY"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("RYRY"));
        }
    }
}