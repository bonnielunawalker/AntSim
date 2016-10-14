using System.Collections.Generic;

namespace MyGame
{
    public class Grid
    {
        private Node[,] _nodes;

        public Grid()
        {
            _nodes = new Node[GameState.WindowHeight - 1, GameState.WindowWidth - 1];
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

        public Node[,] Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
    }
}