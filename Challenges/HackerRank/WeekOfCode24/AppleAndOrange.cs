using System;

namespace Challenges.HackerRank.WeekOfCode24
{
    public class AppleAndOrange
    {
        static void Main(String[] args)
        {
            string[] tokens_s = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int t = Convert.ToInt32(tokens_s[1]);
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] apple_temp = Console.ReadLine().Split(' ');
            int[] apples = Array.ConvertAll(apple_temp, Int32.Parse);
            string[] orange_temp = Console.ReadLine().Split(' ');
            int[] oranges = Array.ConvertAll(orange_temp, Int32.Parse);

            Console.WriteLine(Count(apples, s, t, a));
            Console.WriteLine(Count(oranges, s, t, b));

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        private static void DefaultUserInput()
        {

        }

        public static int Count(int[] fruit_list, int house_bound_left, int house_bound_right, int tree_location)
        {
            int count = 0;
            foreach (int fruit_relative in fruit_list)
            {
                int fruit = tree_location + fruit_relative;
                if (house_bound_left <= fruit && fruit <= house_bound_right)
                    count++;
            }
            return count;
        }
    }
}