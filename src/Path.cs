using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Path
    {
        private readonly Random _rand;
        private readonly LinkedList<Waypoint> _waypoints;
        private readonly Location _destination;

        public Path(Location l, Location d)
        {
            _rand = GameLogic.Random;
            _destination = d;
            _waypoints = new LinkedList<Waypoint>();
            _waypoints.AddFirst(new Waypoint(new Location(l.X, l.Y)));
            GetRoute();
        }

        public LinkedList<Waypoint> Waypoints
        {
            get { return _waypoints; }
        }

        public Location Destination
        {
            get { return _destination; }
        }

        public LinkedList<Waypoint> Waypoint
        {
            get { return _waypoints; }
        }

        public Waypoint NextWaypoint(Waypoint w)
        {
            LinkedListNode<Waypoint> current = _waypoints.Find(w);
            return current.Next.Value;
        }

        private void GetRoute()
        {
            while (!_waypoints.Last.Value.IsAt(_destination))
                _waypoints.AddAfter(_waypoints.Last, GetNewWaypoint(_waypoints.Last.Value, _destination));
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