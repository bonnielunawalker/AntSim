using SwinGameSDK;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace MyGame
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static List<IDrawable> _drawables = new List<IDrawable>();
        private static List<Food> _food = new List<Food>();
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

            if (GameState.Setup)
            {
                _nest = new Nest(new Location(_rand.Next(720), _rand.Next(480)));
                _drawables.Add(_nest);

                for (int i = 0; i < 9; i++)
                    _nest.Ants.Add(new Ant(new Location(_nest.Location.X, _nest.Location.Y), _nest));

                foreach (Ant a in _nest.Ants)
                {
                    a.Move();
                    _drawables.Add(a);
                }

                for (int i = 0; i < 5; i++)
                    _food.Add(new Food(new Location(_rand.Next(720), _rand.Next(480))));

                foreach (Food f in _food)
                    _drawables.Add(f);

                GameState.Setup = false;
            }

            foreach (Ant a in _nest.Ants)
            {
                if (a.Wander)
                    a.CheckFood();

                a.Move();
            }

        }

        public static void DrawObjects()
        {
            foreach (IDrawable obj in _drawables)
                obj.Draw();
        }
    }
}