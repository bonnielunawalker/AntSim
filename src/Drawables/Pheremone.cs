using System;
using SwinGameSDK;

namespace MyGame
{
    public class Pheremone : Drawable
    {
        private int _strength;
        private Location _location;
        private Layer _layer;
        private static int _decayRate = 2;

        public Pheremone(Location location, byte strength)
        {
            _strength = strength * 100;
            _location = location;
            _layer = Layer.Mid;
        }

        public void Draw()
        {
            SwinGame.FillRectangle(SwinGame.RGBAColor(245, 245, 0, (byte)(_strength / 100)),
                                   _location.X, _location.Y, 4, 4);
        }

        public void Decay()
        {
            if (Strength < _decayRate)
                Strength = 0;

            if (Strength > 0)
                Strength -= _decayRate;
        }

        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int X
        {
            get { return _location.X; }
            set { _location.X = value; }
        }

        public int Y
        {
            get { return _location.Y; }
            set { _location.Y = value; }
        }

        public Layer Layer
        {
            get { return _layer; }
        }
    }
}