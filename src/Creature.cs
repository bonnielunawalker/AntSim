using System;
using SwinGameSDK;

namespace MyGame
{
    public abstract class Creature : IDrawable
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
            set { _location = value; }
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

        public Waypoint CurrentWaypoint
        {
            get { return _currentWaypoint; }
            set { _currentWaypoint = value; }
        }

        public Path GetPathTo(Location d)
        {
           return new Path(Location, d);
        }

        public virtual void Move()
        {
            if (CurrentWaypoint == null)
                if (CurrentPath == null)
                {
                    CurrentPath = Wander();
                    return;
                }
                else
                    CurrentWaypoint = CurrentPath.Waypoints.First.Value;

            if (Location == CurrentPath.Destination)
                Console.WriteLine("Made it!");
            else
            {
                if (CurrentWaypoint.Location.X < Location.X)
                    Location.X--;
                else if (CurrentWaypoint.Location.X > Location.X)
                    Location.X++;

                if (CurrentWaypoint.Location.Y < Location.Y)
                    Location.Y--;
                else if (CurrentWaypoint.Location.Y > Location.Y)
                    Location.Y++;
            }

            if (Location.X == CurrentWaypoint.Location.X && Location.Y == CurrentWaypoint.Location.Y)
                CurrentWaypoint = CurrentPath.NextWaypoint(CurrentWaypoint);
        }

        public Path Wander()
        {
            Location destination = new Location(GameLogic.Random.Next(Location.X - 70, Location.X + 70),
                                                GameLogic.Random.Next(Location.Y - 70, Location.Y + 70));
            return GetPathTo(destination);
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Red, Location.X, Location.Y, 4, 4);
        }
    }
}