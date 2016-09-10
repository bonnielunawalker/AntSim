namespace MyGame
{
    public class Waypoint : IHasLocation
    {
        private readonly Location _location;

        public Waypoint(Location l)
        {
            _location = l;
        }

        public Location Location
        {
            get { return _location; }
        }

        public bool IsAt(Location d)
        {
            return _location.X == d.X && _location.Y == d.Y;
        }
    }
}