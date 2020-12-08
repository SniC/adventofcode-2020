using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TobogganTrajectory
{
    public class Slope
    {
        public Slope(List<string> lines)
        {
            this.Person = new Person();
            this.Lines = lines;
        }

        public void MovePersonToBottomWhileCountingTrees(int x, int y)
        {

            while (this.Person.Position.Y < this.Height - 1)
            {
                var newPosition = new Position(this.Person.Position.X + x, this.Person.Position.Y + y);

                if (newPosition.X > this.Width - 1)
                {
                    var difference = newPosition.X - this.Width;
                    newPosition = new Position(difference, newPosition.Y);
                }

                this.Person.MoveTo(newPosition);

                if (this.IsTreeOnPosition(this.Person.Position))
                {
                    this.Person.CountTree();
                }
            }
        }

        private bool IsTreeOnPosition(Position position)
        {
            Console.WriteLine("Person at {0},{1}", this.Person.Position.X, this.Person.Position.Y);

            var line = this.Lines[position.Y];
            var treeFound = line[position.X] == '#';

            if (treeFound)
            {
                StringBuilder sb = new StringBuilder(line);
                sb[position.X] = 'X';
                line = sb.ToString();
            }
            
            Console.WriteLine(line);

            return treeFound;
        }

        public Person Person { get; private set; }

        public List<string> Lines { get; private set; }

        public int Height => this.Lines.Count;

        public int Width => this.Lines.First().Length;
    }
}
