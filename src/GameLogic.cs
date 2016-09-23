using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static List<Food> _food = new List<Food>();
        private static List<Obstacle> _obstacles = new List<Obstacle>();
        private static Nest _nest;
        private static GameGrid _gameGrid = new GameGrid();

        // Allows a single instance of Random to be used throughout the program.
        // This avoids the possibility of duplicate random values being generated.
        public static Random Random
        {
            get { return _rand; }
        }

        public static List<Food> Food
        {
            get { return _food; }
            set { _food = value; }
        }

        public static void Process()
        {
            SwinGame.ProcessEvents();

            foreach (Ant a in _nest.Ants)
            {
                if (a.Wandering)
                    a.CheckFood();

                a.Move();
            }
        }

        public static void Setup()
        {
            Console.WriteLine("Generating entities...");
            GenerateEntities();
            Console.WriteLine("Done!");
            Console.WriteLine("Adding objects to game grid...");
            AddEntitiesToGrid();
            Console.WriteLine("Done!");
        }

        private static void GenerateEntities()
        {
            _nest = new Nest(new Location(GameState.WindowWidth / 2, GameState.WindowHeight / 2));

            for (int i = 0; i < 100; i++)
                _nest.Ants.Add(new Ant(new Location(_nest.Location), _nest));

            for (int i = 0; i < 5; i++)
                _food.Add(new Food(new Location()));

            for (int i = 0; i < _rand.Next(10, 40); i++)
                _obstacles.Add(new Obstacle(new Location()));
        }

        private static void AddEntitiesToGrid()
        {
            foreach (Ant a in _nest.Ants)
            {
                _gameGrid.Add(a);
                _gameGrid.Add(a.CurrentPath.LastWaypoint);
            }

            foreach (Food f in _food)
                _gameGrid.Add(f);

            foreach (Obstacle o in _obstacles)
                _gameGrid.Add(o);

            _gameGrid.Add(_nest);
        }

        public static void DrawObjects()
        {
            for (int i = 0; i < _gameGrid.Grid.GetLength(0); i++)
                for (int j = 0; j < _gameGrid.Grid.GetLength(1); j++)
                    if (_gameGrid.Grid[i, j] != null)
                        _gameGrid.Grid[i, j].Draw();
        }
    }
}