using System;
using System.Collections.Generic;
using System.Net.Configuration;

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

        public void AddNeigbours(PriorityQueue<Node> open, LinkedList<Node> closed)
        {
            Node newNode;
            int xMax = World.Instance.Grid.Nodes.GetLength(0);
            int yMax = World.Instance.Grid.Nodes.GetLength(1);

            for (int x = X - 1; x <= X + 1; x++)
                for (int y = Y - 1; y <= Y + 1; y++)
                    if (InGrid(xMax, yMax, x, y))
                    {
                        newNode = World.Instance.Grid.Nodes[x,y];
                        if (!newNode.IsIn(open) && !newNode.IsIn(closed))
                        {
                            open.Add(newNode);
                            newNode.GScore = GetGScore(newNode);
                        }
                    }
        }

        private double GetGScore(Node n)
        {
            // Calculates diagonal cost function.
            if (Math.Abs(n.X - X) == 1 && Math.Abs(n.Y - Y) == 1)
                return n.GScore + 1.41;

            return n.GScore + 1;
        }

        private bool InGrid(int xMax, int yMax, int x, int y)
        {
            return x < xMax && y < yMax && x >= 0 && y >= 0;
        }

        public bool IsIn(List<Node> list)
        {
            return list.Contains(this);
        }

        public bool IsIn(LinkedList<Node> list)
        {
            return list.Contains(this);
        }

        public bool IsIn(PriorityQueue<Node> queue)
        {
            return queue.Contains(this);
        }

        public int PheremoneStrength
        {
            get
            {
                if (_pheremone == null)
                    return 0;
                return _pheremone.Strength;
            }
        }

        public Pheremone Pheremone
        {
            get
            {
                if (_pheremone == null)
                    _pheremone = new Pheremone(new Location(X, Y), 0);

                if (_pheremone.Strength > 0 && !GameLogic.Renderer.Drawables.Contains(_pheremone))
                    GameLogic.Renderer.AddDrawable(_pheremone);

                return _pheremone;
            }
            set
            {
                _pheremone = value;
                if (_pheremone.Strength == 0)
                    GameLogic.Renderer.RemoveDrawable(_pheremone);
            }
        }

        public double GScore
        {
            get { return _gScore; }
            set { _gScore = value; }
        }
    }
}