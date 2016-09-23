using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
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

        public int X
        {
            get { return _location.X; }
        }

        public int Y
        {
            get { return _location.Y; }
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
            {
                if (CurrentPath == null)
                    CurrentPath = Wander();
                else
                    CurrentWaypoint = CurrentPath.Waypoints.First.Value;
            }

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
            Location destination = new Location(GameLogic.Random.Next(Location.X - 100, Location.X + 100),
                                                GameLogic.Random.Next(Location.Y - 100, Location.Y + 100));
            return GetPathTo(destination);
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Red, Location.X, Location.Y, 4, 4);
        }

        public bool CheckCollision(Obstacle obstacle)
        {
            int leftEdge = obstacle.X - (obstacle.Size / 2);
            int topEdge = obstacle.Y - (obstacle.Size / 2);
            Location topLeft = new Location(leftEdge, topEdge);
            Location bottomRight = new Location(leftEdge + obstacle.Size, topEdge + obstacle.Size);

            return UtilityFunctions.InField(this, topLeft, bottomRight);
        }
    }
}