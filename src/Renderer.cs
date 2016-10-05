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

        public void RenderAll()
        {
            Render(Layer.Back);
            Render(Layer.Mid);
            Render(Layer.Front);
        }

        private void Render(Layer l)
        {
            foreach (Drawable d in _drawables)
            {
                if (d.Layer == l)
                    d.Draw();
            }
        }

        public List<Drawable> Drawables
        {
            get { return _drawables; }
        }
    }
}