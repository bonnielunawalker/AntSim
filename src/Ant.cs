using System;

namespace MyGame
{
    public class Ant : Creature
    {
        private Nest _nest;

        public Ant(Location l, Nest n)
            : base(l)
        {
            _nest = n;
        }

        public Nest Nest
        {
            get { return _nest; }
            set { _nest = value; }
        }
    }
}