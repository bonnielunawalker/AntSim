using System;

namespace MyGame
{
    public class Ant : Creature
    {

        private Nest _nest;
        private bool _wander;
        private bool _return;
        private bool _getFood;

        public Ant(Location l, Nest n)
            : base(l)
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

        public bool Wander
        {
            get { return _wander; }
            set { _wander = value; }
        }

        public bool Return
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
                if (CurrentPath == null)
                {
                    Wander();
                    base.Move();
                }
                else
                    base.Move();
            }
            else if (_getFood)
                base.Move();
        }
    }
}