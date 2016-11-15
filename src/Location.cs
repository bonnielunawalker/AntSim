namespace AntSim
{
    public class Location
    {
        private int _x, _y;

        public Location(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // Location initialised with no parameters generates a random location.
        public Location()
            :this (GameLogic.Random.Next(0, GameState.WindowWidth), GameLogic.Random.Next(0, GameState.WindowHeight))
        {

        }

        public Location(Location l)
            : this(l.X, l.Y)
        {

        }

        public bool IsAt(Location d)
        {
            return _x == d.X && _y == d.Y;
        }

        public bool IsAt(Node n)
        {
            return _x == n.X && _y == n.Y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}