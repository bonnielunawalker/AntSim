using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyGame
{
    public class Path
    {
        private readonly Random _rand;
        private readonly LinkedList<Waypoint> _waypoints;
        private readonly Location _destination;
        private List<Node> _closed;
        private List<Node> _open;

        public Path(Location l, Location d)
        {
            _rand = GameLogic.Random;
            _destination = d;
            _waypoints = new LinkedList<Waypoint>();
            _closed = new List<Node>();
            _open = new List<Node>();
            _closed.Add(new Node(l.X, l.Y, 0));
            _waypoints.AddFirst(new Waypoint(new Location(l.X, l.Y), 0));
            AddNeigbours(_closed.First());
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

        private void AddNeigbours(Node n)
        {
            Node north = new Node(n.X, n.Y - 1, n.GScore);
            Node south = new Node(n.X, n.Y + 1, n.GScore);
            Node east = new Node(n.X - 1, n.Y, n.GScore);
            Node west = new Node(n.X + 1, n.Y, n.GScore);
            Node northeast = new Node(n.X - 1, n.Y - 1, n.GScore);
            Node southeast = new Node(n.X - 1, n.Y + 1, n.GScore);
            Node northwest = new Node(n.X - 1, n.Y + 1, n.GScore);
            Node southwest = new Node(n.X + 1, n.Y + 1, n.GScore);

            _open.Add(north);
            _open.Add(south);
            _open.Add(east);
            _open.Add(west);
            _open.Add(northeast);
            _open.Add(southeast);
            _open.Add(northwest);
            _open.Add(southwest);
        }

        private Node GetPriorityNode(Node current)
        {
            int score;
            int lowestScore = 2073600;
            Node bestNode = null;

            foreach (Location l in _open)
            {
                score = GetFScore(current, l);

                if (score < lowestScore)
                {
                    lowestScore = score;
                    bestNode = l as Node;
                }
            }

            return bestNode;
        }

        private int GetFScore(Node current, Location destination)
        {
            int manhattanX, manhattanY, distance;

            distance = current.GScore + 1;

            manhattanX = Math.Abs(current.X - destination.X);
            manhattanY = Math.Abs(current.Y - destination.Y);

            return distance + manhattanX + manhattanY;
        }
    }
}