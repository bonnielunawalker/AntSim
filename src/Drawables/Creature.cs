using System;
using SwinGameSDK;

namespace MyGame
{
    public abstract class Creature : Drawable
    {
        private Path _currentPath;
        private Waypoint _currentWaypoint;
        private Path _newPath;
        private Location _location;
        private readonly Layer _layer;

        public Creature(Location l)
        {
            _location = l;
            _layer = Layer.Front;
        }

        public virtual Path GetPathTo(Location d)
        {
            return new Path(Location, d);
        }

        public virtual void Move()
        {
            if (CurrentWaypoint == null)
            {
                CurrentWaypoint = CurrentPath.Waypoints.First.Value;
            }

            if (_location.IsAt(CurrentPath.Destination))
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

            if (_location.IsAt(CurrentWaypoint.Location))
                CurrentWaypoint = CurrentPath.NextWaypoint(CurrentWaypoint);
        }

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Red, Location.X, Location.Y, 4, 4);
        }

        public bool CheckCollision(Collidable collidable)
        {
            int leftEdge = collidable.X - (collidable.Size / 2);
            int topEdge = collidable.Y - (collidable.Size / 2);
            Location topLeft = new Location(leftEdge, topEdge);
            Location bottomRight = new Location(leftEdge + collidable.Size, topEdge + collidable.Size);

            return UtilityFunctions.InField(this, topLeft, bottomRight);
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

        public Layer Layer
        {
            get { return _layer; }
        }
    }
}