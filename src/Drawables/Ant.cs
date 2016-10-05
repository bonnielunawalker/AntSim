using System;

namespace MyGame
{
    public class Ant : Creature
    {
        private readonly Nest _nest;

        private PathingState _state;

        private int _food;
        private readonly int _maxFood;

        private Food _targetFood;

        public Ant(Nest n)
            :base(new Location(n.Location))
        {
            _nest = n;

            _state = PathingState.GetFood;

            _maxFood = 1;
        }

        public override void Move()
        {
            foreach (Food f in GameLogic.Foods)
            {
                if (f.CheckCollision(Location) && _food < _maxFood)
                {
                    if (f.Size == 0)
                        _state = PathingState.Return;
                    else
                        _food = f.TakeFood(1);
                }
            }

            if (_food == _maxFood)
                _state = PathingState.Return;

            if (_nest.CheckCollision(Location))
            {
                _nest.AddFood(_food);
                _food = 0;
                _state = PathingState.GetFood;
                CurrentPath = null;
            }

            if (_state == PathingState.Wander)
            {
                if (CurrentPath == null || Location.IsAt(CurrentPath.Destination))
                    CurrentPath = Wander();
            }
            else if (_state == PathingState.GetFood)
            {
                if (CurrentPath == null || Location.IsAt(CurrentPath.Destination))
                    CurrentPath = GetPathToFood();
            }
            else if (_state == PathingState.Return)
            {
                CurrentPath = GetPathTo(_nest.Location);
                LeavePheremone();
            }


            base.Move();
        }

        public Path GetPathToFood()
        {
            _targetFood = GetBestFood();
            Location destination = new Location(_targetFood.Location);
            return GetPathTo(destination);
        }

        public Food GetBestFood()
        {
            Food bestFood = null;
            int bestScore = 0;

            foreach (Food f in GameLogic.Foods)
            {
                if (100 + f.Size + GameLogic.Random.Next(50) -
                    PathingUtils.GetFScore(f.Location, new Node(Location.X, Location.Y)) > bestScore)
                {
                    bestFood = f;
                    bestScore = f.Size;
                }
            }

            return bestFood;
        }

        public void LeavePheremone()
        {
            foreach (Pheremone p in GameLogic.Pheremones)
            {
                if (p.Location.IsAt(Location))
                {
                    if (p.Strength < _targetFood.Size)
                        p.Strength = _targetFood.Size;

                    return;
                }

            }

            GameLogic.Pheremones.Add(new Pheremone(new Location(Location), (Byte)_targetFood.Size));
        }


        public Nest Nest
        {
            get { return _nest; }
        }

        public PathingState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int Food
        {
            get { return _food; }
        }
    }
}