using SwinGameSDK;

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

        public void Draw()
        {
            SwinGame.FillRectangle(Color.Blue, _x, _y, 4, 4);
        }
    }
}