using System;
using System.IO;

namespace Challenges.HackerRank.WeekOfCode24
{
    public class AppleAndOrange
    {
        private int house_bound_left, house_bound_right;
        private int apple_tree, orange_tree;
        private int apple_count, orange_count;
        private int[] apples, oranges; 
        static void Main(String[] args)
        {
            AppleAndOrange aor = new AppleAndOrange();
            aor.ReadStream(Console.In);

            Console.WriteLine(aor.Count("apple"));
            Console.WriteLine(aor.Count("orange"));

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        public void ReadStream(TextReader tr)
        {
            string[] tokens_s = tr.ReadLine().Split(' ');
            house_bound_left = Convert.ToInt32(tokens_s[0]);
            house_bound_right = Convert.ToInt32(tokens_s[1]);
            string[] tokens_a = tr.ReadLine().Split(' ');
            apple_tree = Convert.ToInt32(tokens_a[0]);
            orange_tree = Convert.ToInt32(tokens_a[1]);
            string[] tokens_m = tr.ReadLine().Split(' ');
            apple_count = Convert.ToInt32(tokens_m[0]);
            orange_count = Convert.ToInt32(tokens_m[1]);
            string[] apple_temp = tr.ReadLine().Split(' ');
            apples = Array.ConvertAll(apple_temp, Int32.Parse);
            string[] orange_temp = tr.ReadLine().Split(' ');
            oranges = Array.ConvertAll(orange_temp, Int32.Parse);


        }
        
        public int Count(string type)
        {
            switch (type) {
                case "apple":
                    return Count(house_bound_left, house_bound_right, apple_tree, apples);
                case "orange":
                    return Count(house_bound_left, house_bound_right, orange_tree, oranges);
            }

            return 0;
        }

        public static int Count(int house_bound_left, int house_bound_right, int tree_location, int[] fruit_list)
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