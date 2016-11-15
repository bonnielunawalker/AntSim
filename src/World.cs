using System;
using System.Collections.Generic;

namespace AntSim
{
    public class World
    {
        private List<Food> _foods;
        private Nest _nest;
        private Grid _grid;

        private static World _instance;

        public World()
        {
            _foods = new List<Food>();

            _grid = new Grid(GameState.WindowWidth - 1, GameState.WindowHeight - 1);

            _instance = this;
        }

        public static World CreateInstance()
        {
            return Instance;
        }

        public Pheromone PheremoneAt(int x, int y)
        {
            return Grid[x, y].Pheromone;
        }

        public Pheromone PheremoneAt(Location loc)
        {
            return PheremoneAt(loc.X, loc.Y);
        }

        public Food FoodAt(Location loc)
        {
            foreach(Food f in Instance.Foods)
                if (f.CheckCollision(loc))
                    return f;

            return null;
        }

        public bool FoodExistsAt(Location loc)
        {
            foreach (Food f in _foods)
                if (f.Location == loc)
                    return true;

            return false;
        }

        public Food NearestFood(Location loc)
        {
            Food bestFood = null;
            int bestScore = Int32.MaxValue;
            int currentScore = 0;

            foreach (Food f in _foods)
            {
                currentScore = (f.X - loc.X) + (f.Y - loc.Y);
                if (currentScore < bestScore)
                {
                    bestScore = currentScore;
                    bestFood = f;
                }
            }
            return bestFood;
        }

        // Not thread safe, but since we're running on one thread, this doesn't matter.
        public static World Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new World();
                return _instance;
            }
        }

        public List<Food> Foods
        {
            get { return _foods; }
            set { _foods = value; }
        }

        public Nest Nest
        {
            get { return _nest; }
            set { _nest = value; }
        }

        public Grid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
    }
}