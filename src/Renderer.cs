using System.Collections.Generic;

namespace AntSim
{
    public class Renderer
    {
        public enum Layer
        {
            Front,
            Mid,
            Back
        }

        private List<IDrawable> _drawables;

        public Renderer()
        {
            _drawables = new List<IDrawable>();
        }

        public void AddDrawable(IDrawable drawable)
        {
            _drawables.Add(drawable);
        }

        public void RemoveDrawable(IDrawable drawable)
        {
            _drawables.Remove(drawable);
        }

        public void RenderAll()
        {
            Render(Layer.Back);
            Render(Layer.Mid);
            Render(Layer.Front);
        }

        private void Render(Layer l)
        {
            foreach (IDrawable d in _drawables)
                if (d.Layer == l)
                    d.Draw();
        }

        public List<IDrawable> Drawables
        {
            get { return _drawables; }
        }
    }
}