using SwinGameSDK;

namespace MyGame
{
    public class Pheremone : Drawable
    {
        private int _strength;
        private Location _location;

        public Pheremone(Location location, byte strength)
        {
            _strength = strength * 100;
            _location = location;
        }

        public void Draw()
        {
            SwinGame.FillRectangle(SwinGame.RGBAColor(245, 245, 0, (byte)(_strength / 100)), _location.X, _location.Y, 4, 4);
        }

        public int Strength
        {
            get { return _strength; }
            set { _strength = value * 100; }
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
    }
}