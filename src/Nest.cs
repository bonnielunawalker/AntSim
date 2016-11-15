using SwinGameSDK;
using System.Collections.Generic;

namespace AntSim
{
    public class Nest : ICollidable
    {
        private readonly Location _location;
        private List<Ant> _ants;
        private readonly int _size;
        private int _food;
        private readonly Renderer.Layer _layer;
        private static int _foodThreshold = 2;

        public Nest(Location l)
        {
            _location = l;
            _ants = new List<Ant>();
            _size = 8;
            _layer = Renderer.Layer.Back;
        }

        public void Draw()
        {
            SwinGame.FillCircle(Color.Orange, _location.X, _location.Y, _size);
        }

        // TODO: Overhaul when replacing collisions with quadtrees
        // Currently placeholder. Does not accurately check collisions.
        public bool CheckCollision(Location l)
        {
            Point2D pointToCheck = new Point2D();
            pointToCheck.X = l.X;
            pointToCheck.Y = l.Y;
            return SwinGame.PointInCircle(pointToCheck, _location.X, _location.Y, _size);
        }

        public void CreateNewAnts()
        {
            if (FoodThresholdReached())
            {
                for (int i = 0; i <= _food / 10; i++)
                {
                    Ant newAnt = new Ant(this);
                    _ants.Add(newAnt);
                    GameLogic.Renderer.AddDrawable(newAnt);
                    _food -= _foodThreshold;
                }
            }
        }

        private bool FoodThresholdReached()
        {
            return _food >= _foodThreshold;
        }

        public void UpdateFood(ref int amount)
        {
            _food += amount;
            amount = 0;
        }


        public int Size
        {
            get { return _size; }
        }

        public Location Location
        {
            get { return _location; }
        }

        public int X
        {
            get { return _location.X; }
        }

        public int Y
        {
            get { return _location.Y; }
        }

        public List<Ant> Ants
        {
            get { return _ants; }
            set { _ants = value; }
        }

        public Renderer.Layer Layer
        {
            get { return _layer; }
        }
    }
}