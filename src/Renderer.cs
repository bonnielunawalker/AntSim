using System.Collections.Generic;

namespace MyGame
{
    public class Renderer
    {
        private List<Drawable> _drawables;

        public Renderer()
        {
            _drawables = new List<Drawable>();
        }

        public void AddDrawable(Drawable drawable)
        {
            _drawables.Add(drawable);
        }

        public void Render()
        {
            foreach (Drawable d in _drawables)
                d.Draw();
        }
    }
}