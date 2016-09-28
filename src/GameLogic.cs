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
        private static List<IDrawable> _drawables = new List<IDrawable>();

        public static void Process()
        {
            SwinGame.ProcessEvents();

            foreach (Ant a in _nest.Ants)
            {
                if (a.Wandering)
                    a.CheckForFood();

                a.Move();
            }

            RemoveEmptyFoods();

            _nest.CreateNewAnts();
        }

        public static void Setup()
        {
            Console.WriteLine("Generating entities...");
            GenerateEntities();
            Console.WriteLine("Done!");
            Console.WriteLine("Adding objects to game grid...");
            AddEntitiesToEnvironment();
            Console.WriteLine("Done!");
        }

        private static void GenerateEntities()
        {
            _nest = new Nest(new Location(GameState.WindowWidth / 2, GameState.WindowHeight / 2));

            for (int i = 0; i < 3; i++)
                _nest.Ants.Add(new Ant(_nest));

            for (int i = 0; i < 10; i++)
                _food.Add(new Food(new Location()));

            for (int i = 0; i < _rand.Next(10, 40); i++)
                _obstacles.Add(new Obstacle(new Location()));
        }

        private static void AddEntitiesToEnvironment()
        {
            _drawables.Add(_nest);

            foreach (Food f in _food)
                _drawables.Add(f);

            foreach (Ant a in _nest.Ants)
                _drawables.Add(a);

//            foreach (Obstacle o in _obstacles)
//                _drawables.Add(o);
        }

        public static void DrawObjects()
        {
            foreach (IDrawable obj in _drawables)
                obj.Draw();
        }

        private static void RemoveEmptyFoods()
        {
            for (int i = _food.Count - 1; i >= 0; i--)
            {
                if (_food[i].Size == 0)
                {
                    _food.RemoveAt(i);
                    _drawables.Remove(_food[i]);
                }
            }
        }


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

        public static List<IDrawable> Drawables
        {
            get { return _drawables; }
            set { _drawables = value; }
        }
    }
}