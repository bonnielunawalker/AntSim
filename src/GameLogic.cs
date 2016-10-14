using SwinGameSDK;
using System;

namespace MyGame
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static Renderer _renderer = new Renderer();
        private static Grid _grid = World.Instance.Grid;

        // Methods
        public static void Process()
        {
            SwinGame.ProcessEvents();

            Food.RemoveEmptyFoods(World.Instance.Foods);

            foreach (Ant a in World.Instance.Nest.Ants)
            {
                Renderer.Drawables.RemoveAll(item => item is Waypoint);
                a.Move();
                Console.WriteLine("{0},{1}", a.Location.X, a.Location.Y);
            }

            World.Instance.Nest.CreateNewAnts();

            for (int x = 0; x < _grid.Nodes.GetLength(0); x++)
                for (int y = 0; y < _grid.Nodes.GetLength(1); y++)
                {
                    Pheremone p = _grid.Nodes[x,y].Pheremone;
                    p.Decay();
                }
        }


        // Properties
        /* Allows a single instance of Random to be used throughout the program.
           This avoids the possibility of duplicate random values being generated. */
        public static Random Random
        {
            get { return _rand; }
        }

        public static Renderer Renderer
        {
            get { return _renderer; }
            set { _renderer = value; }
        }
    }
}