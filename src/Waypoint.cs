namespace MyGame
{
    public class Waypoint : IHasLocation
    {
        private readonly Location _location;
        private readonly Waypoint _previous;

        public Waypoint(Location location, Waypoint w)
        {
            _location = location;
            _previous = w;
        }

        public Location Location
        {
            get { return _location; }
        }

        public Waypoint Previous
        {
            get { return _previous; }
        }
    }
}