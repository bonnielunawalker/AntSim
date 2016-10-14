using System.Collections.Generic;

namespace MyGame
{
    public class World
    {
        private List<Food> _foods;
        private List<Obstacle> _obstacles;
        private List<Pheremone> _pheremones;
        private Nest _nest;
        private Grid _grid;

        private static World _instance;

        public World()
        {
            _foods = new List<Food>();
            _obstacles = new List<Obstacle>();
            _pheremones = new List<Pheremone>();

            _grid = new Grid();

            _instance = this;
        }

        public static World Touch()
        {
            return Instance;
        }

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

        public List<Obstacle> Obstacles
        {
            get { return _obstacles; }
            set { _obstacles = value; }
        }

        public List<Pheremone> Pheremones
        {
            get { return _pheremones; }
            set { _pheremones = value; }
        }

        public Grid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
    }
}