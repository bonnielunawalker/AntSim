﻿using SwinGameSDK;

namespace MyGame
{
    public class Obstacle: Drawable
    {
        private Location _location;
        private int _size;
        private readonly Layer _layer;

        public Obstacle(Location l)
        {
            _location = l;
            _size = GameLogic.Random.Next(10, 300);
            _layer = Layer.Back;
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Grey, _location.X, _location.Y, _size / 2, _size / 2);
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

        public Layer Layer
        {
            get { return _layer; }
        }
    }
}