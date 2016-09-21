namespace MyGame
{
    public class Location
    {
        private int _x, _y;

        public Location(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Location()
            :this (GameLogic.Random.Next(GameState.WindowWidth), GameLogic.Random.Next(GameState.WindowWidth))
        {

        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}