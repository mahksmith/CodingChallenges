using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Challenges.HackerRank.WeekOfCode24
{
    public class XORMatrix
    {

        static void Main(String[] args)
        {
            string[] matrix_size = Console.ReadLine().Split(' ');
            UInt64 columns = UInt64.Parse(matrix_size[0]);   // 0 < n < 10^5
            UInt64 rows = UInt64.Parse(matrix_size[1]);      // 0 < m < 10^18 

            string[] numbers_temp = Console.ReadLine().Split(' ');
            int[] numbers = Array.ConvertAll(numbers_temp, int.Parse);
            int[] solution = Solve(columns, rows, numbers);

            for (int i = 0; i < solution.Length; i++)
                Console.Write(solution[i] + " ");
            Console.WriteLine();

            if (Debugger.IsAttached)
                Console.Read();
        }

        private static int[] Solve(UInt64 columns, UInt64 rows, int[] numbers)
        {
            int[] new_row;

            Dictionary<string, UInt64> iterations = new Dictionary<string, UInt64>();
            Dictionary<string, UInt64> rotations = new Dictionary<string, UInt64>();

            List<int[]> rots = GenerateRotations(numbers);

            iterations.Add(string.Join(" ", Array.ConvertAll(numbers, Convert.ToString)), 0);



            for (UInt64 i = 1; i <= rows; i++)
            {
                new_row = new int[columns];

                for (UInt64 j = 0; j < columns; j++)
                {
                    UInt64 column_plus_one;
                    if (j + 1 >= columns)
                        column_plus_one = 0;
                    else
                        column_plus_one = j + 1;
                    new_row[j] = numbers[j] ^ numbers[column_plus_one];
                }
                numbers = new_row;

                //Detect array rotations.

                string key = string.Join(" ", Array.ConvertAll(new_row, Convert.ToString));
                if (iterations.ContainsKey(key))
                {
                    // A conflict means that this is now a repeating sequence. So we...
                    // Get the value, and subtract current, that is the length of repeating sequence..

                    UInt64 first_repeat;
                    iterations.TryGetValue(key, out first_repeat);


                    // The length of the looping iterations.
                    UInt64 period = i - first_repeat;

                    // Now we need to get the location in the loop of the theoretical last row by taking (rows - first_repeat) modulo'd by the period. 
                    UInt64 last_iteration = (rows - i - 1) % period;

                    // This remainder will be taken from the iterations to select the key of (first_repeat + remainder) to get the correct entry in sequence. 
                    return Array.ConvertAll(iterations.First(x => x.Value.Equals(first_repeat + last_iteration)).Key.Split(' '), Convert.ToInt32);

                }
                else
                {
                    iterations.Add(key, i);
                }

                //for (int x = 0; x < numbers.Length; x++)
                //    Console.Write(numbers[x] + " ");
                //Console.WriteLine();


            }


            return numbers;
        }

        private static List<int[]> GenerateRotations(int[] numbers)
        {
            List<int[]> rotations = new List<int[]>();

            int[] iteration = new int[numbers.Length];
            int[] last_iteration = new int[numbers.Length];

            Array.Copy(numbers, last_iteration, numbers.Length);

            for (int i = 0; i < numbers.Length - 1 /*0th iteration not required*/; i++)
            {
                iteration = new int[numbers.Length];
                Array.Copy(last_iteration, iteration, iteration.Length);

                int first = iteration[0];


                Array.Copy(iteration, 1, iteration, 0, numbers.Length - 1);
                iteration[iteration.Length - 1] = first;

                rotations.Add(iteration);
                Array.Copy(iteration, last_iteration, iteration.Length);
            }

            return rotations;
        }
    }
}