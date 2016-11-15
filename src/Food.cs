using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace AntSim
{
    public class Food : ICollidable
    {
        private readonly Location _location;
        private int _size;
        private readonly Renderer.Layer _layer;

        public Food(Location l)
        {
            _location = l;
            _size = GameLogic.Random.Next(20, 75);
            _layer = Renderer.Layer.Back;
        }

        public int TakeFood(int takeAmount)
        {
            Console.WriteLine("Taking food");
            _size = _size - takeAmount;
            return takeAmount;
        }

        public void Draw()
        {
            SwinGame.FillCircle(Color.Brown, Location.X, Location.Y, _size / 5);
        }

        public bool CheckCollision(Location l)
        {
            Point2D pointToCheck = new Point2D();
            pointToCheck.X = l.X;
            pointToCheck.Y = l.Y;
            return SwinGame.PointInCircle(pointToCheck, _location.X, _location.Y, _size / 5);
        }

        public static void RemoveEmptyFoods(List<Food> food)
        {
            foreach (Food f in food)
                if (f.Size == 0)
                    f.Delete(food);
        }

        public void Delete(List<Food> food)
        {
            food.Remove(this);
            GameLogic.Renderer.RemoveDrawable(this);
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

        public int Size
        {
            get { return _size; }
        }

        public Renderer.Layer Layer
        {
            get { return _layer; }
        }
    }
}