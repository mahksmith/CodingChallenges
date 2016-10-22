using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode24;
using System.IO;
using System.Reflection;
using ChallengesTests.Properties;
using System;

namespace Tests
{
    [TestFixture()]
    public class AppleAndOrangeTests
    {
        [Test()]
        public void TestCase0()
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

            Assert.AreEqual(1, AppleAndOrange.Count(house_bound_left, house_bound_right, apple_tree, apples));
            Assert.AreEqual(1, AppleAndOrange.Count(house_bound_left, house_bound_right, orange_tree, oranges));
        }

        [Test()]
        public void TestCase01()
        {
            /*
             * Example Input:
             * 2 3
             * 1 5
             * 1 1
             * -2
             * -1
             */
            int house_bound_left = 2, house_bound_right = 3;
            int apple_tree = 1, orange_tree = 5;
            const int apple_count = 1, orange_count = 1;
            int[] apples = new int[apple_count] { -2 };
            int[] oranges = new int[orange_count] { -1 };

            Assert.AreEqual(0, AppleAndOrange.Count(house_bound_left, house_bound_right, apple_tree, apples));
            Assert.AreEqual(0, AppleAndOrange.Count(house_bound_left, house_bound_right, orange_tree, oranges));
        }

        [Test()]
        public void TestCase02()
        {
            /*
             * Example Input:
             * 2 3
             * 1 5
             * 1 1
             * 2
             * -2
             */
            int house_bound_left = 2, house_bound_right = 3;
            int apple_tree = 1, orange_tree = 5;
            const int apple_count = 1, orange_count = 1;
            int[] apples = new int[apple_count] { 2 };
            int[] oranges = new int[orange_count] { -2 };

            Assert.AreEqual(1, AppleAndOrange.Count(house_bound_left, house_bound_right, apple_tree, apples));
            Assert.AreEqual(1, AppleAndOrange.Count(house_bound_left, house_bound_right, orange_tree, oranges));
        }

        [Test()]
        public void TestCase03()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase03.txt"));
            Assert.AreEqual(18409, aor.Count("apple"));
            Assert.AreEqual(19582, aor.Count("orange"));
        }

        [Test()]
        public void TestCase04()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase04.txt"));
            Assert.AreEqual(2530, aor.Count("apple"));
            Assert.AreEqual(1149, aor.Count("orange"));
        }

        [Test()]
        public void TestCase05()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase05.txt"));
            Assert.AreEqual(8032, aor.Count("apple"));
            Assert.AreEqual(3129, aor.Count("orange"));
        }

        [Test()]
        public void TestCase06()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase06.txt"));
            Assert.AreEqual(6661, aor.Count("apple"));
            Assert.AreEqual(4075, aor.Count("orange"));
        }

        [Test()]
        public void TestCase07()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase07.txt"));
            Assert.AreEqual(2082, aor.Count("apple"));
            Assert.AreEqual(1960, aor.Count("orange"));
        }

        [Test()]
        public void TestCase08()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase08.txt"));
            Assert.AreEqual(28, aor.Count("apple"));
            Assert.AreEqual(2966, aor.Count("orange"));
        }

        [Test()]
        public void TestCase09()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase09.txt"));
            Assert.AreEqual(16141, aor.Count("apple"));
            Assert.AreEqual(3358, aor.Count("orange"));

        }

        [Test()]
        public void TestCase10()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase10.txt"));
            Assert.AreEqual(37609, aor.Count("apple"));
            Assert.AreEqual(38141, aor.Count("orange"));

        }

        [Test()]
        public void TestCase11()
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(CreateFileStream("AppleAndOrangeTestCase11.txt"));
            Assert.AreEqual(5046, aor.Count("apple"));
            Assert.AreEqual(5659, aor.Count("orange"));
        }

        private TextReader CreateFileStream(String filename)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Input/AppleAndOrange", filename);
            return new StreamReader(dir);
        }
    }
}