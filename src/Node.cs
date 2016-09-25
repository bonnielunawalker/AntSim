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

        public int GScore
        {
            get { return _gScore; }
        }
    }
}