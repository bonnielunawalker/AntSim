using System;
using SwinGameSDK;

namespace MyGame
{
    public abstract class DrawableObject : IHasLocation
    {
        private readonly Location _location;

        public DrawableObject(Location l)
        {
            _location = l;
        }

        public Location Location
        {
            get { return _location; }
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Red, _location.X, _location.Y, 4, 4);
        }

    }
}