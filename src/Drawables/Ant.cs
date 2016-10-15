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

        public void GetMove()
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
                CurrentPath = GetPathTo(_nest.Location);
                LeavePheremone();
            }
            Move();

            CurrentPath = null;
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
            return new Path(Location, PathingUtils.EstimateLocation(Location, d));
        }

        public Path GetPathToFood()
        {
            if (_targetFood == null)
                _targetFood = GetBestFood();
            return GetPathTo(_targetFood.Location);
        }

        public Food GetBestFood()
        {
            Food bestFood = null;
            int bestScore = 0;
            int currentScore;

            foreach (Food f in World.Instance.Foods)
            {
                currentScore = f.Size + GameLogic.Random.Next(50);

                if (currentScore - PathingUtils.GetFScore(PathingUtils.NodeAt(f.Location), PathingUtils.NodeAt(Location.X, Location.Y)) < 0)
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
            Pheremone p = World.Instance.Grid.Nodes[X,Y].Pheremone;
            if (p.Strength < _targetFood.Size * 100)
                p.Strength = (byte)_targetFood.Size * 100;


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