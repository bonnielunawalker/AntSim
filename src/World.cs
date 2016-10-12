using System.Collections.Generic;

namespace MyGame
{
    public class World
    {
        private List<Food> _foods = new List<Food>();
        private List<Obstacle> _obstacles = new List<Obstacle>();
        private List<Pheremone> _pheremones = new List<Pheremone>();
        private Nest _nest;

        private static World _instance;

        public World()
        {
            _foods = new List<Food>();
            _obstacles = new List<Obstacle>();
            _pheremones = new List<Pheremone>();

            _instance = this;
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
    }
}