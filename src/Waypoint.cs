using SwinGameSDK;
namespace MyGame
{
    public class Waypoint : IDrawable
    {
        private readonly Location _location;

        public Waypoint(Location l)
        {
            _location = l;
        }

        public Location Location
        {
            get { return _location; }
        }

        public bool IsAt(Location d)
        {
            return _location.X == d.X && _location.Y == d.Y;
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Blue, _location.X, _location.Y, 4, 4);
        }
    }
}