namespace AntSim
{
    public class Grid
    {
        private Node[,] _nodes;

        public Grid(int width, int height)
        {
            _nodes = new Node[width, height];
            GenerateNodes();
        }

        private void GenerateNodes()
        {
            for (int x = 0; x < _nodes.GetLength(0); x++)
                for (int y = 0; y < _nodes.GetLength(1); y++)
                    _nodes[x,y] = new Node(x, y);
        }

        public void ResetGScores()
        {
            foreach (Node n in _nodes)
                n.GScore = 0;
        }

        public int GetLength(int dimension)
        {
            return _nodes.GetLength(dimension);
        }

        public Node this[int x, int y]
        {
            get { return _nodes[x, y]; }
            set { _nodes[x, y] = value; }
        }
    }
}