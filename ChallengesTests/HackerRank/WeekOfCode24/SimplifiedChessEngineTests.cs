using NUnit.Framework;
using System;
using System.Collections.Generic;
using Challenges.HackerRank.WeekOfCode24;
using System.IO;

namespace Tests
{
    [TestFixture()]
    public class SimplifiedChessEngineTests
    {
        [Test()]
        public void TestCase00()
        {
            List<Tuple<char, char, int, int>> pieces = new List<Tuple<char, char, int, int>>(3);
            pieces.Add(new Tuple<char, char, int, int>('W', 'N', 2, 2));
            pieces.Add(new Tuple<char, char, int, int>('W', 'Q', 2, 1));
            pieces.Add(new Tuple<char, char, int, int>('B', 'Q', 1, 4));

            SimplifiedChessEngine sce = new SimplifiedChessEngine(1, pieces);

            Assert.AreEqual("YES", sce.Solve());
        }

        [Test()]
        public void MoveKnightTest()
        {
            // 4 X   X
            // 3       X
            // 2   N
            // 1       X
            //   1 2 3 4

            List<Tuple<int, int>> moves = SimplifiedChessEngine.GenerateMoves('N', 2, 2);
            Assert.AreEqual(4, moves.Count);
            Assert.That(moves.Contains(new Tuple<int, int>(1, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(3, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 1)));

            // 4 X
            // 3     N
            // 2 X
            // 1   X   X  
            //   1 2 3 4

            moves = SimplifiedChessEngine.GenerateMoves('N', 3, 3);
            Assert.AreEqual(4, moves.Count);
            Assert.That(moves.Contains(new Tuple<int, int>(1, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(1, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 1)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 1)));
        }

        [Test()]
        public void MoveBishopTest()
        {
            //4 X      
            //3   X   X
            //2     B
            //1   X   X
            //  1 2 3 4

            List<Tuple<int, int>> moves = SimplifiedChessEngine.GenerateMoves('B', 3, 2);
            Assert.AreEqual(5, moves.Count);
            Assert.That(moves.Contains(new Tuple<int, int>(1, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 1)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 1)));
        }

        [Test()]
        public void MoveRookTest()
        {
            //4   X
            //3   X
            //2 X R X X
            //1   X   
            //  1 2 3 4

            List<Tuple<int, int>> moves = SimplifiedChessEngine.GenerateMoves('R', 2, 2);
            Assert.AreEqual(6, moves.Count);
            Assert.That(moves.Contains(new Tuple<int, int>(2, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(1, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(3, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 1)));
        }

        [Test()]
        public void MoveQueenTest()
        {
            //4   X X X
            //3 X X Q X
            //2   X X X
            //1 X   X
            //  1 2 3 4

            List<Tuple<int, int>> moves = SimplifiedChessEngine.GenerateMoves('Q', 3, 3);
            Assert.AreEqual(11, moves.Count);
            Assert.That(moves.Contains(new Tuple<int, int>(2, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(3, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 4)));
            Assert.That(moves.Contains(new Tuple<int, int>(1, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 3)));
            Assert.That(moves.Contains(new Tuple<int, int>(2, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(3, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(4, 2)));
            Assert.That(moves.Contains(new Tuple<int, int>(1, 1)));
            Assert.That(moves.Contains(new Tuple<int, int>(3, 1)));
        }

        [Test()]
        public void MultipleMovesRecursiveTest()
        {
            List<Tuple<char, char, int, int>> pieces = new List<Tuple<char, char, int, int>>(2);
            pieces.Add(new Tuple<char, char, int, int>('W', 'Q', 2, 1));
            pieces.Add(new Tuple<char, char, int, int>('B', 'Q', 1, 4));

            SimplifiedChessEngine sce = new SimplifiedChessEngine(3, pieces);

            Assert.AreEqual("YES", sce.Solve());
        }

        [Test()]
        public void TestCase01()
        {
            /*
             * 1
             * 1 1 4
             * Q C 1
             * Q B 3
             */
             
            List<Tuple<char, char, int, int>> pieces = new List<Tuple<char, char, int, int>>(2);
            
            pieces.Add(new Tuple<char, char, int, int>('W', 'Q', 'C', 1));
            pieces.Add(new Tuple<char, char, int, int>('B', 'Q', 'B', 3));
            
            SimplifiedChessEngine sce = new SimplifiedChessEngine(4, pieces);

            Assert.AreEqual("NO", sce.Solve());
        }

        [Test()]
        public void TestCase02()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase03()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase04()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase05()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase06()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase07()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase08()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase09()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase10()
        {
            List<SimplifiedChessEngine> list = SimplifiedChessEngine.ReadStream(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Input/SimplifiedChessEngine", "Test10Input.txt")));

            TextReader tr = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Input", "SimplifiedChessEngine", "Test10Output.txt"));

            foreach (SimplifiedChessEngine sce in list)
                Assert.AreEqual(tr.ReadLine(), sce.Solve());
        }

        [Test()]
        public void TestCase11()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase12()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase13()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase14()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase15()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase16()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase17()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase18()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase19()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase20()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase21()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase22()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase23()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase024()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase25()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase26()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase27()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase28()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase29()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void TestCase30()
        {
            throw new NotImplementedException();
        }
    }
}