using System;

namespace MyGame
{
    public interface IDrawable
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