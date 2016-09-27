using System;

namespace MyGame
{
    public class Ant : Creature
    {
        private Nest _nest;
        private bool _wander;
        private bool _return;
        private bool _getFood;
        private int _food;
        private int _maxFood;

        public Ant(Nest n)
            : base(new Location(n.Location))
        {
            _nest = n;

            _wander = false;
            _return = false;
            _getFood = true;

            _maxFood = 1;
        }

        public override void Move()
        {
            if (_wander)
            {
                if (CurrentPath == null || (Location.X == CurrentPath.Destination.X
                                            && Location.Y == CurrentPath.Destination.Y))
                    CurrentPath = Wander();

                base.Move();
            }
            else if (_getFood)
            {
                if (CurrentPath == null || (Location.X == CurrentPath.Destination.X
                                            && Location.Y == CurrentPath.Destination.Y))
                    CurrentPath = GetPathToFood();
            }

            foreach (Food f in GameLogic.Food)
            {
                if (f.CheckCollision(Location) && _food < _maxFood)
                {
                    Console.WriteLine("Taking food!");
                    _food = f.TakeFood(1);
                }
            }

            if (_nest.CheckCollision(Location))
            {
                _nest.AddFood(_food);
                _food = 0;
            }

            base.Move();
        }

        public Path GetPathToFood()
        {
            Location destination = new Location(GameLogic.Food[GameLogic.Random.Next(GameLogic.Food.Count)].Location);
            return GetPathTo(destination);
        }

        public void CheckForFood()
        {
            foreach (Food f in GameLogic.Food)
            {
                if (FoodProximity(f))
                {
                    CurrentPath = GetPathTo(f.Location);
                    _wander = false;
                    _getFood = true;
                    return;
                }
            }
        }

        private bool FoodProximity(Food f)
        {
            return (f.Location.X - Location.X < 300 && f.Location.X - Location.X > -300 )
                    && (f.Location.Y - Location.Y < 300 && f.Location.Y - Location.Y > -300);
        }


        public Nest Nest
        {
            get { return _nest; }
        }

        public bool Wandering
        {
            get { return _wander; }
            set { _wander = value; }
        }

        public bool Returning
        {
            get { return _return; }
            set { _return = value; }
        }

        public bool GetFood
        {
            get { return _getFood; }
            set { _getFood = value; }
        }
    }
}