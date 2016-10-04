namespace MyGame
{
    public interface Drawable
    {
        Location Location
        {
            get;
        }

        int X { get; }
        int Y { get; }

        void Draw();
    }
}