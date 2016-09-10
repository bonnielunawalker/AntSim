using SwinGameSDK;

namespace MyGame
{
    public abstract class DrawableObject : IHasLocation
    {
        private Location _location;

        public Location Location
        {
            get { return _location; }
        }

        public void Draw()
        {

        }

    }
}