using System;
using SwinGameSDK;

namespace AntSim
{
    public class Ant : Creature
    {
        private readonly Nest _nest;
        private PathingState _state;
        private int _food;
        private readonly int _maxFood;
        private Food _targetFood;
        private static readonly int _pathfindingRandomness = 1000;
        private static readonly int _searchRadius = 30;
        private Location _previousNode;
        private int _pheremoneThreshold;

        public Ant(Nest n)
            :base(new Location(n.Location), 4)
        {
            _nest = n;
            _state = PathingState.GetFood;
            _maxFood = 1;
            _pheremoneThreshold = GameLogic.Random.Next(10, 1000);
        }

        public void GetMove()
        {
            if (_state == PathingState.Return)
            {
                if (CurrentPath == null || !CurrentPath.Destination.IsAt(_nest.Location))
                    CurrentPath = GetPathTo(_nest.Location);
                if (_food == _maxFood)
                    LeavePheremone();
            }

            if (_nest.CheckCollision(Location) && _state == PathingState.Return)
            {
                _nest.UpdateFood(ref _food);
                _state = PathingState.GetFood;
                CurrentPath = null;
                _targetFood = null;
                CurrentWaypoint = null;
            }

            if (CurrentPath == null && NearestPheremone() != null)
                CurrentPath = Path.ConstructPathFromTrail(NearestPheremone());

            if (_food == _maxFood)
            {
                _state = PathingState.Return;
                if (!CurrentPath.Destination.IsAt(_nest.Location))
                    CurrentPath = GetPathTo(_nest.Location);
            }
            else
                CheckFoodCollision();

            if (_state == PathingState.GetFood)
                if (CurrentPath == null)
                    CurrentPath = GetPathToFood();

            _previousNode = World.Instance.Grid[Location.X, Location.Y];
        }

        private Pheromone NearestPheremone()
        {
            for (int x = Location.X - _searchRadius; x < Location.X + _searchRadius; x++)
                for (int y = Location.Y - _searchRadius; y < Location.X + _searchRadius; y++)
                {
                    Pheromone p = World.Instance.PheremoneAt(x, y);
                    if (p.Size >= _pheremoneThreshold)
                        return p;
                }

            return null;
        }

        // TODO: Replace with quadtrees
        private void CheckFoodCollision()
        {
            for (int i = 0; i < World.Instance.Foods.Count; i++)
                if (World.Instance.Foods[i].CheckCollision(Location))
                {
                    _targetFood = World.Instance.Foods[i]; // If ants collide with another food on their way to their target food, their target food will be overwritten
                    _food = _targetFood.TakeFood(1);
                    return;
                }
        }

        private Path GetPathToFood()
        {
            _targetFood = GetBestFood();
            return GetPathTo(_targetFood.Location);
        }

        private Food GetBestFood()
        {
            Food bestFood = null;
            int bestScore = 0;
            int currentScore;

            foreach (Food f in World.Instance.Foods)
            {
                 currentScore = f.Size + GameLogic.Random.Next(_pathfindingRandomness);

                // Score cannot be negative
                if (currentScore - Node.GetFScore(PathingUtils.NodeAt(f.Location),
                                                  PathingUtils.NodeAt(Location.X, Location.Y)) < 0)
                    currentScore = 0;

                if (currentScore >= bestScore)
                {
                    bestFood = f;
                    bestScore = currentScore;
                }
            }

            return bestFood;
        }

        private void LeavePheremone()
        {
            Pheromone p = World.Instance.PheremoneAt(X, Y);
            if (p.Size < _targetFood.Size * Pheromone.SizeFactor)
                p.Size = _targetFood.Size * Pheromone.SizeFactor;

            p.Parent = World.Instance.Grid[_previousNode.X, _previousNode.Y].Pheromone;
        }

        public override void Draw()
        {
            SwinGame.FillRectangle(SwinGame.RGBAColor(255, 0, (byte)_pheremoneThreshold, 255) , Location.X, Location.Y, 4, Size);
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