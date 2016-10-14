using SwinGameSDK;

namespace MyGame
{
    public class Waypoint : Drawable
    {
        private readonly Location _location;
        private readonly Layer _layer;

        public Waypoint(Location l)
        {
            _location = l;
            _layer = Layer.Mid;

            GameLogic.Renderer.AddDrawable(this);
        }

        public Waypoint(Node n)
            : this(new Location(n.X, n.Y))
        {

        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Blue, _location.X, _location.Y, 4, 4);
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

        public Layer Layer
        {
            get { return _layer; }
        }
    }
}