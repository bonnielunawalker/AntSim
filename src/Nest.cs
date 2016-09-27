using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class Nest : IDrawable
    {
        private readonly Location _location;
        private List<Ant> _ants;

        public Nest(Location l)
        {
            _location = l;
            _ants = new List<Ant>();
        }

        public void Draw()
        {
            SwinGame.FillCircle(Color.Orange, _location.X, _location.Y, 8);
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