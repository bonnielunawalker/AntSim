namespace MyGame
{
    public class Node: Location
    {
        private readonly int _gScore;

        public Node(int x, int y, int gScore)
            :base(x, y)
        {
            _gScore = gScore;
        }

        public Node(int x, int y)
            :this(x, y, 0)
        {

        }

        public int GScore
        {
            get { return _gScore; }
        }
    }
}