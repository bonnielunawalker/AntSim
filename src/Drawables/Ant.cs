using System;
using SwinGameSDK;

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
            :base(new Location(n.Location), 4)
        {
            _nest = n;
            _state = PathingState.GetFood;
            _maxFood = 1;
        }

        public override void Move()
        {
            CheckFoodCollision();

            if (_food == _maxFood && _state == PathingState.GetFood)
            {
                _state = PathingState.Return;
                CurrentPath = null;
            }

            if (_nest.CheckCollision(Location))
            {
                _nest.AddFood(ref _food);
                _state = PathingState.GetFood;
                CurrentPath = null;
                _targetFood = null;
                CurrentWaypoint = null;
            }

            if (_state == PathingState.GetFood)
            {
                if (CurrentPath == null)
                    _targetFood = GetBestFood();
                CurrentPath = GetPathToFood();
                CurrentWaypoint = null;

            }
            else if (_state == PathingState.Return)
            {
                if (CurrentPath == null)
                    CurrentPath = GetPathTo(_nest.Location);
                LeavePheremone();
            }
            base.Move();
        }

        public void CheckFoodCollision()
        {
            for (int i = 0; i < World.Instance.Foods.Count; i++)
            {
                if (World.Instance.Foods[i].CheckCollision(Location) && _food < _maxFood)
                {
                    if (World.Instance.Foods[i].Size == 0)
                        _state = PathingState.GetFood;
                    else
                        _food = World.Instance.Foods[i].TakeFood(1);
                }
            }
        }

        public override Path GetPathTo(Location d)
        {
            return new Path(Location, d);
        }

        public Path GetPathToFood()
        {
            if (_targetFood == null)
                _targetFood = GetBestFood();
            return GetPathTo(PathingUtils.EstimateLocation(Location, _targetFood.Location));
        }

        public Food GetBestFood()
        {
            Food bestFood = null;
            int bestScore = 0;
            int currentScore = 0;

            foreach (Food f in World.Instance.Foods)
            {
                currentScore = f.Size + GameLogic.Random.Next(50);

                if (currentScore - PathingUtils.GetFScore(f.Location, new Node(Location.X, Location.Y)) < 0)
                    currentScore = 0;

                if (currentScore >= bestScore)
                {
                    bestFood = f;
                    bestScore = f.Size;
                }
            }

            return bestFood;
        }

        public void LeavePheremone()
        {
            foreach (Pheremone p in World.Instance.Pheremones)
            {
                if (p.Location.IsAt(Location))
                {
                    if (p.Strength < _targetFood.Size * 100)
                        p.Strength = _targetFood.Size * 100;

                    return;
                }
            }

            World.Instance.Pheremones.Add(new Pheremone(new Location(Location), (Byte)_targetFood.Size));
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