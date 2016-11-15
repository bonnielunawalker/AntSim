using SwinGameSDK;
using System;

namespace AntSim
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static Renderer _renderer = new Renderer();
        private static Grid _grid = World.Instance.Grid;

        public static void Process()
        {
            SwinGame.ProcessEvents();

            Food.RemoveEmptyFoods(World.Instance.Foods);

            foreach (Ant a in World.Instance.Nest.Ants)
            {
                a.GetMove();
                a.Move();
            }

            World.Instance.Nest.CreateNewAnts();

            ProcessPheremoneDecay();
        }

        private static void ProcessPheremoneDecay()
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    Pheromone p = _grid[x,y].Pheromone;
                    p.Decay();
                }
        }

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