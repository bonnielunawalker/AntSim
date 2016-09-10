using System.Collections.Generic;

namespace MyGame
{
    public class Creature : DrawableObject
    {
        private Path _currentPath;
        private List<Waypoint> _newPath;
        private Location _location;

        public Creature(Location l)
            : base (l)
        {
            _location = l;
        }

        public Path CurrentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        public Path GetPathTo(Location d)
        {
           return new Path(_location, d);
        }

        public void Move()
        {

        }
    }
}