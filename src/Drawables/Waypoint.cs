namespace MyGame
{
    public class Waypoint : Drawable
    {
        private readonly Location _location;

        public Waypoint(Location l)
        {
            _location = l;
        }

        public Waypoint(Node n)
            : this(new Location(n.X, n.Y))
        {

        }

        public void Draw()
        {
            //SwinGame.FillRectangle(Color.Blue, _location.X, _location.Y, 4, 4);
            return;
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
    }
}