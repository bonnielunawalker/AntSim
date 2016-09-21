using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static List<IDrawable> _drawables = new List<IDrawable>();
        private static List<Food> _food = new List<Food>();
        private static List<Obstacle> _obstacles = new List<Obstacle>();
        private static Nest _nest;

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
            _nest = new Nest(new Location(GameState.WindowWidth / 2, GameState.WindowHeight / 2));
            _drawables.Add(_nest);

            for (int i = 0; i < 100; i++)
                _nest.Ants.Add(new Ant(new Location(_nest.Location), _nest));

            foreach (Ant a in _nest.Ants)
            {
                a.Move();
                _drawables.Add(a);
                _drawables.Add(a.CurrentPath.Waypoints.Last.Value);
            }

            for (int i = 0; i < 5; i++)
                _food.Add(new Food(new Location()));

            foreach (Food f in _food)
                _drawables.Add(f);

            for (int i = 0; i < _rand.Next(10, 40); i++)
                _obstacles.Add(new Obstacle(new Location()));

            foreach (Obstacle o in _obstacles)
                _drawables.Add(o);
        }

        public static void DrawObjects()
        {
            foreach (IDrawable obj in _drawables)
                obj.Draw();
        }
    }
}