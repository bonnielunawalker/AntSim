using System.Collections.Generic;

namespace MyGame
{
    public class Path
    {
        private List<Waypoint> _waypoints;
        private Location _destination;

        public Path(Location d)
        {
            _destination = d;
            _waypoints = new List<Waypoint>();
            GetRoute();
        }

        private void GetRoute()
        {
            while (!_waypoints[_waypoints.Count - 1].IsAt(_destination))
            {
                _waypoints[_waypoints.Count] = GetNewWaypoint(_waypoints, _waypoints.Count, _destination);
            }
        }

        private Waypoint GetNewWaypoint(List<Waypoint> w, int idx, Location d)
        {
            int newX;
            int newY;

            if (w[idx].Location.X < d.X)
                newX = w[idx].Location.X + 5;
            else if (w[idx].Location.X > d.X)
                newX = w[idx].Location.X - 5;
            else
                newX = w[idx].Location.X;

            if (w[idx].Location.Y < d.Y)
                newY = w[idx].Location.Y + 5;
            else if (w[idx].Location.Y > d.Y)
                newY = w[idx].Location.Y - 5;
            else
                newY = w[idx].Location.Y;

            return new Waypoint(new Location(newX, newY), w[idx]);
        }
    }
}