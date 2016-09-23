using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Path
    {
        private readonly Random _rand;
        private readonly LinkedList<Waypoint> _waypoints;
        private readonly Location _destination;
        private List<Location> _closed;
        private List<Location> _open;

        public Path(Location l, Location d)
        {
            _rand = GameLogic.Random;
            _destination = d;
            _waypoints = new LinkedList<Waypoint>();
            _waypoints.AddFirst(new Waypoint(new Location(l.X, l.Y), 0));
        }

        public LinkedList<Waypoint> Waypoints
        {
            get { return _waypoints; }
        }

        public Waypoint LastWaypoint
        {
            get { return _waypoints.Last.Value; }
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
            try
            {
                return current.Next.Value;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public void GetRoute()
        {

        }

        private void AddNeigbours(Location l)
        {
            Location up = new Location(l.X, l.Y-1);
            Location down = new Location(l.X, l.Y + 1);
            Location left = new Location(l.X-1, l.Y);
            Location right = new Location(l.X+1, l.Y);

            _open.Add(up);
            _open.Add(down);
            _open.Add(left);
            _open.Add(right);
        }
    }
}