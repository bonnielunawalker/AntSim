﻿using SwinGameSDK;

namespace MyGame
{
    public class Food : IDrawable
    {
        private readonly Location _location;

        public Food(Location l)
        {
            _location = l;
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

        public void Draw()
        {
            SwinGame.FillCircle(Color.Brown, Location.X, Location.Y, 4);
        }
    }
}