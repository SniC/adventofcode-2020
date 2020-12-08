namespace TobogganTrajectory
{
    public class Person
    {
        public Person()
        {
            this.Position = new Position(0, 0);
        }

        public void MoveTo(Position position)
        {
            this.Position = position;
        }

        public void CountTree()
        {
            this.TreesCounted += 1;
        }

        public Position Position { get; private set; }

        public int TreesCounted { get; private set; }
    }
}
