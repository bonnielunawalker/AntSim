namespace MyGame
{
    public class Waypoint : IDrawable
    {
        private readonly Location _location;
        private readonly int _gScore;

        public Waypoint(Location l, int gScore)
        {
            _location = l;
            _gScore = gScore;
        }

        public Location Location
        {
            get { return _location; }
        }

        public int X
        {
            get { return _location.X; }
        }

        public int Y
        {
            get { return _location.Y; }
        }

        public bool IsAt(Location d)
        {
            return _location.X == d.X && _location.Y == d.Y;
        }

        public void Draw()
        {
            //SwinGame.FillRectangle(Color.Blue, _location.X, _location.Y, 4, 4);
            return;
        }
    }
}