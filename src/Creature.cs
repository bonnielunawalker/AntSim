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
        }

        public Path GetPathTo(Location l)
        {
           return new Path();
        }
    }
}