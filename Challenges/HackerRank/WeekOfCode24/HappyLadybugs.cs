using System;
using System.Collections.Generic;

namespace Challenges.HackerRank.WeekOfCode24
{
    public class HappyLadybugs
    {
        static void Main(String[] args)
        {
            if (args.Length.Equals(0))
            {
                //Supplied Code for Exercise
                int Q = Convert.ToInt32(Console.ReadLine());
                for (int a0 = 0; a0 < Q; a0++)
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    string b = Console.ReadLine();

                    Console.WriteLine(IsHappy(b));
                }
            }
            else
            {
                int Q = Convert.ToInt32(args[0]);
                for (int a0 = 0; a0 < Q * 2; a0 += 2)
                {
                    int n = Convert.ToInt32(args[a0 + 1]);
                    string b = args[a0 + 2];
                }
            }
        }

        //To determine the board, we should just need to sort the string, pair off all "colors". 
        // * We can't sort the board if it doesn't have an "_".
        public static string IsHappy(string b)
        {
            Dictionary<char, uint> survey = new Dictionary<char, uint>();

            foreach (char c in b.ToCharArray())
            {
                survey = Add_To_Dictionary(survey, c);
            }

            if (b.Contains("_"))
            {
                // if any entries contain only 1, then return no.
                foreach (int n in survey.Values)
                    if (n.Equals(1))
                        return "NO";
                return "YES";
            }
            else
            {
                //No space for sorting, so need to determine if colors are already paired up.
                survey.Clear();

                char prev = '.';
                foreach (char c in b.ToCharArray())
                {
                    // add each color to dictionary, if it already exists, and previous one added is already in the dictionary then output no.
                    if (survey.ContainsKey(c) && prev != c)
                        return "NO";
                    else
                        survey = Add_To_Dictionary(survey, c);
                    prev = c;
                }
            }
            return "YES";
        }

        private static Dictionary<char, uint> Add_To_Dictionary(Dictionary<char, uint> survey, char color)
        {
            if (color.Equals('_'))
                // Ignore any underscores, they aren't colors.
                return survey;

            if (!survey.ContainsKey(color))
                survey.Add(color, 1);
            else
                survey[color]++;

            return survey;
        }
    }
}