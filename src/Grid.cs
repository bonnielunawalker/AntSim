using System.Collections.Generic;

namespace MyGame
{
    public class Grid
    {
        private List<Node> _nodes;

        public Grid()
        {
            _nodes = new List<Node>();
            GenerateNodes();
        }

        private void GenerateNodes()
        {
            for (int x = 0; x < GameState.WindowWidth; x++)
            {
                for (int y = 0; y < GameState.WindowHeight; y++)
                    _nodes.Add(new Node(x, y));
            }
        }

        public void ResetGScores()
        {
            foreach (Node n in _nodes)
                n.GScore = 0;
        }

        public List<Node> Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }
    }
}