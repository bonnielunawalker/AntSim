using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class Nest : ICollidable
    {
        private readonly Location _location;
        private List<Ant> _ants;
        private readonly int _size;

        public Nest(Location l)
        {
            _location = l;
            _ants = new List<Ant>();
            _size = 8;
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
    }
}