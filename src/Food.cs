﻿using SwinGameSDK;

namespace MyGame
{
    public class Food : ICollidable
    {
        private readonly Location _location;
        private int _size;

        public Food(Location l)
        {
            _location = l;
            _size = GameLogic.Random.Next(15, 100);
        }

        public int TakeFood(int takeAmount)
        {
            _size -= takeAmount;
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
    }
}