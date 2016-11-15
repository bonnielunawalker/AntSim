using System;
using System.Collections.Generic;

namespace AntSim
{
    public class Node: Location
    {
        private double _gScore;
        private Pheromone _pheromone;

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
            int xMax = World.Instance.Grid.GetLength(0);
            int yMax = World.Instance.Grid.GetLength(1);

            for (int x = X - 1; x <= X + 1; x++)
                for (int y = Y - 1; y <= Y + 1; y++)
                    if (InGrid(xMax, yMax, x, y))
                    {
                        newNode = World.Instance.Grid[x,y];
                        if (!newNode.IsIn(open) && !newNode.IsIn(closed))
                        {
                            open.Add(newNode);
                            newNode.GScore = GetGScore(newNode);
                        }
                    }
        }

        public static double GetFScore (Node destination, Node nodeToCheck)
        {
            double distance = nodeToCheck.GScore;
            int manhattan = PathingUtils.GetHScore (nodeToCheck, destination);

            return distance + manhattan;
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

        public double PheremoneStrength
        {
            get
            {
                if (_pheromone == null)
                    return 0;
                return _pheromone.Size * Pheromone.SizeFactor;
            }
        }

        // Adding and removing pheremones from the renderer is handled by this property
        // TODO: Too highly coupled?
        public Pheromone Pheromone
        {
            get
            {
                if (_pheromone == null)
                    _pheromone = new Pheromone(new Location(X, Y), 0);

                if (_pheromone.Size > 0 && !GameLogic.Renderer.Drawables.Contains(_pheromone))
                    GameLogic.Renderer.AddDrawable(_pheromone);

                return _pheromone;
            }
            set
            {
                _pheromone = value;
                if (_pheromone.Size == 0)
                    GameLogic.Renderer.RemoveDrawable(_pheromone);
            }
        }

        public double GScore
        {
            get { return _gScore; }
            set { _gScore = value; }
        }
    }
}