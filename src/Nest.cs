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

        public Location Location
        {
            get { return _location; }
        }

        public List<Ant> Ants
        {
            get { return _ants; }
            set { _ants = value; }
        }

        public void Draw()
        {
            SwinGame.FillCircle(Color.Orange, _location.X, _location.Y, 8);
        }
    }
}