using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame
{
    public class Path
    {
        private LinkedList<Waypoint> _waypoints;
        private LinkedList<Node> _closed;
        private List<Node> _open;
        private readonly Location _destination;
        private readonly Location _startingNode;

        public Path(Location l, Location d)
        {
            _destination = d;
            _startingNode = l;

            AddInitialNode(l);

            PathingUtils.AddNeigbours(_open, _closed, _closed.First());

            GetRoute();
            CreateWaypoints();
        }

        private void AddInitialNode(Location l)
        {
            _closed = new LinkedList<Node>();
            _open = new List<Node>();

            _closed.AddFirst(PathingUtils.NodeAt(l.X, l.Y));
        }

        public void GetRoute()
        {
            Node current = _open[0];
            LinkedListNode<Node> previous = _closed.First;

            while (!current.IsAt(_destination))
            {
                _closed.AddAfter(previous, current);
                previous = previous.Next;

                PathingUtils.AddNeigbours(_open, _closed, current);

                _open.Remove(current);

                current = PathingUtils.GetPriorityNode(_open, _destination);
            }
        }

        private void CreateWaypoints()
        {
            _waypoints = new LinkedList<Waypoint>();
            LinkedListNode<Node> currentNode = _closed.Last;
            _waypoints.AddFirst(new Waypoint(currentNode.Value));
            LinkedListNode<Waypoint> currentWaypoint = _waypoints.First;

            while (!currentNode.Value.IsAt(_startingNode))
            {
                currentNode = currentNode.Previous;
                _waypoints.AddAfter(currentWaypoint, new Waypoint(currentNode.Value));
            }
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
    }
}
