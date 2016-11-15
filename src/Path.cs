using System;
using System.Collections.Generic;
using System.Linq;

namespace AntSim
{
    public class Path
    {
        private LinkedList<Node> _waypoints;
        private LinkedList<Node> _closed;
        private PriorityQueue<Node> _open;
        private readonly Location _destination;
        private readonly Location _startingNode;

        public Path(Location l, Location d)
        {
            _destination = d;
            _startingNode = l;

            AddInitialNode(l);

            GetRoute();
            CreateWaypoints();
        }

        public Path(LinkedList<Node> waypoints)
        {
            _waypoints = waypoints;
            _destination = new Location(waypoints.Last.Value);
        }

        private void AddInitialNode(Location l)
        {
            _closed = new LinkedList<Node>();
            _open = new PriorityQueue<Node>();

            _open.Add(PathingUtils.NodeAt(l.X, l.Y));
            _closed.AddFirst(PathingUtils.NodeAt(l.X, l.Y));
            _closed.First().AddNeigbours(_open, _closed);
        }

        private void GetRoute()
        {
            Node current = _open.First;

            LinkedListNode<Node> previous = _closed.First;

            while (!current.IsAt(_destination))
            {
                _closed.AddAfter(previous, current);
                previous = previous.Next;

                current.AddNeigbours(_open, _closed);

                _open.Remove(current);

                current = _open.PriorityItem(Node.GetFScore, PathingUtils.CompareScores,
                    PathingUtils.NodeAt(_destination));
            }
        }

        private void CreateWaypoints()
        {
            CreateInitialWaypoint();
            LinkedListNode<Node> currentNode = _closed.Last;
            LinkedListNode<Node> previousNode = _waypoints.First;

            while (!currentNode.Value.IsAt(_startingNode))
            {
                currentNode = currentNode.Previous;
                _waypoints.AddAfter(previousNode, currentNode.Value);
            }
        }

        private void CreateInitialWaypoint()
        {
            _waypoints = new LinkedList<Node>();
            LinkedListNode<Node> currentNode = _closed.Last;
            _waypoints.AddFirst(currentNode.Value);
        }

        // Manually constructs a path by backtracking over pheremones.
        public static Path ConstructPathFromTrail(Pheromone p)
        {
            Pheromone pToCheck = p;

            LinkedList<Node> waypoints = new LinkedList<Node>();
            waypoints.AddFirst(World.Instance.Grid[p.X, p.Y]);
            LinkedListNode<Node> parentListNode = waypoints.First;

            Pheromone parent = World.Instance.PheremoneAt(waypoints.First.Value).Parent;

            do
            {
                Node newNode = World.Instance.Grid[pToCheck.X, pToCheck.Y];
                waypoints.AddAfter(parentListNode, newNode);
                parentListNode = waypoints.Find(World.Instance.Grid[pToCheck.X, pToCheck.Y]);
                pToCheck = parent;
                parent = pToCheck.Parent;

                // Sometimes pheremone trails will point in loops that don't lead to food.
                // If this happens, we simply return a path to a random food object.
                if (waypoints.Count > 5000)
                    return new Path(p.Location, World.Instance.Foods[GameLogic.Random.Next(World.Instance.Foods.Count - 1)].Location);
            } while (parent != null && !parent.Location.IsAt(pToCheck.Location));

            // Once the trail reaches the edge of the food object, finish the path by pathing to the centre of the nearest food.
            // This avoids hangs where ants can't quite reach the food and pathfind forever.
            Food destination = World.Instance.NearestFood(pToCheck.Location);
            Node finalNode = World.Instance.Grid[destination.X, destination.Y];
            waypoints.AddAfter(parentListNode, finalNode);

            return new Path(waypoints);
        }

        public Node NextWaypoint(Node w)
        {
            LinkedListNode<Node> current = _waypoints.Find(w);
            try
            {
                return current.Next.Value;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public LinkedList<Node> Waypoints
        {
            get { return _waypoints; }
        }

        public Node LastWaypoint
        {
            get { return _waypoints.Last.Value; }
        }

        public Location Destination
        {
            get { return _destination; }
        }
    }
}
