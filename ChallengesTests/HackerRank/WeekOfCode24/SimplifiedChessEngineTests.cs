using NUnit.Framework;
using System;
using System.Collections.Generic;
using Challenges.HackerRank.WeekOfCode24;

namespace Tests
{
    [TestFixture()]
    public class SimplifiedChessEngineTests
    {
        [Test()]
        public void SuppliedTest()
        {
            List<Tuple<char, char, int, int>> pieces = new List<Tuple<char, char, int, int>>(3);
            pieces.Add(new Tuple<char, char, int, int>('W', 'N', 2, 2));
            pieces.Add(new Tuple<char, char, int, int>('W', 'Q', 2, 1));
            pieces.Add(new Tuple<char, char, int, int>('B', 'Q', 1, 4));

            Assert.AreEqual("YES", SimplifiedChessEngine.Solve(1, pieces, 1));
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

            Assert.AreEqual("YES", SimplifiedChessEngine.Solve(3, pieces, 1));
        }
    }
}