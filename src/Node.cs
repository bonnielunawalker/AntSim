using System.Collections.Generic;

namespace MyGame
{
    public class Node: Location
    {
        private double _gScore;

        public Node(int x, int y, double gScore)
            :base(x, y)
        {
            _gScore = gScore;
        }

        public Node(Node n)
            :base(n.X, n.Y)
        {
            _gScore = n.GScore;
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

        public double GScore
        {
            get { return _gScore; }
            set { _gScore = value; }
        }
    }
}