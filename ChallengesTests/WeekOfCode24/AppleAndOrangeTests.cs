using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode24;

namespace Tests
{
    [TestFixture()]
    public class AppleAndOrangeTests
    {
        [Test()]
        public void SuppliedTest()
        {
            /*
             * Example Input:
             * 7 11
             * 5 15
             * 3 2
             * -2 2 1
             * 5 -6 
             */
            int house_bound_left = 7, house_bound_right = 11;
            int apple_tree = 5, orange_tree = 15;
            const int apple_count = 3, orange_count = 2;
            int[] apples = new int[apple_count] { -2, 2, 1 };
            int[] oranges = new int[orange_count] { 5, -6 };

            Assert.AreEqual(1, AppleAndOrange.Count(apples, house_bound_left, house_bound_right, apple_tree));
            Assert.AreEqual(1, AppleAndOrange.Count(oranges, house_bound_left, house_bound_right, orange_tree));
        }
    }
}