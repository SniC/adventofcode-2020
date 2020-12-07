using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string line;
            var numbers = new List<int>();

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"input.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (int.TryParse(line, out int result))
                {
                    numbers.Add(result);
                }
                System.Console.WriteLine(line);
            }

            file.Close();

            FindAnswerWithTwoEntries(numbers);
            FindAnswerWithThreeEntries(numbers);

            // Suspend the screen.
            System.Console.ReadLine();
        }

        private static void FindAnswerWithTwoEntries(IReadOnlyList<int> numbers)
        {
            (int, int)? sum2020 = null;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        sum2020 = (numbers[i], numbers[j]);
                    }
                }
            }

            if (sum2020 != null)
            {
                System.Console.WriteLine($"The answer with two entries is {sum2020.Value.Item1 * sum2020.Value.Item2}.");
            }
        }

        private static void FindAnswerWithThreeEntries(IReadOnlyList<int> numbers)
        {
            (int, int, int)? sum2020 = null;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i + 1; j < numbers.Count - 1; j++)
                {
                    for (int k = i + 1; k < numbers.Count - 1; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            sum2020 = (numbers[i], numbers[j], numbers[k]);
                        }
                    }
                }
            }

            if (sum2020 != null)
            {
                System.Console.WriteLine($"The answer with three entries is {sum2020.Value.Item1 * sum2020.Value.Item2 * sum2020.Value.Item3}.");
            }
        }
    }
}
