using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class GameLogic
    {
        private static readonly Random _rand = new Random();
        private static List<Food> _foods = new List<Food>();
        private static List<Obstacle> _obstacles = new List<Obstacle>();
        private static List<Pheremone> _pheremones = new List<Pheremone>();
        private static Nest _nest;
        private static Renderer _renderer = new Renderer();
        private static int _pheremoneDecayRate = 20;

        // Methods
        public static void Process()
        {
            SwinGame.ProcessEvents();

            Food.RemoveEmptyFoods(_foods);

            foreach (Ant a in _nest.Ants)
                a.Move();

            _nest.CreateNewAnts();

            foreach (Pheremone p in _pheremones)
            {
                if (!Renderer.Drawables.Contains(p))
                    Renderer.AddDrawable(p);

                if (p.Strength < _pheremoneDecayRate)
                    p.Strength = 0;

                if (p.Strength > 0)
                    p.Strength -= _pheremoneDecayRate;
            }
        }


        // Properties
        /* Allows a single instance of Random to be used throughout the program.
           This avoids the possibility of duplicate random values being generated. */
        public static Random Random
        {
            get { return _rand; }
        }

        public static List<Food> Foods
        {
            get { return _foods; }
            set { _foods = value; }
        }

        public static Nest Nest
        {
            get { return _nest; }
            set { _nest = value; }
        }

        public static List<Obstacle> Obstacles
        {
            get { return _obstacles; }
            set { _obstacles = value; }
        }

        public static List<Pheremone> Pheremones
        {
            get { return _pheremones; }
            set { _pheremones = value; }
        }

        public static Renderer Renderer
        {
            get { return _renderer; }
            set { _renderer = value; }
        }
    }
}