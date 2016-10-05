namespace MyGame
{
    public interface Drawable
    {
        Layer Layer
        {
            get;
        }

        Location Location
        {
            get;
        }

        int X { get; }
        int Y { get; }

        void Draw();
    }
}