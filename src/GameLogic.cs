using SwinGameSDK;
using System;

namespace MyGame
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static Renderer _renderer = new Renderer();
        private static int _pheremoneDecayRate = 2;

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

            foreach (Pheremone p in World.Instance.Pheremones)
            {
                if (!Renderer.Drawables.Contains(p))
                    Renderer.AddDrawable(p);

                if (p.Strength < _pheremoneDecayRate)
                    p.Strength = 0;

                if (p.Strength > 0)
                    p.Strength -= _pheremoneDecayRate;
            }

            for (int i = World.Instance.Pheremones.Count - 1; i >= 0; i--)
            {
                if (World.Instance.Pheremones[i].Strength == 0)
                    World.Instance.Pheremones.RemoveAt(i);
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