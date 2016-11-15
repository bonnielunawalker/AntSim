namespace AntSim
{
    public interface IDrawable
    {
        Renderer.Layer Layer
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