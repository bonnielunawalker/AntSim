namespace MyGame
{
    public class Ant : Creature
    {
        private Nest _nest;
        private bool _wander;
        private bool _return;
        private bool _getFood;

        public Ant(Nest n)
            : base(n.Location)
        {
            _nest = n;
            _wander = true;
            _return = false;
            _getFood = false;
        }

        public Nest Nest
        {
            get { return _nest; }
            set { _nest = value; }
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
                base.Move();
        }

        public void CheckFood()
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
            return (f.Location.X - Location.X < 50 && f.Location.X - Location.X > -50 )
                    && (f.Location.Y - Location.Y < 50 && f.Location.Y - Location.Y > -50);
        }
    }
}