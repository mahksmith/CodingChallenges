using System;
using System.Collections.Generic;
using System.IO;

namespace Challenges.HackerRank.WeekOfCode24
{
    public class HappyLadybugs
    {
        static void Main(String[] args)
        {
            foreach (string s in ReadStream(Console.In))
            {
                Console.WriteLine(s);
            }
        }

        public static string[] ReadStream(TextReader tr)
        {
            int Q = Convert.ToInt32(tr.ReadLine());
            string[] ret = new string[Q];

            for (int a0 = 0; a0 < Q; a0++)
            {
                int n = Convert.ToInt32(tr.ReadLine());
                string b = tr.ReadLine();

                ret[a0] = IsHappy(b);
            }

            return ret;
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
                string last_ret = "";
                foreach (char c in b.ToCharArray())
                {
                    if (prev != c && last_ret.Equals("NO"))
                        return last_ret;
                    else if (prev != c)
                        last_ret = "NO";
                    else if (prev == c)
                        last_ret = "YES";
                    
                    prev = c;
                }
                return last_ret;
            }
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