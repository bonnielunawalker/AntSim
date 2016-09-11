using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Creature : DrawableObject
    {
        private Path _currentPath;
        private Waypoint _currentWaypoint;
        private Path _newPath;

        public Creature(Location l)
            : base (l)
        {

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

            Console.WriteLine(_currentWaypoint.Location.X);
            //Console.WriteLine(_currentWaypoint.Location.Y);
            Console.WriteLine(Location.X);
            //Console.WriteLine(Location.Y);


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
    }
}