using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Nest : Collidable
    {
        private readonly Location _location;
        private List<Ant> _ants;
        private readonly int _size;
        private int _food;
        private readonly Layer _layer;

        public Nest(Location l)
        {
            _location = l;
            _ants = new List<Ant>();
            _size = 8;
            _layer = Layer.Back;
        }

        public void Draw()
        {
            SwinGame.FillCircle(Color.Orange, _location.X, _location.Y, _size);
        }

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
                    _food -= 10;
                }
            }
        }

        private bool FoodThresholdReached()
        {
            return (_food >= 10);
        }

        public void AddFood(int amount)
        {
            _food += amount;
            Console.WriteLine(_food);
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

        public Layer Layer
        {
            get { return _layer; }
        }
    }
}