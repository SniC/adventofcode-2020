using System;
using System.Collections.Generic;
using System.Linq;

namespace TobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new FileReader().GetLines();
            var slope = new Slope(lines.ToList());

            slope.MovePersonToBottomWhileCountingTrees(3, 1);

            Console.WriteLine("Amount of trees passed: {0}", slope.Person.TreesCounted);

            var traversals = new List<(int, int)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };

            var sums = new List<int>();

            traversals.ForEach(x =>
            {
                var slope = new Slope(lines.ToList());
                slope.MovePersonToBottomWhileCountingTrees(x.Item1, x.Item2);
                sums.Add(slope.Person.TreesCounted);
            });

            var multiplied = sums.Aggregate((a, x) => a * x);

            Console.WriteLine("Amount of trees passed multiplied: {0}", multiplied);
            Console.ReadLine();
        }
    }
}
