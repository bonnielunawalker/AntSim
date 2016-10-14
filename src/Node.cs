using System.Collections.Generic;

namespace MyGame
{
    public class Node: Location
    {
        private double _gScore;
        private Pheremone _pheremone;

        public Node(int x, int y, double gScore)
            :base(x, y)
        {
            _gScore = gScore;
            _pheremone = new Pheremone(new Location(X, Y), 0);
        }

        public Node(Node n)
            :base(n.X, n.Y)
        {
            _gScore = n.GScore;
            _pheremone = new Pheremone(new Location(X, Y), 0);
        }

        public Node(int x, int y)
            :this(x, y, 0)
        {

        }

        public void AddNeigbours(List<Node> open, LinkedList<Node> closed)
        {
            Node newNode;

            for (int x = X - 1; x <= X + 1; x++)
                for (int y = Y - 1; y <= Y + 1; y++)
                {
                    newNode = PathingUtils.NodeAt(x, y);
                    if (newNode != null && !newNode.IsIn(open) && !newNode.IsIn(closed))
                        open.Add(newNode);
                }
        }

        public bool IsIn(List<Node> list)
        {
            return list.Contains(this);
        }

        public bool IsIn(LinkedList<Node> list)
        {
            return list.Contains(this);
        }

        public Pheremone Pheremone
        {
            get { return _pheremone; }
            set { _pheremone = value; }
        }

        public double GScore
        {
            get { return _gScore; }
            set { _gScore = value; }
        }
    }
}