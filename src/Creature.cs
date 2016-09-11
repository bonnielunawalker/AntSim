using System;
using SwinGameSDK;

namespace MyGame
{
    public class Creature : IDrawable
    {
        private Path _currentPath;
        private Waypoint _currentWaypoint;
        private Path _newPath;
        private Location _location;

        public Creature(Location l)
        {
            _location = l;
        }

        public Location Location
        {
            get { return _location; }
        }

        public Path NewPath
        {
            get { return _newPath; }
            set { _newPath = value; }
        }

        public Path CurrentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        public Path GetPathTo(Location d)
        {
           return new Path(Location, d);
        }

        public void Move()
        {
            if (_currentWaypoint == null)
                _currentWaypoint = _currentPath.Waypoints.First.Value;

            if (Location == _currentPath.Destination)
                Console.WriteLine("Made it!");
            else
            {
                if (_currentWaypoint.Location.X < Location.X)
                    Location.X--;
                else if (_currentWaypoint.Location.X > Location.X)
                    Location.X++;

                if (_currentWaypoint.Location.Y < Location.Y)
                    Location.Y--;
                else if (_currentWaypoint.Location.Y > Location.Y)
                    Location.Y++;
            }

            if (Location.X == _currentWaypoint.Location.X && Location.Y == _currentWaypoint.Location.Y)
                _currentWaypoint = _currentPath.NextWaypoint(_currentWaypoint);
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Red, _location.X, _location.Y, 4, 4);
        }
    }
}