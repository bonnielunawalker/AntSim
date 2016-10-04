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
        private static Nest _nest;
        private static Renderer _renderer = new Renderer();

        // Methods
        public static void Process()
        {
            SwinGame.ProcessEvents();

            Food.RemoveEmptyFoods(_foods);

            foreach (Ant a in _nest.Ants)
            {
                if (a.Wandering)
                    a.CheckForFood();

                a.Move();
            }

            _nest.CreateNewAnts();
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

        public static Renderer Renderer
        {
            get { return _renderer; }
            set { _renderer = value; }
        }
    }
}