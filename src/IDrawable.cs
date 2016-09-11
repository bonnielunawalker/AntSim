namespace MyGame
{
    public interface IDrawable : IHasLocation
    {
        Location Location
        {
            get;
        }

        void Draw();
    }
}