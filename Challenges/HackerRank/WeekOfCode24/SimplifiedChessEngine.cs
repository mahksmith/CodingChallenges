using System;
using System.Collections.Generic;
using System.IO;

namespace Challenges.HackerRank.WeekOfCode24
{
    public class SimplifiedChessEngine
    {
        private List<Tuple<char, char, int, int>> pieces;
        int max_turns;

        public SimplifiedChessEngine(int max_moves, List<Tuple<char, char, int, int>> pieces)
        {
            this.max_turns = max_moves;
            this.pieces = pieces;
        }

        public static List<SimplifiedChessEngine> ReadStream(TextReader tr)
        {
            int games = Convert.ToInt32(tr.ReadLine());
            List<SimplifiedChessEngine> list = new List<SimplifiedChessEngine>(games);

            for (int g = 0; g < games; g++)
            {
                int[] ints = Array.ConvertAll(tr.ReadLine().Split(' '), Convert.ToInt32);
                int pieces_white = ints[0];
                int pieces_black = ints[1];
                int max_turns = ints[2];

                List<Tuple<char, char, int, int>> pieces = new List<Tuple<char, char, int, int>>(pieces_white + pieces_black);

                for (int i = 0; i < pieces_white + pieces_black; i++)
                {
                    char color;
                    if (i < pieces_white)
                        color = 'W';
                    else
                        color = 'B';


                    string[] piece = tr.ReadLine().Split(' ');
                    pieces.Add(new Tuple<char, char, int, int>(color, Convert.ToChar(piece[0]), Convert.ToInt32(Convert.ToChar(piece[1])) - 64, Convert.ToInt32(piece[2])));
                }

                SimplifiedChessEngine sce = new SimplifiedChessEngine(max_turns, pieces);
                list.Add(sce);
            }
            return list;
        }

        public string Solve(int current_move = 1)
        {
            //Basically, we want to generate first the list of all moves possible.
            // Making sure that a player cannot move two pieces to the same spot, but can move (and delete) other players token.
            // If the white queen is removed, return "YES".

            // recursively, using move number as depth, generate all moves breadth-first.
            if (current_move > this.max_turns)
            {
                return "NO";
            }

            char current_color, opposite_color;

            if (current_move % 2 == 1)
            {
                current_color = 'W';
                opposite_color = 'B';
            }
            else
            {
                current_color = 'B';
                opposite_color = 'W';
            }

            // Win conditions
            Tuple<int, int> blackQueen = GetQueen('B', pieces);
            if (blackQueen == null)
                return "YES";

            Tuple<int, int> whiteQueen = GetQueen('W', pieces);
            if (whiteQueen == null)
                return "NO";


            List<Tuple<char, char, int, int>> pieces_copy;
            Tuple<char, char, int, int> piece_copy;


            foreach (Tuple<char, char, int, int> piece in pieces)
            {
                //Only move pieces of current_color
                if (!piece.Item1.Equals(current_color))
                    continue;


                List<Tuple<int, int>> list = GenerateMoves(piece.Item2, piece.Item3, piece.Item4);
                foreach (Tuple<int, int> move in list)
                {
                    pieces_copy = pieces.ConvertAll(temp_piece => new Tuple<char, char, int, int>(temp_piece.Item1, temp_piece.Item2, temp_piece.Item3, temp_piece.Item4));
                    piece_copy = new Tuple<char, char, int, int>(piece.Item1, piece.Item2, piece.Item3, piece.Item4);

                    // Only allow overwrites if pieces are of different color. Can't complete move so just continue move check.
                    char color = GetColorAtLocation(move.Item1, move.Item2, pieces_copy);
                    if (color.Equals(piece_copy.Item1))
                        continue;
                    else
                    {
                        //Delete other color's piece, if any.
                        pieces_copy = RemovePieceAtLocation(move.Item1, move.Item2, pieces_copy);

                        //Delete and re-add the capturing piece.
                        pieces_copy = RemovePieceAtLocation(piece_copy.Item3, piece_copy.Item4, pieces_copy);
                        pieces_copy.Add(new Tuple<char, char, int, int>(piece_copy.Item1, piece_copy.Item2, move.Item1, move.Item2));
                    }


                    // Check if queen is overwritten, only care about white winning.
                    if (move.Item1.Equals(blackQueen.Item1) && move.Item2.Equals(blackQueen.Item2))
                    {
                        return "YES";
                    }
                    else
                    {
                        if (Solve(current_move + 1).Equals("YES"))
                            return "YES";
                    }
                }
            }

            return "NO";
        }

        static List<Tuple<char, char, int, int>> RemovePieceAtLocation(int x, int y, List<Tuple<char, char, int, int>> pieces)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].Item3.Equals(x) && pieces[i].Item4.Equals(y))
                {
                    pieces.RemoveAt(i);
                    i--;
                }
            }

            return pieces;
        }

        public static List<Tuple<int, int>> GenerateMoves(char piece, int x, int y)
        {
            switch (piece)
            {
                case 'B':
                    return GenerateMovesBishop(x, y);
                case 'N':
                    return GenerateMovesKnight(x, y);
                case 'Q':
                    return GenerateMovesQueen(x, y);
                case 'R':
                    return GenerateMovesRook(x, y);
                default:
                    return null;
            }
        }

        private static List<Tuple<int, int>> GenerateMovesRook(int x, int y)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            //Generate moves horizonally.
            for (int i = 1; i <= 4; i++)
            {
                if (i.Equals(x))
                    continue;
                moves.Add(new Tuple<int, int>(i, y));
            }

            //Generate moves vertically
            for (int i = 1; i <= 4; i++)
            {
                if (i.Equals(y))
                    continue;
                moves.Add(new Tuple<int, int>(x, i));
            }

            return moves;
        }

        private static List<Tuple<int, int>> GenerateMovesKnight(int x, int y)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();
            /* Knights either move:
             *     -2 or +2 in X direction and -1 or +1 in Y, or
             *     -1 or +1 in X direction and -2 or +2 in Y.
             */

            // Sloppy Hardcoding to begin..
            moves.Add(new Tuple<int, int>(x - 2, y - 1));
            moves.Add(new Tuple<int, int>(x - 2, y + 1));
            moves.Add(new Tuple<int, int>(x + 2, y - 1));
            moves.Add(new Tuple<int, int>(x + 2, y + 1));
            moves.Add(new Tuple<int, int>(x - 1, y - 2));
            moves.Add(new Tuple<int, int>(x - 1, y + 2));
            moves.Add(new Tuple<int, int>(x + 1, y - 2));
            moves.Add(new Tuple<int, int>(x + 1, y + 2));

            // Can't remove item in foreach loop!! Generates exception
            return ConstrainMoves(moves);
        }

        private static List<Tuple<int, int>> GenerateMovesQueen(int x, int y)
        {
            // This should be the list of Rook moves added to the list of Bishop moves, for simplicity.

            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();
            moves.AddRange(GenerateMovesRook(x, y));
            moves.AddRange(GenerateMovesBishop(x, y));
            return moves;
        }

        private static List<Tuple<int, int>> GenerateMovesBishop(int x, int y)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            for (int i = 1; i <= 4; i++)
            {
                moves.Add(new Tuple<int, int>(x + i, y + i));
                moves.Add(new Tuple<int, int>(x + i, y - i));
                moves.Add(new Tuple<int, int>(x - i, y + i));
                moves.Add(new Tuple<int, int>(x - i, y - i));
            }

            return ConstrainMoves(moves);
        }

        private static List<Tuple<int, int>> ConstrainMoves(List<Tuple<int, int>> moves)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i].Item1 < 1 || moves[i].Item1 > 4 || moves[i].Item2 < 1 || moves[i].Item2 > 4)
                {
                    moves.RemoveAt(i);
                    i--;
                }
            }

            return moves;
        }

        static Tuple<int, int> GetQueen(char color, List<Tuple<char, char, int, int>> pieces)
        {
            foreach (Tuple<char, char, int, int> piece in pieces)
            {
                if (piece.Item1.Equals(color) && piece.Item2.Equals('Q'))
                    return new Tuple<int, int>(piece.Item3, piece.Item4);
            }

            return null;
        }

        static char GetColorAtLocation(int x, int y, List<Tuple<char, char, int, int>> pieces)
        {
            foreach (Tuple<char, char, int, int> piece in pieces)
            {
                if (piece.Item3.Equals(x) && piece.Item4.Equals(y))
                    return piece.Item1;
            }
            return '_';
        }

        static void Main(string[] args)
        {
            List<SimplifiedChessEngine> games = ReadStream(Console.In);

            foreach (SimplifiedChessEngine sce in games)
            {
                string s = sce.Solve();
                Console.WriteLine(s);
            }
        }
    }
}
