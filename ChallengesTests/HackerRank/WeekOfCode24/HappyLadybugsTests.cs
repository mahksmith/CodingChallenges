using NUnit.Framework;
using Challenges.HackerRank.WeekOfCode24;
using System;
using System.IO;

namespace Tests
{
    [TestFixture()]
    public class HappyLadybugsTests
    {
        private void CompareInputToExpectedOutput(string input, string output)
        {
            input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Input/HappyLadyBugs", input);
            output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Input/HappyLadyBugs", output);

            int line_count = 1;  // useful for debugs..
            string line;
            StreamReader sr_in = new StreamReader(input);
            StreamReader sr_out = new StreamReader(output);
            
            int cases = Convert.ToInt32(sr_in.ReadLine());

            for (int i = 0; i < cases; i++)
            {
                sr_in.ReadLine(); //read in and throw away the string length.
                Assert.AreEqual(sr_out.ReadLine(), HappyLadybugs.IsHappy(sr_in.ReadLine()));
            }
        }

        [Test()]
        public void TestCase00()
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

        [Test()]
        public void TestCase01()
        {
            /*
             * 5
             * 1
             * _
             * 4
             * RBRB
             * 4
             * RRRR
             * 3
             * BBB
             * 4
             * BBB_
             */

            Assert.AreEqual("YES", HappyLadybugs.IsHappy("_"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("RBRB"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("RRRR"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("BBB"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("BBB_"));
        }

        [Test()]
        public void TestCase02()
        {
            /*
             * 7
             * 1
             * G
             * 2
             * GR
             * 4
             * _GR_
             * 5
             * _R_G_
             * 5
             * R_R_R
             * 8
             * RRGGBBXX
             * 8
             * RRGGBBXY
             */
             
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("G"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("GR"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("_GR_"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("_R_G_"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("R_R_R"));
            Assert.AreEqual("YES", HappyLadybugs.IsHappy("RRGGBBXX"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("RRGGBBXY"));
        }

        [Test()]
        public void TestCase03()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest03Input.txt", "HappyLadybugsTest03Output.txt");
        }

        [Test()]
        public void TestCase04()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest04Input.txt", "HappyLadybugsTest04Output.txt");
        }
        [Test()]
        public void TestCase05()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest05Input.txt", "HappyLadybugsTest05Output.txt");
        }
        [Test()]
        public void TestCase06()
        {
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("IJNPTY_HGHDR_QDIOJSIQXCUBXNKI_DJ_JOHXBJQ_HJD_IGOITUKXDIPSUHJOU_KTSSQDGHBUQIIG"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("B_XZVJK_UTM_XUOJML_RHYDJSR_KLZBOMXMJJ_YJBZOZ_BXKZOLBUBXRYROOHX_O_UBJHVBKVJJURM_ZXKMTVJXYJ_JRK"));
            Assert.AreEqual("NO", HappyLadybugs.IsHappy("BGRBSL_DRDKHYJQQCVRS_EMSDEBJB_KRQQGYMDRHQYSSGDHRQESRRD_SMCRDEJJDSDVQBS"));
        }
        [Test()]
        public void TestCase07()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest07Input.txt", "HappyLadybugsTest07Output.txt");
        }
        [Test()]
        public void TestCase08()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest08Input.txt", "HappyLadybugsTest08Output.txt");
        }
        [Test()]
        public void TestCase09()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest09Input.txt", "HappyLadybugsTest09Output.txt");
        }
        [Test()]
        public void TestCase10()
        {
            CompareInputToExpectedOutput("HappyLadybugsTest10Input.txt", "HappyLadybugsTest10Output.txt");
        }
    }
}