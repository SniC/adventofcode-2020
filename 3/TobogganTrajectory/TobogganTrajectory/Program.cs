using System;
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
            Console.ReadLine();
        }
    }
}
