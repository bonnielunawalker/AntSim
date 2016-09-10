using System;
using SwinGameSDK;

namespace MyGame
{
    public abstract class DrawableObject : IHasLocation
    {
        private Location _location;

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
            SwinGame.FillCircle(Color.Red, _location.X, _location.Y, 4);
        }

    }
}