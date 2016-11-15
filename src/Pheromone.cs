using SwinGameSDK;

namespace AntSim
{
    public class Pheromone : IDrawable
    {
        private static int _sizeFactor = 10;
        private int _size;
        private Location _location;
        private Renderer.Layer _layer;
        private static int _decayRate = 2;
        private Pheromone _parent;

        public Pheromone(Location location, int strength)
        {
            _size = strength * _sizeFactor;
            _location = location;
            _layer = Renderer.Layer.Mid;
        }

        public void Draw()
        {
            SwinGame.FillRectangle(SwinGame.RGBAColor(245, 245, 0, (byte)(_size / _sizeFactor)),
                                   _location.X, _location.Y, 4, 4);
        }

        public void Decay()
        {
            if (Size < _decayRate)
                Size = 0;
            else if (Size > 0)
                Size -= _decayRate * (_sizeFactor / 10);
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
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

        public Renderer.Layer Layer
        {
            get { return _layer; }
        }

        public static int SizeFactor
        {
            get { return _sizeFactor; }
        }

        public Pheromone Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
    }
}