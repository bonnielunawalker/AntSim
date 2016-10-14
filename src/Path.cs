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


            // Add the initial node's neighbour nodes to the open list.
            _closed.First().AddNeigbours(_open, _closed);

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

                current.AddNeigbours(_open, _closed);

                _open.Remove(current);

                current = PathingUtils.GetPriorityNode(_open, _destination);
            }
        }

        private void CreateWaypoints()
        {
            CreateInitialWaypoint();
            LinkedListNode<Node> currentNode = _closed.Last;
            LinkedListNode<Waypoint> currentWaypoint = _waypoints.First;

            while (!currentNode.Value.IsAt(_startingNode))
            {
                currentNode = currentNode.Previous;
                _waypoints.AddAfter(currentWaypoint, new Waypoint(currentNode.Value));
            }
        }

        private void CreateInitialWaypoint()
        {
            _waypoints = new LinkedList<Waypoint>();
            LinkedListNode<Node> currentNode = _closed.Last;
            _waypoints.AddFirst(new Waypoint(currentNode.Value));
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
