using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Path
    {
        private Random _rand = new Random();
        private LinkedList<Waypoint> _waypoints;
        private Location _destination;

        public Path(Location l, Location d)
        {
            _destination = d;
            _waypoints = new LinkedList<Waypoint>();
            _waypoints.AddFirst(new Waypoint(new Location(l.X, l.Y)));
            GetRoute();
        }

        private void GetRoute()
        {
            while (!_waypoints.Last.Value.IsAt(_destination))
            {
                _waypoints.AddAfter(_waypoints.Last, GetNewWaypoint(_waypoints.Last.Value, _destination));
            }
        }

        private Waypoint GetNewWaypoint(Waypoint w, Location d)
        {
            int newX;
            int newY;

            if (w.Location.X < d.X)
                newX = w.Location.X + _rand.Next(0, 5);
            else if (w.Location.X > d.X)
                newX = w.Location.X - _rand.Next(0, 5);
            else
                newX = w.Location.X;

            if (w.Location.Y < d.Y)
                newY = w.Location.Y + _rand.Next(0, 5);
            else if (w.Location.Y > d.Y)
                newY = w.Location.Y - _rand.Next(0, 5);
            else
                newY = w.Location.Y;

            return new Waypoint(new Location(newX, newY));
        }
    }
}