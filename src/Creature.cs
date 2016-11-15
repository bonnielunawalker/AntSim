namespace AntSim
{
    public abstract class Creature : IDrawable
    {
        private Path _currentPath;
        private Node _currentWaypoint;
        private Location _location;
        private readonly Renderer.Layer _layer;
        private int _size;

        public Creature(Location l, int size)
        {
            _location = l;
            _layer = Renderer.Layer.Front;
            _size = size;
        }

        public virtual Path GetPathTo(Location d)
        {
            return new Path(Location, d);
        }

        public virtual void Move()
        {
            if (CurrentWaypoint == null)
                CurrentWaypoint = CurrentPath.Waypoints.First.Value;

            if (CurrentWaypoint.X < Location.X)
                Location.X--;
            else if (CurrentWaypoint.X > Location.X)
                Location.X++;

            if (CurrentWaypoint.Y < Location.Y)
                Location.Y--;
            else if (CurrentWaypoint.Y > Location.Y)
                Location.Y++;

            if (_location.IsAt(CurrentWaypoint) && CurrentPath != null)
                CurrentWaypoint = CurrentPath.NextWaypoint(CurrentWaypoint);

        }

        public abstract void Draw();


        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int X
        {
            get { return _location.X; }
        }

        public int Y
        {
            get { return _location.Y; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Path CurrentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        public Node CurrentWaypoint
        {
            get { return _currentWaypoint; }
            set { _currentWaypoint = value; }
        }

        public Renderer.Layer Layer
        {
            get { return _layer; }
        }
    }
}