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
            List<Node> newNodes = new List<Node>();

            newNodes.Add(PathingUtils.NodeAt(X, Y - 1));
            newNodes.Add(PathingUtils.NodeAt(X, X + 1));
            newNodes.Add(PathingUtils.NodeAt(X - 1, Y));
            newNodes.Add(PathingUtils.NodeAt(X + 1, Y));

            newNodes.Add(PathingUtils.NodeAt(X + 1, Y - 1));
            newNodes.Add(PathingUtils.NodeAt(X + 1, Y + 1));
            newNodes.Add(PathingUtils.NodeAt(X - 1, Y - 1));
            newNodes.Add(PathingUtils.NodeAt(X - 1, Y + 1));

            for (int i = 1; i < newNodes.Count; i++)
                if (newNodes[i] != null && !newNodes[i].IsIn(open) && !newNodes[i].IsIn(closed))
                    open.Add(newNodes[i]);
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